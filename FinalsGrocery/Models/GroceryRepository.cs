using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalsGrocery.Models
{
    public class GroceryRepository : IGroceryRepository
    {
        private List<Grocery> groceries = new List<Grocery>();
        private int _nextId = 1;

        public GroceryRepository()
        {
            Add(new Grocery { Name = "Chicken", Category = "Meat", Price = 1000 });
            Add(new Grocery { Name = "Comb", Category = "Toiletries", Price = 20 });
            Add(new Grocery { Name = "Broom", Category = "Cleaning Equipment", Price = 500 });
        }

        public IEnumerable<Grocery> GetAll()
        {
            return groceries;
        }

        public Grocery Get(int id)
        {
            return groceries.Find(p => p.Id == id);
        }

        public Grocery Add(Grocery item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            groceries.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            groceries.RemoveAll(p => p.Id == id);
        }

        public bool Update(Grocery item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = groceries.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            groceries.RemoveAt(index);
            groceries.Add(item);
            return true;
        }
    }
}