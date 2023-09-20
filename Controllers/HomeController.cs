using Anbar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.IO;

namespace Anbar.Controllers
{
    public class HomeController : Controller
    {
        private Data.MyContext _myContext;

        public HomeController(Data.MyContext mydb)
        {
            _myContext = mydb;
        }
        public IActionResult Index()
        {
            IEnumerable<Models.Item> items = _myContext.Items.ToList();
            Download.ToDownload.RemoveText();
            foreach (Models.Item x in _myContext.Items)
            {
                if (x.Id != 1)
                {
                    var f = new Download.ToDownload(x.Name, x.Price, x.Description);
                }
            }
            Download.ToDownload.IfEmpty();
            return View(items);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Privacy(Item item)
        {
            if (ModelState.IsValid)
            {
                _myContext.Add(item);
                _myContext.SaveChanges();
            }

            return View();
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var item = _myContext.Items.FirstOrDefault(x => x.Id == id);
            return View(item);
        }
        public IActionResult DeleteById(int id)
        {
            var myitem = _myContext.Items.Find(id);
            if (myitem == null)
            {
                return RedirectToAction("Index");
            }
            _myContext.Items.Remove(myitem);
            _myContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                Item itemtoedit = _myContext.Items.SingleOrDefault(current => current.Id == item.Id);
                if (itemtoedit == null)
                    return RedirectToAction("Index");
                itemtoedit.Name = item.Name;
                itemtoedit.Description = item.Description;
                itemtoedit.Price = item.Price;
                _myContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("GetById", new { id = item.Id });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}