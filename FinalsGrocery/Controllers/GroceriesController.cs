using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using FinalsGrocery.Models;

namespace FinalsGrocery.Controllers
{
    public class GroceriesController : ApiController
    {
        static readonly IGroceryRepository repo = new GroceryRepository();
        public IEnumerable<Grocery> GetAllGroceries()
        {
            return repo.GetAll();
        }
        public Grocery GetGrocery(int id)
        {
            Grocery item = repo.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
        public IEnumerable<Grocery> GetGroceriesByCategory(string category)
        {
            return repo.GetAll().Where(
                p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }
        public HttpResponseMessage PostGrocery(Grocery item)
        {
            item = repo.Add(item);
            var response = Request.CreateResponse<Grocery>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
        public void PutGrocery(int id, Grocery grocery)
        {
            grocery.Id = id;
            if (!repo.Update(grocery))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        public void DeleteGrocery(int id)
        {
            Grocery item = repo.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repo.Remove(id);
        }
    }
}

