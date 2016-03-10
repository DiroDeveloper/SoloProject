using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EntityClassLibrary
{
    public class DatabaseMethods
    {
        private ProjectEntities _context;
        
        public DatabaseMethods(ProjectEntities context)
        {
            _context = context;
        }

        public Category AddCategory(int categoryId, string categoryName)
        {
            var category = _context.Categories.Add(new Category { CategoryId = categoryId, CategoryName = categoryName });
            _context.SaveChanges();

            return category;
        }

        public List<Category> GetAllCategory()
        {
            var query = from c in _context.Categories
                        orderby c.CategoryName
                        select c;

            return query.ToList();
        }

        public async Task<List<Category>> GetAllCategoryAsync()
        {
            var query = from c in _context.Categories
                        orderby c.CategoryName
                        select c;

            return await query.ToListAsync();
        }

        public Employee AddEmployee(string userName, string password)
        {
            var employee = _context.Employees.Add(new Employee { UserName = userName, Password = password });
            _context.SaveChanges();

            return employee;
        }

      
    }
}
