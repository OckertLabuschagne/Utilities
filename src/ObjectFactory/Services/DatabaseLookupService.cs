using System.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

using SEFI.Mappings;
using SEFI.Queries;
using SEFI.DataUtilities;
using SEFI.Factory;

namespace SEFI.Services
{

    public abstract class DatabaseLookupService : IDatabaseLookupService
    {
		public virtual async Task<List<T>> LookupAsync<T>(IQuery query
			, ObjectPropertyMap<T> mapping
			, IDbConnection connection
			, CancellationToken token
			)
		{
			List<T> retVal = null;
			await Task.Run(() =>
			{
				IDataReader reader = SQLServer.GetData(connection, mapping, query.Filters);
				if (reader.Read())
					retVal = ObjectFactory.CreateList<List<T>>(reader, mapping.PropertyMaps);

				reader.Dispose();
			});
			return retVal;
		}

		public virtual async Task<List<T>> LookupAsync<T>(IQuery query
			, ObjectPropertyMap<T> mapping
			, IDbConnection connection
			, CancellationToken token
			, Dictionary<string, T> cache = null)
		{
			List<T> retVal = null;
			await Task.Run(() =>
			{
				IDataReader reader = SQLServer.GetData(connection, mapping, query.Filters);
				if (reader != null)
				{
					if (reader.Read())
						retVal = ObjectFactory.CreateList<List<T>>(reader, mapping.PropertyMaps);
					//iterate through the values
					if (retVal != null)
					{
						for (int i = 0; i < retVal.Count; i++)
						{
							T value = retVal[i];
							//get the key
							string key = mapping.GetKey(value);
							//If the cache does not contain the object
							if (cache != null)
							{
								if (!cache.ContainsKey(key))
									//add it to the cache
									cache.Add(key, value);
								else
									//replace the object in the list with the one from the cache
									retVal[i] = cache[key];
							}
						}
					}
					reader.Dispose();
				}
			});
			return retVal;
		}

		public virtual async Task<T> GetAsync<T>(IQuery query
			, ObjectPropertyMap<T> mapping
			, IDbConnection connection
			, CancellationToken token)
		{
				List<T> list = await LookupAsync(query, mapping, connection, token);
				return list != null ? list.FirstOrDefault() : default;
		}

		public virtual async Task<T> GetAsync<T>(IQuery query
			, ObjectPropertyMap<T> mapping
			, IDbConnection connection
			, CancellationToken token
			, Dictionary<string, T> cache = null)
		{
			if (cache != null)
			{
				System.Linq.Expressions.Expression<Func<T, bool>> exception = query.Filters.GetExpression<T>(false);
				T cashedValue = cache.Values.Where(v => exception.Compile().Invoke(v)).FirstOrDefault();

				if (cashedValue != null)
					return cashedValue;

				else
				{
					List<T> list = await LookupAsync(query, mapping, connection, token, cache);
					cashedValue = list != null ? list.FirstOrDefault() : default;

					if (cashedValue != null)
					{
						string key = mapping.GetKey(cashedValue);
						if (!cache.ContainsKey(key))
							cache.Add(key, cashedValue);
					}
					return cashedValue;
				}
			}
			else
			{
				List<T> list = await LookupAsync(query, mapping, connection, token, cache);
				return list != null ? list.FirstOrDefault() : default;
			}
		}

		public virtual List<T> Lookup<T>(IQuery query
			, ObjectPropertyMap<T> mapping
			, IDbConnection connection
			)
		{
			List<T> retVal = null;
			IDataReader reader = SQLServer.GetData(connection, mapping, query.Filters);
			if (reader.Read())
				retVal = ObjectFactory.CreateList<List<T>>(reader, mapping.PropertyMaps);

			reader.Dispose();
			return retVal;
		}

		public virtual List<T> Lookup<T>(IQuery query
			, ObjectPropertyMap<T> mapping
			, IDbConnection connection
			, Dictionary<string, T> cache = null)
		{
			List<T> retVal = null;
			IDataReader reader = SQLServer.GetData(connection, mapping, query.Filters);
			if (reader != null)
			{
				if (reader.Read())
					retVal = ObjectFactory.CreateList<List<T>>(reader, mapping.PropertyMaps);
				//iterate through the values
				if (retVal != null)
				{
					for (int i = 0; i < retVal.Count; i++)
					{
						T value = retVal[i];
						//get the key
						string key = mapping.GetKey(value);
						//If the cache does not contain the object
						if (cache != null)
						{
							if (!cache.ContainsKey(key))
								//add it to the cache
								cache.Add(key, value);
							else
								//replace the object in the list with the one from the cache
								retVal[i] = cache[key];
						}
					}
				}
				reader.Dispose();
			}
			return retVal;
		}

		public virtual T Get<T>(IQuery query
			, ObjectPropertyMap<T> mapping
			, IDbConnection connection)
		{
			List<T> list = Lookup(query, mapping, connection);
			return list != null ? list.FirstOrDefault() : default;
		}

		public virtual T Get<T>(IQuery query
			, ObjectPropertyMap<T> mapping
			, IDbConnection connection
			, Dictionary<string, T> cache = null)
		{
			if (cache != null)
			{
				System.Linq.Expressions.Expression<Func<T, bool>> exception = query.Filters.GetExpression<T>(false);
				T cashedValue = cache.Values.Where(v => exception.Compile().Invoke(v)).FirstOrDefault();

				if (cashedValue != null)
					return cashedValue;

				else
				{
					List<T> list = Lookup(query, mapping, connection, cache);
					cashedValue = list != null ? list.FirstOrDefault() : default;

					if (cashedValue != null)
					{
						string key = mapping.GetKey(cashedValue);
						if (!cache.ContainsKey(key))
							cache.Add(key, cashedValue);
					}
					return cashedValue;
				}
			}
			else
			{
				List<T> list = Lookup(query, mapping, connection, cache);
				return list != null ? list.FirstOrDefault() : default;
			}
		}

    }
}
