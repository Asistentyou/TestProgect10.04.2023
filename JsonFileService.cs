using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace MVVC
{
    internal class JsonFileService : IFileService
    {
        public List<Blyda> Open(string filename)
        {
            List<Blyda> phones = new List<Blyda>();
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(List<Blyda>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                phones = jsonFormatter.ReadObject(fs) as List<Blyda>;
            }

            return phones;
        }

        public void Save(string filename, List<Blyda> phonesList)
        {
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(List<Blyda>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, phonesList);
            }
        }
    }
}
