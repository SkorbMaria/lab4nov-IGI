using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGI_5.Models;
using IGI_5.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace IGI_5.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class UserController : Controller
    {
        Repository repository;
                     
        public UserController(ApplicationContext context)
        {
            repository = new Repository(context);
        }

        [HttpGet]
        public ActionResult AddAutor()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddContract()
        {
            ViewBag.Books = repository.GetBooks();
            ViewBag.Autors = repository.GetAutors();
            return View();
        }
        [HttpGet]
        public ActionResult AddOrder()
        {
            ViewBag.Books = repository.GetBooks();
            ViewBag.Customers = repository.GetCustomers();
            return View();
        }


        [HttpGet]
        public ActionResult EditAutor(int id)
        {
            var model = repository.GetAutors().FirstOrDefault(x => x.ID == id);
            return View(model);
        }
        [HttpGet]
        public ActionResult EditBook(int id)
        {
            var model = repository.GetBooks().FirstOrDefault(x => x.ID == id);
            return View(model);
        }
        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            var model = repository.GetCustomers().FirstOrDefault(x => x.ID == id);
            return View(model);
        }
        [HttpGet]
        public ActionResult EditContract(int id)
        {
            var model = repository.GetContracts().FirstOrDefault(x => x.ID == id);
            ViewBag.Books = repository.GetBooks();
            ViewBag.Autors = repository.GetAutors();
            return View(model);
        }
        [HttpGet]
        public ActionResult EditOrder(int id)
        {
            var model = repository.GetOrders().FirstOrDefault(x => x.ID == id);
            ViewBag.Books = repository.GetBooks();
            ViewBag.Customers = repository.GetCustomers();
            return View(model);
        }


        [HttpGet]
        public ActionResult RemoveAutor(int id)
        {
            var model = repository.GetAutors().FirstOrDefault(x => x.ID == id);
            return View(model);
        }
        [HttpGet]
        public ActionResult RemoveBook(int id)
        {
            var model = repository.GetBooks().FirstOrDefault(x => x.ID == id);
            return View(model);
        }
        [HttpGet]
        public ActionResult RemoveCustomer(int id)
        {
            var model = repository.GetCustomers().FirstOrDefault(x => x.ID == id);
            return View(model);
        }
        [HttpGet]
        public ActionResult RemoveContract(int id)
        {
            var model = repository.GetContracts().FirstOrDefault(x => x.ID == id);
            return View(model);
        }
        [HttpGet]
        public ActionResult RemoveOrder(int id)
        {
            var model = repository.GetOrders().FirstOrDefault(x => x.ID == id);
            return View(model);
        }



        [HttpPost]
        public ActionResult AddAutor(Autor autor)
        {
            if (ModelState.IsValid)
            {
                repository.AddAutor(autor);
                return RedirectToAction("Autor", "Home");
            }
            return View(autor);
        }
        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.AddBook(book);
                return RedirectToAction("Book", "Home");
            }
            return View(book);
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                repository.AddCustomer(customer);
                return RedirectToAction("Customer", "Home");
            }
            return View(customer);
        }
        [HttpPost]
        public ActionResult AddContract(Contract order, string bookName, string autorName)
        {
            if (ModelState.IsValid)
            {
                order.Book = repository.GetBookByName(bookName);
                order.Autor = repository.GetAutorByName(autorName);
                repository.AddContract(order);
                return RedirectToAction("Contract", "Home");
            }
            ViewBag.Books = repository.GetBooks();
            ViewBag.Customers = repository.GetCustomers();
            ViewBag.Autors = repository.GetAutors();
            return View(order);
        }
        [HttpPost]
        public ActionResult AddOrder(Order order, string bookName, string customerName)
        {
            if (ModelState.IsValid)
            {
                order.Book = repository.GetBookByName(bookName);
                order.Customer = repository.GetCustomerByName(customerName);
                repository.AddOrder(order);
                return RedirectToAction("Order", "Home");
            }
            ViewBag.Books = repository.GetBooks();
            ViewBag.Customers = repository.GetCustomers();
            ViewBag.Autors = repository.GetAutors();
            return View(order);
        }


        [HttpPost]
        public ActionResult EditAutor(Autor autor)
        {
            if (ModelState.IsValid)
            {
                repository.EditAutor(autor);
                return RedirectToAction("Autor", "Home");
            }
            return View(autor);
        }
        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.EditBook(book);
                return RedirectToAction("Book", "Home");
            }
            return View(book);
        }
        [HttpPost]
        public ActionResult EditCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                repository.EditCustomer(customer);
                return RedirectToAction("Customer", "Home");
            }
            return View(customer);
        }
        [HttpPost]
        public ActionResult EditContract(Contract order, string autorName, string bookName)
        {
            if (ModelState.IsValid)
            {
                order.Autor = repository.GetAutorByName(autorName);
                order.Book = repository.GetBookByName(bookName);
                repository.EditContract(order);
                ViewBag.Books = repository.GetBooks();
                ViewBag.Customers = repository.GetCustomers();
                return RedirectToAction("Contract", "Home");
            }
            return View(order);
        }
        [HttpPost]
        public ActionResult EditOrder(Order order, string customerName, string bookName)
        {
            if (ModelState.IsValid)
            {
                order.Customer = repository.GetCustomerByName(customerName);
                order.Book = repository.GetBookByName(bookName);
                repository.EditOrder(order);
                ViewBag.Books = repository.GetBooks();
                ViewBag.Customers = repository.GetCustomers();
                return RedirectToAction("Order", "Home");
            }
            return View(order);
        }


        [HttpPost]
        public ActionResult RemoveAutors(int id)
        {
            repository.RemoveAutor(id);
            return RedirectToAction("Autor", "Home");
        }
        [HttpPost]
        public ActionResult RemoveBooks(int id)
        {
            repository.RemoveBook(id);
            return RedirectToAction("Book", "Home");
        }
        [HttpPost]
        public ActionResult RemoveCustomers(int id)
        {
            repository.RemoveCustomer(id);
            return RedirectToAction("Customer", "Home");
        }
        [HttpPost]
        public ActionResult RemoveContracts(int id)
        {
            repository.RemoveContract(id);
            return RedirectToAction("Contract", "Home");
        }
        [HttpPost]
        public ActionResult RemoveOrders(int id)
        {
            repository.RemoveOrder(id);
            return RedirectToAction("Order", "Home");
        }
    }
}