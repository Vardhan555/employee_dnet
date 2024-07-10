using System;
using employee.Data;
using employee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace employee.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly ApplicationDbContext _context;
		public EmployeeController(ApplicationDbContext context)
		{
			_context = context;
		}
		//GET: /<controller>/
		public IActionResult Index()
		{
			var employees = _context.Employees.ToList();
			return View(employees);
		}
		public IActionResult Create()
		{
            ViewData["GenderList"] = new SelectList(new List<string> { "Male", "Female", "Other" });
            return View();
        }

		[HttpPost]
		public IActionResult Create(Employee employee)
		{
			if (ModelState.IsValid)
			{
				
				_context.Employees.Add(employee);
				_context.SaveChanges();
				return RedirectToAction("Index");
            }
            ViewData["GenderList"] = new SelectList(new List<string> { "Male", "Female", "Other" });
            return View();
		}

		public IActionResult Edit(int id)
		{
			var item = _context.Employees.Find(id);
			if(item == null)
			{
				return NotFound();
			}
            ViewData["GenderList"] = new SelectList(new List<string> { "Male", "Female", "Other" });
            return View(item);
		}
		[HttpPost]
		public IActionResult Edit(int id, Employee emp)
		{
			if(id != emp.id)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				_context.Update(emp);
				_context.SaveChanges();
			}
            ViewData["GenderList"] = new SelectList(new List<string> { "Male", "Female", "Other" });
            return View(emp);
		}

		public IActionResult Delete(int id)
		{
            var item = _context.Employees.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["GenderList"] = new SelectList(new List<string> { "Male", "Female", "Other" });
            return View(item);
        }
		[HttpPost]
		public IActionResult Delete(int id,Employee employee)
		{
			if(employee == null)
			{
				return NotFound();
			}
			if (ModelState.IsValid)
			{
				_context.Employees.Remove(employee);
				_context.SaveChanges();
			}
            ViewData["GenderList"] = new SelectList(new List<string> { "Male", "Female", "Other" });

            return RedirectToAction(nameof(Index));
		}
	}
}

