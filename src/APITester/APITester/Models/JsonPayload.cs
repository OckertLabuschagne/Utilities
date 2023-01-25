using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APITester.Models
{
    public class JsonPayload
    {

        public JsonPayload()
        {
            Properties = new List<JsonPayloadProperty>();
        }

        public JsonPayload(JObject value)
            : this()
        {
            Parse(value);
        }

        public List<JsonPayloadProperty> Properties { get; protected set; }

        public object GetPropertyValue(string propertyName)
        {
            JsonPayloadProperty property;
            if (propertyName.Contains('.'))
            {
                string[] props = propertyName.Split('.');
                property = Properties.Where(p => p.Name == props[0]).FirstOrDefault();
                if (property.Value is JsonPayload)
                    return (property.Value as JsonPayload).GetPropertyValue(propertyName.Replace($"{props[0]}.", ""));
                throw new Exception("Invalid property");
            }
            property = Properties.Where(p => p.Name.ToUpper() == propertyName.ToUpper()).FirstOrDefault();
            return property.Value;
        }

        public void NextValue()
        {
            foreach (JsonPayloadProperty property in Properties)
                property.NextValue();
        }

        public override string ToString()
        {
            StringBuilder retValue = new StringBuilder();
            retValue.AppendLine("{");
            bool isFirst = true;
            foreach (JsonPayloadProperty property in Properties)
            {
                if (isFirst)
                    isFirst = false;
                else
                    retValue.AppendLine(",");
                retValue.Append(property.ToString());
            }
            retValue.Append("\n}");
            return retValue.ToString();
        }

        public void Parse(JObject value)
        {
            foreach (JProperty obj in value.Children())
            {
                Properties.Add(new JsonPayloadProperty(obj));
            }
        }

        public void Parse(string value)
        {
            JObject json = JObject.Parse(value);
            Parse(json);
        }
    }
}
