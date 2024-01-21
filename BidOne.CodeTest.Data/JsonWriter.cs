using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using BidOne.CodeTest.Core;
using BidOne.CodeTest.Core.Entities;

namespace BidOne.CodeTest.Data
{
    public class JsonWriter
    {
        private readonly JsonSerializerSettings _options
        = new() { NullValueHandling = NullValueHandling.Ignore };

        public bool WriteToFile(Person person, string fileName)
        {
            var jsonString = JsonConvert.SerializeObject(person, Formatting.Indented, _options);
            bool isFileempty = true;
            List<Person> source = new List<Person>();

            using (StreamReader r = new StreamReader(fileName))
            {
                var json = r.ReadToEnd();
                if(json.Contains("{"))
                {
                    isFileempty = false;
                }
            }

            if(isFileempty)
            {
                File.AppendAllText(fileName, jsonString);
            }
            else
            {
                File.AppendAllText(fileName, ","+jsonString);
            }
            
            return true;
        }
    }
}
