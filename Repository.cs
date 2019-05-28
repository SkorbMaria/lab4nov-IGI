using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI_5.Models
{
    public class Repository
    {
        ApplicationContext context;

        public Repository(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Autor> GetAutors()
        {
            return context.Autors;
        }
        public IEnumerable<Book> GetBooks()
        {
            return context.Books;
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return context.Customers;
        }
        public IEnumerable<Contract> GetContracts()
        {
            return context.Contracts.Include("Book").Include("Autor");
        }
        public IEnumerable<Order> GetOrders()
        {
            return context.Orders.Include("Book").Include("Customer");
        }

        public Autor GetAutorByName(string about)
        {
            return context.Autors.FirstOrDefault(x => x.About == about);
        }
        public Book GetBookByName(string name)
        {
            return context.Books.FirstOrDefault(x => x.Name == name);
        }
        public Customer GetCustomerByName(string name)
        {
            return context.Customers.FirstOrDefault(x => x.Name == name);
        }

        public void AddAutor(Autor furniture)
        {
            context.Autors.Add(furniture);
            context.SaveChanges();
        }
        public void AddBook(Book furniture)
        {
            context.Books.Add(furniture);
            context.SaveChanges();
        }
        public void AddCustomer(Customer furniture)
        {
            context.Customers.Add(furniture);
            context.SaveChanges();
        }
        public void AddContract(Contract order)
        {
            context.Contracts.Add(order);
            context.SaveChanges();
        }
        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void EditAutor(Autor furniture)
        {
            context.Entry(furniture).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void EditBook(Book furniture)
        {
            context.Entry(furniture).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void EditCustomer(Customer furniture)
        {
            context.Entry(furniture).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void EditContract(Contract order)
        {
            context.Entry(order).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void EditOrder(Order order)
        {
            context.Entry(order).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void RemoveAutor(int id)
        {
            context.Autors.Remove(context.Autors.Find(id));
            context.SaveChanges();
        }
        public void RemoveBook(int id)
        {
            context.Books.Remove(context.Books.Find(id));
            context.SaveChanges();
        }
        public void RemoveCustomer(int id)
        {
            context.Customers.Remove(context.Customers.Find(id));
            context.SaveChanges();
        }
        public void RemoveContract(int id)
        {
            context.Contracts.Remove(context.Contracts.Find(id));
            context.SaveChanges();
        }
        public void RemoveOrder(int id)
        {
            context.Orders.Remove(context.Orders.Find(id));
            context.SaveChanges();
        }
    }
}
