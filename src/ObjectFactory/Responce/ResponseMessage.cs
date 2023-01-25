using Newtonsoft.Json;

using SEFI.Enums;
using SEFI.Extensions;
namespace SEFI.Models
{
	public class ResponseMessage
	{
        public ResponseMessage() { }
        public ResponseMessage(ResponseDetailStatusCode detailStatus
            , string message
            , string property)
        {
            Code = $"{(int)detailStatus}";
            Message = message;
            Type = detailStatus.GetEnumCategory();
            Property = property;
        }
        public string Code { get; set; }
        [JsonIgnore]
        public ResponseDetailStatusCode Status { get => (ResponseDetailStatusCode)int.Parse(Code); set => Code = $"{(int)value}"; }
        public string Type { get; set; }
		public string Message { get; set; }
		[JsonIgnore]
		public string Property { get; set; }

    }

}
