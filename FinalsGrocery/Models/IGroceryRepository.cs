using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalsGrocery.Models
{
    public interface IGroceryRepository
    {
        IEnumerable<Grocery> GetAll();
        Grocery Get(int id);
        Grocery Add(Grocery item);
        void Remove(int id);
        bool Update(Grocery item);
    }
}
