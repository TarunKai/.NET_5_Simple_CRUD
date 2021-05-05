using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
	public class ExpenseTypeController : Controller
	{
		private readonly ApplicationDbContext _db;

		public ExpenseTypeController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			IEnumerable<expenseCategory> obj = _db.expenseCategories;
			return View(obj);
		}

		public IActionResult expenseCtgry()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult expenseCtgry(expenseCategory obj)
		{
			if (ModelState.IsValid)
			{
				_db.expenseCategories.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{

				return NotFound();
			}

			//To display the record that we are deleting 
			var obj = _db.expenseCategories.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]

		public IActionResult DeletePose(int? id)
		{
			var obj = _db.expenseCategories.Find(id);

			if (obj == null)
			{
				return NotFound();
			}

			_db.expenseCategories.Remove(obj);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult getUpdate(int? id)
		{
			if (id == null || id == 0)
			{

				return NotFound();
			}

			//To display the record that we are updating 
			var obj = _db.expenseCategories.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			return View("getUpdate", obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult postUpdate(expenseCategory obj)
		{
			if (ModelState.IsValid)
			{
				_db.expenseCategories.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}
	}
}
