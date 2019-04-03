using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo.Models;
using Demo.Interfaces;

namespace Demo.Controllers
{
    public class OrderController : Controller
    {
        private UnitOfWork unitOfWork;

        public OrderController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var shopDbContext = unitOfWork.OrderRepository.GetList();
            return View(shopDbContext);
        }

        public IActionResult Details(int id)
        {
            var order = unitOfWork.OrderRepository.GetList().FirstOrDefault(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            ViewData["PhoneId"] = new SelectList(unitOfWork.PhoneRepository.GetList(), "Id", "Name");
            return View();
        }

        //// POST: Order/Create
        [HttpPost]
        public IActionResult Create(Order order)
        {
            order.Date = DateTime.Now;

            if (ModelState.IsValid)
            {
                unitOfWork.OrderRepository.Create(order);
                unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhoneId"] = new SelectList(unitOfWork.PhoneRepository.GetList(), "Id", "Company", order.PhoneId);
            return View(order);
        }

        public IActionResult Edit(int id)
        {
            Order order = unitOfWork.OrderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["PhoneId"] = new SelectList(unitOfWork.PhoneRepository.GetList(), "Id", "Name", order.PhoneId);

            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(int id, Order order)
        {

            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                unitOfWork.OrderRepository.Update(order);
                unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            ViewData["PhoneId"] = new SelectList(unitOfWork.PhoneRepository.GetList(), "Id", "Name", order.PhoneId);
            return View(order);
        }

        public IActionResult Delete(int id)
        {

            var order = unitOfWork.OrderRepository.GetList().FirstOrDefault(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            unitOfWork.OrderRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
