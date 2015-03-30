using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeXmlManipulation.Repository
{
    public interface IXMLRepository<TEntity> : IDisposable
    {       
        IEnumerable<TEntity> All();
        void Insert(TEntity entity);
        void Remove(TEntity entity);
        void SaveChanges();
        
    }
}
