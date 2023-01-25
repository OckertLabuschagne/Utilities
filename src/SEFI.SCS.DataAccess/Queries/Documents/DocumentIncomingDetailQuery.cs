using System.Data;
using System.Collections.Generic;
using SEFI.Classes;
using SEFI.Queries;
using SEFI.Enums;

namespace SEFI.SCS.DataAccess.Queries.Documents
{
    public class DocumentIncomingDetailQuery : IQuery
    {
        
        public virtual int? ID{ get; set; }
        public virtual int? Module{ get; set; }
        public virtual int? ModuleKeyId{ get; set; }
        public virtual Filters Filters => BuildFilters();
        
        private Filters BuildFilters()
        {
            Filters returnValue;
            returnValue = new Filters();
            if ((this.ID != null))
            {
                Filter filter = new Filter();
                ValueObject filterValue = new ValueObject();
                filterValue.Value = this.ID;
                filter.Name = "By ID";
                filter.PropertyName = "ID";
                filter.FieldName = "iincoming_detail_id";
                filter.Value = filterValue;
                returnValue.FilterList.Add(new KeyValuePair<SEFI.Interfaces.IFilter, LogicOperator>(filter, LogicOperator.Empty));
            }
            if ((this.Module != null))
            {
                Filter filter = new Filter();
                ValueObject filterValue = new ValueObject();
                filterValue.Value = this.Module;
                filter.Name = "By Module";
                filter.PropertyName = "Module";
                filter.FieldName = "idoc_module_id";
                filter.Value = filterValue;
                returnValue.FilterList.Add(new KeyValuePair<SEFI.Interfaces.IFilter, LogicOperator>(filter, LogicOperator.Empty));
            }
            if ((this.ModuleKeyId != null))
            {
                Filter filter = new Filter();
                ValueObject filterValue = new ValueObject();
                filterValue.Value = this.ModuleKeyId;
                filter.Name = "By ModuleKeyId";
                filter.PropertyName = "ModuleKeyId";
                filter.FieldName = "imodule_key_id";
                filter.Value = filterValue;
                returnValue.FilterList.Add(new KeyValuePair<SEFI.Interfaces.IFilter, LogicOperator>(filter, LogicOperator.Empty));
            }
            return returnValue;
        }
    }
}
