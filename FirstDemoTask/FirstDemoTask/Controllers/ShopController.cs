using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstDemoTask.Models;

namespace FirstDemoTask.Controllers
{
    public class ShopController : Controller
    {
        //UnitOfWork unitOfWork;
        //public ShopController()
        //{
        //    unitOfWork = new UnitOfWork();
        //}

        //public ActionResult Index()
        //{
        //    var phones = unitOfWork.Orders.GetAll();
        //    return View(phones);
        //}

        //public IActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var order = unitOfWork.Orders
        //        .GetAll()
        //        .FirstOrDefault(m => m.OrderId == id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(order);
        //}

        //public IActionResult Create()
        //{
        //    ViewData["PhoneId"] = new SelectList(unitOfWork.Phones.GetAll(), "Id", "Name");
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        unitOfWork.Orders.Create(order);
        //        unitOfWork.Save();
        //        return RedirectToAction("Index");
        //    }
        //    return View(order);
        //}

        //public IActionResult Edit(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var order = unitOfWork.Orders.Get(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["PhoneId"] = new SelectList(unitOfWork.Phones.GetAll(), "Id", "Company", order.PhoneId);
        //    return View(order);
        //}

        //// POST: Shop/Edit/5
        //[HttpPost]
        //public IActionResult Edit(int id, Order order)
        //{
        //    if (id != order.OrderId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {

        //        unitOfWork.Orders.Update(order);
        //        unitOfWork.Save();

        //    }
        //    return RedirectToAction("Index");
        //    ViewData["PhoneId"] = new SelectList(_context.Phones, "Id", "Company", order.PhoneId);
        //    return View(order);
        //}

        //GET: Shop/Delete/5
        //public IActionResult Delete(int? id)
        //{
        //    ViewBag.Id = id;

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var order = unitOfWork.Orders
        //        .GetAll()
        //        .FirstOrDefault(m => m.OrderId == id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(order);
        //}

        //POST: Shop/Delete/5
        //[HttpPost]
        //[ActionName("Delete")]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    unitOfWork.Orders.Delete(id);
        //    unitOfWork.Save();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    unitOfWork.Dispose();
        //    base.Dispose(disposing);
        //}
        private readonly MobileContext _context;

        public ShopController(MobileContext context)
        {
            _context = context;
        }

        // GET: Shop
        public async Task<IActionResult> Index()
        {
            var mobileContext = _context.Orders.Include(o => o.Phone);
            return View(await mobileContext.ToListAsync());
        }

        // GET: Shop/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Phone)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Shop/Create
        public IActionResult Create()
        {
            ViewData["PhoneId"] = new SelectList(_context.Phones, "Id", "Name");
            return View();
        }

        // POST: Shop/Create
        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            order.date = DateTime.Now;
            _context.Add(order);
            await _context.SaveChangesAsync();

            return Redirect("/Shop/Index");
        }

        // GET: Shop/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            //if (order == null)
            //{
            //    return NotFound();
            //}
            ViewData["PhoneId"] = new SelectList(_context.Phones, "Id", "Company", order.PhoneId);
            return View(order);
        }

        // POST: Shop/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _context.Update(order);
                await _context.SaveChangesAsync();

            }

            return RedirectToAction(nameof(Index));

            //ViewData["PhoneId"] = new SelectList(_context.Phones, "Id", "Company", order.PhoneId);
            //return View(order);
        }

        // GET: Shop/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.Id = id;

            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Phone)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Shop/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return Redirect("/Shop/Index");
        }
    }
}
