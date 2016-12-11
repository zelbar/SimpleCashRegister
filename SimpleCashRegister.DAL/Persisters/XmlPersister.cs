using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SimpleCashRegister.DataAccessLayer.Persisters
{
    public class XmlPersister<T> : IPersister<T>
    {
        public XmlPersister(string filename)
        {
            _fileName = filename;
        }

        private readonly string _fileName;
        private List<T> _list;

        public List<T> GetList()
        {
            return _list;
        }

        public void SetList(List<T> list)
        {
            _list = list;
        }

        public void Load()
        {
            if (File.Exists(_fileName))
            {
                lock (_fileName)
                {
                    using (FileStream reader = File.Open(_fileName,
                             FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                        _list = (List<T>)serializer.Deserialize(reader);
                    }
                }
            }
            else
            {
                _list = new List<T>();
                Save();
            }
        }

        public void Save()
        {
            lock (_fileName)
            {
                using (FileStream writer = File.Create(_fileName))
                {
                    XmlSerializer serializer = new XmlSerializer(_list.GetType());
                    serializer.Serialize(writer, _list);
                }
            }
        }
    }
}
