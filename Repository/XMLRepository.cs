using SerializeXmlManipulation.Application_Class;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;
using System.Diagnostics;

namespace SerializeXmlManipulation.Repository
{
    public class XMLRepository<TEntity> : IXMLRepository<TEntity> where TEntity : class
    {

        private readonly string _fileName;
        private readonly TEntity entity;
        List<TEntity> list;
        private XmlDocument Data;
        private XmlSerializer _serializer;
       


        public XMLRepository(string filename)
        {
            try
            {
                _fileName = filename;
                _serializer = new XmlSerializer(typeof(List<TEntity>));
                FileInfo fInfo = new FileInfo(_fileName);
                if (fInfo.Exists)
                {
                    using (FileStream myWriter = File.OpenRead(_fileName))
                    {
                        list = (List<TEntity>)_serializer.Deserialize(myWriter);
                        myWriter.Close();
                    }
                }
                else
                {
                    list = Activator.CreateInstance<List<TEntity>>();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }

        public IEnumerable<TEntity> All()
        {
            var currentList = list as List<TEntity>;
            return currentList;
        }

        public void Insert(TEntity entity)
        {
            var currentList = list as List<TEntity>;
            currentList.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            
            var currentList = list as List<TEntity>;                        
            currentList.Remove(entity); 
         }

        public void SaveChanges()
        {            
            using (StreamWriter myWriter = new StreamWriter(_fileName))
            {
                _serializer.Serialize(myWriter, list);
                myWriter.Close();
            }
        }

        public void Dispose()
        {
            if (_serializer != null)
            {
                _serializer = null;
            }
        }
    }
}