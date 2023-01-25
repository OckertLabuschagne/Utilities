using System.Collections.Generic;
using System;

using Newtonsoft.Json;

using SEFI.Enums;
using SEFI.Extensions;
using System.IO;
using System.Text;

namespace SEFI.Models
{
	public class Response
	{

        private ResponseStatusCode _Status;

        public Response() {  }

        public Response(ResponseStatusCode status
            , string dataId
            , params ResponseMessage[] responseMessages )
        {
            Status = status;
            DataID = dataId;
            Messages = new List<ResponseMessage>(responseMessages);
        }

        public string StatusCode { get => $"{(int)_Status}"; set => Status = (ResponseStatusCode)(int.Parse(value)); }
        public string StatusDescription { get; set; }
		public List<ResponseMessage> Messages { get; set; }
		public string DataID { get; set; }
        public object Data { get; set; }
        public int? FilteredCount { get; set; } = null;
        public int? TotalCount { get; set; } = null;

        [JsonIgnore]
        public ResponseStatusCode Status
        {
            get => _Status;
            set
            {
                if (Enum.IsDefined(typeof(ResponseStatusCode), value))
                {
                    _Status = value;
                    StatusDescription = value.GetEnumDescription();
                }
                else
                    throw new ArgumentException($"{value} is not a valid ResponseStatusCode");
            }
        }

        public void AddMessage(ResponseDetailStatusCode detailStatus
            , string message
            , string property)
        {
            if (message == null)
                return;
            if (Messages == null)
                Messages = new List<ResponseMessage>();
            Messages.Add(new ResponseMessage(detailStatus, message, property));
        }

        public void AddMessage(ResponseMessage message)
        {
            if (message == null)
                return;
            if (Messages == null)
                Messages = new List<ResponseMessage>();
            Messages.Add(message);
        }

        public void AddMessages(params ResponseMessage[] message)
        {
            if (message == null)
                return;
            if (Messages == null)
                Messages = new List<ResponseMessage>();
            Messages.AddRange(message);
        }

        public void AddMessages(IEnumerable<ResponseMessage> message)
        {
            if (message == null)
                return;
            if (Messages == null)
                Messages = new List<ResponseMessage>();
            Messages.AddRange(message);
        }

        public string Format(out int statusCode)
        {
            statusCode = 500;
            var sb = new StringBuilder();
            var sw = new StringWriter(sb);

            try
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartObject();
                    writer.WritePropertyName("Errors");
                    writer.WriteStartArray();

                    foreach (var message in Messages)
                    {
                        writer.WriteStartObject();
                        writer.WritePropertyName("Code");
                        writer.WriteValue(message.Code);
                        writer.WritePropertyName("Message");
                        writer.WriteValue(message.Message);
                        writer.WriteEndObject();
                    }

                    writer.WriteEndArray();
                    writer.WriteEnd();
                }

                int.TryParse(StatusCode, out statusCode);
                statusCode = statusCode % 400 < 100 ? 400 : 201;
                return sw.ToString();
            }
            catch
            {
            }

            return "";
        }
    }
}
