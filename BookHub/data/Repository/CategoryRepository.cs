using BookHub.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookHub.data.Repository
{
    public class CategoryRepository
    {
        public List<Category> GetAllCategories()
        {
            using (var context = new AppContext())
            {
                return context.Set<Category>().ToList();
            }
        }
    }
}