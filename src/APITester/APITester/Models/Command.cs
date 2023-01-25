using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester.Models
{
    public class Command
    {
        public Command()
        {
            Parameters = new Dictionary<string, string>();
            Form = new Dictionary<string, string>();
        }
        public string Name { get; set; }
        public string URL { get; set; }
        public Dictionary<string, string> Parameters { get; }
        public Dictionary<string, string> Form { get; }
        public string Raw { get; set; }
        public ActionType Action { get; set; }
        public string FilePath { get; set; }
        public string UserId { get; set; }
        public string Note { get; set; }

        public JsonPayload JsonPayload { get; set; }

        public Command Clone()
        {
            Command retval = new Command
            {
                Name = $"{Name} (clone)",
                URL = URL,
                Raw = Raw,
                Action = Action,
                FilePath = FilePath,
                UserId = UserId,
                Note = Note
            };
            foreach (string key in Parameters.Keys)
                retval.Parameters.Add(key, Parameters[key]);
            foreach (string key in Form.Keys)
                retval.Form.Add(key, Form[key]);
            return retval;
        }

        public int PayloadSize { get
            {
                int size = 0;
                if(Parameters != null)
                {
                    foreach (string key in Parameters.Keys)
                    {
                        size += key.Length;
                        size++;
                        size += Parameters[key].Length;
                    }
                }
                if(Form != null)
                {
                    foreach(string key in Form.Keys)
                    {
                        size += key.Length;
                        size++;
                        size += Form[key].Length;
                    }
                }
                if (Raw != null)
                    size += Raw.Length;
                return size;
            } }
    }
}
