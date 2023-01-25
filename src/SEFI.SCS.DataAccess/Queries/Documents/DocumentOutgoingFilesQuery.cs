using System.Data;
using System.Collections.Generic;
using SEFI.Classes;
using SEFI.Queries;
using SEFI.Enums;
namespace SEFI.SCS.DataAccess.Queries.Documents
{
    public class DocumentOutgoingFilesQuery : IQuery
    {
        
        public virtual int? Id{ get; set; }
        public virtual string TpaCode{ get; set; }
        public virtual int? DetailId{ get; set; }
        public virtual Filters Filters
        {
            get
            {
                return BuildFilters();
            }
        }
        
        private Filters BuildFilters()
        {
            Filters returnValue;
            returnValue = new Filters();
            if ((Id != null))
            {
                Filter filter = new Filter();
                ValueObject filterValue = new ValueObject();
                filterValue.Value = Id;
                filterValue.DbType = DbType.Int32;
                filter.Name = "By Id";
                filter.PropertyName = "Id";
                filter.FieldName = "ioutgoing_file_id";
                filter.Value = filterValue;
                returnValue.FilterList.Add(new KeyValuePair<SEFI.Interfaces.IFilter, LogicOperator>(filter, LogicOperator.Empty));
            }
            if ((TpaCode != null))
            {
                Filter filter = new Filter();
                ValueObject filterValue = new ValueObject();
                filterValue.Value = TpaCode;
                filterValue.DbType = DbType.StringFixedLength;
                filterValue.Size = 4;
                filter.Name = "By TpaCode";
                filter.PropertyName = "TpaCode";
                filter.FieldName = "stpa_code";
                filter.Value = filterValue;
                returnValue.FilterList.Add(new KeyValuePair<SEFI.Interfaces.IFilter, LogicOperator>(filter, LogicOperator.Empty));
            }
            if ((DetailId != null))
            {
                Filter filter = new Filter();
                ValueObject filterValue = new ValueObject();
                filterValue.Value = DetailId;
                filterValue.DbType = DbType.Int32;
                filter.Name = "By DetailId";
                filter.PropertyName = "DetailId";
                filter.FieldName = "ioutgoing_detail_id";
                filter.Value = filterValue;
                returnValue.FilterList.Add(new KeyValuePair<SEFI.Interfaces.IFilter, LogicOperator>(filter, LogicOperator.Empty));
            }
            return returnValue;
        }
    }
}
