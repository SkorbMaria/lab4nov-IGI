using IGI_5.Models;
using IGI_5.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace IGI_5.Controllers
{
    public class HomeController : Controller
    {
        Repository repository;
        int pageSize = 3;

        public HomeController(ApplicationContext context)
        {
            repository = new Repository(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Autor(int page = 1, string sort = null)
        {
            var model = repository.GetAutors();
            var count = model.Count();
            if (sort != null) HttpContext.Session.SetString("AutorSort", sort);
            else sort = HttpContext.Session.GetString("AutorSort");
            switch (sort)
            {
                case "ID": model = model.OrderBy(x => x.ID); break;
                case "About": model = model.OrderBy(x => x.About); break;
            }
            model = model.Skip(pageSize * (page - 1)).Take(pageSize);
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ViewBag.PageViewModel = pageViewModel;
            return View(model);
        }
        public IActionResult Book(int page = 1, string sort = null, int filter = 0)
        {
            var model = repository.GetBooks();
            if (filter > 0) HttpContext.Session.SetInt32("BookFilter", filter);
            else filter = HttpContext.Session.GetInt32("BookFilter") ?? 0;
            model = model.Where(x => x.Price > filter);
            var count = model.Count();
            if (sort != null) HttpContext.Session.SetString("BookSort", sort);
            else sort = HttpContext.Session.GetString("BookSort");
            switch (sort)
            {
                case "ID": model = model.OrderBy(x => x.ID); break;
                case "Name": model = model.OrderBy(x => x.Name); break;
                case "Cypher": model = model.OrderBy(x => x.Cypher); break;
                case "Date": model = model.OrderBy(x => x.Date); break;
                case "Price": model = model.OrderBy(x => x.Price); break;
                case "Sell": model = model.OrderBy(x => x.Sell); break;
                case "Fee": model = model.OrderBy(x => x.Fee); break;
            }
            model = model.Skip(pageSize * (page - 1)).Take(pageSize);
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ViewBag.PageViewModel = pageViewModel;
            return View(model);
        }
        public IActionResult Customer(int page = 1, string sort = null)
        {
            var model = repository.GetCustomers();
            var count = model.Count();
            if (sort != null) HttpContext.Session.SetString("CustomerSort", sort);
            else sort = HttpContext.Session.GetString("CustomerSort");
            switch (sort)
            {
                case "ID": model = model.OrderBy(x => x.ID); break;
                case "Name": model = model.OrderBy(x => x.Name); break;
                case "About": model = model.OrderBy(x => x.About); break;
            }
            model = model.Skip(pageSize * (page - 1)).Take(pageSize);
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ViewBag.PageViewModel = pageViewModel;
            return View(model);
        }
        public IActionResult Contract(int page = 1, string sort = null)
        {
            var model = repository.GetContracts();
            var count = model.Count();

            if (sort != null) HttpContext.Session.SetString("ContractSort", sort);
            else sort = HttpContext.Session.GetString("ContractSort");

            switch (sort)
            {
                case "ID": model = model.OrderBy(x => x.ID); break;
                case "DateStart": model = model.OrderBy(x => x.DateStart); break;
                case "Term": model = model.OrderBy(x => x.Term); break;
                case "DateEnd": model = model.OrderBy(x => x.DateEnd); break;
                case "Book": model = model.OrderBy(x => x.Book.Name); break;
                case "Autor": model = model.OrderBy(x => x.Autor.About); break;
            }

            model = model.Skip(pageSize * (page - 1)).Take(pageSize);
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ViewBag.PageViewModel = pageViewModel;


            return View(model);
        }
        public IActionResult Order(int page = 1, string sort = null)
        {
            var model = repository.GetOrders();
            var count = model.Count();

            if (sort != null) HttpContext.Session.SetString("OrderSort", sort);
            else sort = HttpContext.Session.GetString("OrderSort");

            switch (sort)
            {
                case "ID": model = model.OrderBy(x => x.ID); break;
                case "RecieveDate": model = model.OrderBy(x => x.RecieveDate); break;
                case "CompleteDate": model = model.OrderBy(x => x.CompleteDate); break;
                case "Count": model = model.OrderBy(x => x.Count); break;
                case "Customer": model = model.OrderBy(x => x.Customer.Name); break;
                case "Book": model = model.OrderBy(x => x.Book.Name); break;
            }

            model = model.Skip(pageSize * (page - 1)).Take(pageSize);
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ViewBag.PageViewModel = pageViewModel;


            return View(model);
        }
    }
}