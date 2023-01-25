using System;
using System.Collections.Generic;
using System.Windows.Markup;
using SEFI.Encryption;
namespace IDEncryptDecrypt
{
    class Program
    {
        static Dictionary<string, string> _Parameters;
        static void Main(string[] args)
        {
            ParseArguments(args);
            if(_Parameters.ContainsKey("E"))
            {
                int intVal;
                if (int.TryParse(_Parameters["E"], out intVal))
                    Console.WriteLine(KeyGenerator.EncryptKey((int?)intVal));
                else
                    Console.WriteLine($"\"{_Parameters["E"]}\" ins not a valid integer.");
            }
            if(_Parameters.ContainsKey("ENCRYPT"))
            {
                int intVal;
                if (int.TryParse(_Parameters["ENCRYPT"], out intVal))
                    Console.WriteLine(KeyGenerator.EncryptKey((int?)intVal));
                else
                    Console.WriteLine($"\"{_Parameters["ENCRYPT"]}\" ins not a valid integer.");
            }
            if (_Parameters.ContainsKey("D"))
                    Console.WriteLine(KeyGenerator.DecryptKey(_Parameters["D"]));
            if (_Parameters.ContainsKey("DECRYPT"))
                Console.WriteLine(KeyGenerator.DecryptKey(_Parameters["DECRYPT"]));
            Console.ReadLine();
        }

        static void ParseArguments(string[] args)
        {
            _Parameters = new Dictionary<string, string>();
            foreach(string arg in args)
            {
                string[] parts = arg.Split('=');
                _Parameters.Add(parts[0].ToUpper(), parts.Length > 1 ? parts[1] : "True");
            }
        }
    }
}
