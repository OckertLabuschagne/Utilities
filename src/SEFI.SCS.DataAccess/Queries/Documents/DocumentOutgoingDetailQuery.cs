using System.Data;
using System.Collections.Generic;
using SEFI.Classes;
using SEFI.Queries;
using SEFI.Enums;

namespace SEFI.SCS.DataAccess.Queries.Documents
{
    public class DocumentOutgoingDetailQuery : IQuery
    {
        public virtual int? Id{ get; set; }
        public virtual int? Module{ get; set; }
        public virtual int? ModuleKeyId{ get; set; }
        public virtual Filters Filters => BuildFilters();
        
        private Filters BuildFilters()
        {
            Filters returnValue;
            returnValue = new Filters();
            if (Id != null)
            {
                Filter filter = new Filter();
                ValueObject filterValue = new ValueObject();
                filterValue.Value = Id;
                filterValue.DbType = DbType.Int32;
                filter.Name = "By Id";
                filter.PropertyName = "Id";
                filter.FieldName = "ioutgoing_detail_id";
                filter.Value = filterValue;
                returnValue.FilterList.Add(new KeyValuePair<Interfaces.IFilter, LogicOperator>(filter, LogicOperator.Empty));
            }
            if (Module != null)
            {
                Filter filter = new Filter();
                ValueObject filterValue = new ValueObject();
                filterValue.Value = Module;
                filterValue.DbType = DbType.Int32;
                filter.Name = "By Module";
                filter.PropertyName = "Module";
                filter.FieldName = "idoc_module_id";
                filter.Value = filterValue;
                returnValue.FilterList.Add(new KeyValuePair<Interfaces.IFilter, LogicOperator>(filter, LogicOperator.Empty));
            }
            if (ModuleKeyId != null)
            {
                Filter filter = new Filter();
                ValueObject filterValue = new ValueObject();
                filterValue.Value = ModuleKeyId;
                filterValue.DbType = DbType.Int32;
                filter.Name = "By ModuleKeyId";
                filter.PropertyName = "ModuleKeyId";
                filter.FieldName = "imodule_key_id";
                filter.Value = filterValue;
                returnValue.FilterList.Add(new KeyValuePair<Interfaces.IFilter, LogicOperator>(filter, LogicOperator.Empty));
            }
            return returnValue;
        }
    }
}
