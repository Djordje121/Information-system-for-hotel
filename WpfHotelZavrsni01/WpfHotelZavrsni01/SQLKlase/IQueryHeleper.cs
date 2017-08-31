using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfHotelZavrsni01
{
    interface IQueryHeleper<T>
    {
        List<T> ReturnSelect();     
        bool InsertInto(T obj);
        bool Update(T obj);
        bool Delete(T obj);

    }
}
