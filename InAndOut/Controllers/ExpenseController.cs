using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
	public class ExpenseController : Controller
	{
		private readonly ApplicationDbContext _db;

		public ExpenseController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			IEnumerable<Expense> obj = _db.Expenses; 
			return View(obj);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Expense obj)
		{
			if (ModelState.IsValid)
			{
				_db.Expenses.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id==0)
			{

				return NotFound();
			}

			//To display the record that we are deleting 
			var obj = _db.Expenses.Find(id);
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
			var obj = _db.Expenses.Find(id);

			if (obj == null)
			{
				return NotFound();
			}

			_db.Expenses.Remove(obj);
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
			var obj = _db.Expenses.Find(id);
			if (obj == null)
			{
				return NotFound();
			}
			return View("getUpdate",obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult postUpdate(Expense obj)
		{
			if (ModelState.IsValid)
			{
				_db.Expenses.Update(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(obj);
		}

	
	}
}
