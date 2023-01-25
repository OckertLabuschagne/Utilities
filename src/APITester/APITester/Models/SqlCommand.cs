using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SEFI.Interfaces;
using SEFI.Models;
namespace APITester.Models
{
    public class SQLCommand
    {
        public string Name { get; set; }
        public string SQL { get; set; }
        public IFilters Filters { get; set; }
        public SQLCommandType CommandType { get; set; }
        public SQLSourceType SQLSourceType { get; set; }
        public override string ToString()
        {
            return $"{Name} ({CommandType})";
        }
    }

    public class SqlCommands : List<SQLCommand>
    {
    }

    public class SQLCommadGroup
    {
        public IFilters Filters { get; set; }
        public string Name { get; set; }
        public SqlCommands Commands { get; set; }
    }

    public class SQLCommadGroups : Dictionary<string,SQLCommadGroup>
    {
        public SQLCommadGroups() { }
        public SQLCommadGroups(SQLCommandConfigurationSection configuration)
        {
            if(configuration?.SQLCommandGroups != null)
            {
                //Filters filters
            }
        }
        public IFilters Filters { get; set; }
    }

    public enum SQLCommandType
    {
        Script,
        Query,
        Scaler
    }

    public enum SQLSourceType
    {
        Resource,
        File
    }
}
