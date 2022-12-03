using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopInDBFirstDataAccessLayer.Models;

namespace ShopInDBFirstDataAccessLayer
{
    public class ShopInRepository
    {
        ShopInDbContext context;
        public ShopInRepository()
        {
            context = new ShopInDbContext();

        }

        public List<Category> GetAllCategories()
        {
            List<Category> categoriesList = (from category in context.Categories
                                             orderby category.CategoryId
                                             select category).ToList();
            return categoriesList;
        }

        public List<Product> GetAllProducts()
        {
            List<Product> productList = null;
            try
            {
                productList = context.Products.OrderByDescending(p => p.Rating).ToList();
            }
            catch (Exception ex)
            {
                productList = null;
            }
            return productList;
        }
        public Product GetProductDetailsById(String PId)
        {
            Product productList = null;
            try
            {
                productList = context.Products.Find(PId);
            }
            catch (Exception ex)
            {
                productList = null;
            }
            return productList;
        }
        public List<Product> GetProductsByCategoryId(int CId)
        {
            List<Product> productList = null;
            try
            {
                productList = context.Products.Where(p => p.CategoryId == CId).ToList();
            }
            catch (Exception ex)
            {
                productList = null;
            }
            return productList;
        }
        public List<Order> GetAllOrdersByUserId(int UId)
        {
            List<Order> orderList = null;
            try
            {
                orderList = context.Orders.Where(o => o.UserId == UId).ToList();
            }
            catch (Exception ex)
            {
                orderList = null;
            }
            return orderList;
        }



        public bool AddCategory(string categoryName)
        {
            bool status = false;
            Category category = new Category();
            category.CategoryName = categoryName;
            try
            {
                context.Categories.Add(category);
                //context.Add<Categories>(category);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public bool AddProducts(Product products)
        {
            bool status = false;
            try
            {
                products.ProductId = ShopInDbContext.GenerateNewProductId();
            
                context.Products.Add(products);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public bool AddUsers(User users)
        {
            bool status = false;
            try
            {
                context.Users.Add(users);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public bool CheckUser(string Email, string Password)
        {
            bool status = false;
            User ob=null;
            try
            {
                ob = context.Users.Where(p => p.UserEmail.Equals(Email) && p.UserPassword.Equals(Password)).FirstOrDefault();
                if (ob == null)
                    status = false;
                else
                    status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public bool AddOrder(Order ob)
        {
            bool status = false;
            try
            {
                context.Orders.Add(ob);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {

                status = false;
            }
            return status;
        }

    }
}
