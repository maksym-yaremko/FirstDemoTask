using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo.Models;

namespace Demo.Controllers
{
    public class PhoneController : Controller
    {
        private UnitOfWork unitOfWork;

        public PhoneController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // GET: Phone
        public IActionResult Index()
        {
            var shopDbContext =unitOfWork.PhoneRepository.GetList();
            return View(shopDbContext);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Phone phone)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.PhoneRepository.Create(phone);
                unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(phone);
        }

        public IActionResult Edit(int id)
        {
            var phone = unitOfWork.PhoneRepository.GetById(id);
            if (phone == null)
            {
                return NotFound();
            }
            return View(phone);
        }

        [HttpPost]
        public IActionResult Edit(int id,Phone phone)
        {
            if (id != phone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    unitOfWork.PhoneRepository.Update(phone);
                    unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(phone);
        }

        public IActionResult Delete(int id)
        {

            var phone = unitOfWork.PhoneRepository.GetList().FirstOrDefault(m => m.Id == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            unitOfWork.PhoneRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var order = unitOfWork.PhoneRepository.GetList().FirstOrDefault(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
    }
}
