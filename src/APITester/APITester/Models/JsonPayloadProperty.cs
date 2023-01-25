using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace APITester.Models
{
    public class JsonPayloadProperty
    {
        int index = 1;
        public JsonPayloadProperty()
        { }

        public JsonPayloadProperty(JProperty value)
        {
            Parse(value);
        }

        public string Name { get; set; } 
        [JsonIgnore]
        public object Value
        {
            get
            {
                if (ObjectValue != null)
                    return ObjectValue;
                else if (ArrayValue != null)
                    return ArrayValue;
                else
                    return StringValue;
            }
            set
            {
                if (value is JsonPayload)
                    ObjectValue = value as JsonPayload;
                else if (value is Array)
                    ArrayValue = value as JsonPayload[];
                else
                    StringValue = value as string;
            }
        }
        public JsonPayload ObjectValue { get; set; }
        public JsonPayload[]  ArrayValue { get; set; }
        public string StringValue { get; set; }
        public bool Increment { get; set; }
        public string ValueFormat { get; set; }
        public int IncrementValue { get; set; }

        public void NextValue()
        {
            if (Value is JsonPayload)
                (Value as JsonPayload).NextValue();
            else if(Value is Array)
            {
                foreach(var val in (Value as Array))
                    (val as JsonPayload).NextValue();
            }
            else if (Increment)
            {
                {
                    index += IncrementValue;
                    Value = string.Format(ValueFormat, index);
                }
            }
        }

        public void Parse(JProperty value)
        {
            Name = value.Name;
            if (value.Value is JObject)
                Value = new JsonPayload(value.Value as JObject);
            else if (value.Value is JArray)
            {
                List<JsonPayload> values = new List<JsonPayload>();
                foreach (var val in (value.Value as JArray))
                {
                    values.Add(new JsonPayload(val as JObject));
                }
                Value = values.ToArray();
            }
            else
                Value = value.Value.ToString();
        }

        public override string ToString()
        {
            if (Value is JsonPayload)
                return $"\"{Name}\": {Value}";
            else if (Value is Array)
            {
                StringBuilder valString = new StringBuilder();
                valString.Append("[");
                bool isFirst = true;
                foreach(JsonPayload  val in (Value as Array))
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        valString.AppendLine(",");
                    valString.Append(val.ToString());
                }
                valString.Append("]");
                return $"\"{Name}\": {valString}";
            }
            else
                return $"\"{Name}\": \"{Value}\"";
        }
    }
}
