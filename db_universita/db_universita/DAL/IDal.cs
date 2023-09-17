using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_universita.DAL
{
    internal interface IDal<T>
    {
        public List<T> findAll();
        public T? findById(int id);
        public bool insert(T t);
        public bool update(T t);
        public bool delete(int id);
    }
}
