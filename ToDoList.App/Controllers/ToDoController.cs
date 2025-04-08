using Microsoft.AspNetCore.Mvc;
using ToDoList.App.Data;
using ToDoList.App.Models;
namespace ToDoList.App.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext doContext;

        public ToDoController(ToDoContext doContext)
        {
            this.doContext = doContext;
            
        }
        public IActionResult Index()
        {
            var toDoList = doContext.Tasks.ToList();
            return View(toDoList);
        }
        public IActionResult Create(int? id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,Priority,TaskDescription,IsCompleted")]ToDoTask task)
        {
            if (ModelState.IsValid)
            {       
                task.IsCompleted = false;
                doContext.Add(task);
                doContext.SaveChanges();
                return RedirectToAction(nameof(Index)); 
            }
            return View(task);
        }

        
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var toDoTask = doContext.Tasks.Find(id);
            if (toDoTask == null)
            {
                return NotFound();
            }
            return View(toDoTask);
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id,Priority,TaskDescription,IsCompleted")]ToDoTask task)
        {
          
            if (ModelState.IsValid)
            {
                doContext.Tasks.Update(task);
                doContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }
    }
}
