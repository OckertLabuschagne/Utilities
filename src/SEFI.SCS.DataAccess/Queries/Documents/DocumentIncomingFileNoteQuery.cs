using System.Collections.Generic;
using System.Data;
using SEFI.Classes;
using SEFI.Queries;
using SEFI.Enums;
namespace SEFI.SCS.DataAccess.Queries.Documents
{
    public class DocumentIncomingFileNoteQuery : IQuery
    {

        public virtual int? Id { get; set; }
        public virtual int? FileId { get; set; }

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
                filter.FieldName = "iincoming_file_note_id";
                filter.Value = filterValue;
                returnValue.FilterList.Add(new KeyValuePair<Interfaces.IFilter, LogicOperator>(filter, LogicOperator.Empty));
            }
            else if (FileId != null)
            {
                Filter filter = new Filter();
                ValueObject filterValue = new ValueObject();
                filterValue.Value = FileId;
                filterValue.DbType = DbType.Int32;
                filter.Name = "By FileId";
                filter.PropertyName = "FileId";
                filter.FieldName = "iincoming_file_id";
                filter.Value = filterValue;
                returnValue.FilterList.Add(new KeyValuePair<Interfaces.IFilter, LogicOperator>(filter, LogicOperator.Empty));
            }
            return returnValue;
        }
    }
}
