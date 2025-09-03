using Console_App_Project.Modles.Base;
using Console_App_Project.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Project.Repository
{
    internal class Repository <T> where T : BaseEntity
    {
        //Generic Method to Serialize any type of object to JSON and save to file
        public  void SerializeJson(string path,List<T> items)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(JsonConvert.SerializeObject(items, Formatting.Indented));
            }
        }

        //Generic Method to Load or Create List from JSON file
        public  List<T> LoadOrCreateListFromJson(string path)
        {

            string result = Helper.ReadJson(path);

            if (string.IsNullOrEmpty(result))
            {
                return new List<T>();
            }

            else
            {
                var list = JsonConvert.DeserializeObject<List<T>>(result);

                if (list == null)
                    list = new List<T>();

                return list;
            }
        }

    }
}
