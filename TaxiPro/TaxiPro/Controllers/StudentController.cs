 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaxiPro.Data;
using TaxiPro.Models;
using TaxiPro.Models.ViewModels;

namespace TaxiPro.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Students
        public async Task<IActionResult> Index(string searchString)
        {

            var students = from s in _context.Student select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString) || s.Address.Contains(searchString) || s.Phone.Contains(searchString));

                return View(await students.ToListAsync());
            }

            return View(await _context.Student.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .SingleOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,City,State,Zip,Phone")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.SingleOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,City,State,Zip,Phone")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .SingleOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.SingleOrDefaultAsync(m => m.Id == id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }

        // POST: Students/AddAnswer/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAnswer(int id, int optionId)
        {
            var sa = new StudentAnswer()
            {
                StudentId = id,
                OptionId = optionId
            };
            _context.StudentAnswer.Add(sa);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // POST: Students/AddAnswer/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTest(TestViewModel testViewModel, int test)
        {
            var student = testViewModel.StudentId;

            var user = await _userManager.GetUserAsync(User);

            var tvm = new TestViewModel()
            {
                OptionIds = testViewModel.OptionIds,
                StudentId = student,
                User = user
            };

            foreach(var opt in tvm.OptionIds)
            {
                var sa = new StudentAnswer()
                {
                    StudentId = student,
                    OptionId = opt
                };
                _context.StudentAnswer.Add(sa);
                await _context.SaveChangesAsync();
            }

            if (test == 1)
            {
                return RedirectToAction("GetVideo", new {i = 0, test = 2, studentId = student});
            }

            return View();
        }

        // GET: Students/AddEvent/5
        public async Task<IActionResult> AddEvent(int? id)
        {
            var spvm = new StudentProfileViewModel();
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .SingleOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/AddEvent/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEvent(int id, Event evt)
        {
            var evnt = new Event()
            {
                StudentId = id,
                User = await _userManager.GetUserAsync(User),
                DateTime = evt.DateTime,
                Content = evt.Content
            };
            _context.Event.Add(evnt);
            await _context.SaveChangesAsync();
            return View();
        }

        public IActionResult StartMessageView(int id)
        {
            var student = new Student();
            student = _context.Student.Where(s => s.Id == id).SingleOrDefault();
       
            return View(student);
        }

        // GET: Videos
        public IActionResult GetVideo(int i, int test, int studentId)
        {
            List<Video> tv = _context.Video.ToList();
            var student = _context.Student.Where(s => s.Id == studentId).SingleOrDefault();
            if (test == 1)
            {
                // grab all videos with a URL that contains "Navigation"
                var T1vids = tv.Where(v => v.URL.Contains("Navigation")).ToList();
                var T1vv = new VideoViewModel()
                {
                    URL = T1vids[i].URL,
                    Name = T1vids[i].Name,
                    Order = T1vids[i].Order,
                    Student = student
                };
                //if(i == 5)
                //{
                //    await GetTest(1, student.Id);
                //}

                return View(T1vv);
            } else if (test == 2)
            {
                var T2vids = tv.Where(v => v.URL.Contains("Ordinance")).ToList();
                var T2vv = new VideoViewModel()
                {
                    URL = T2vids[i].URL,
                    Name = T2vids[i].Name,
                    Order = T2vids[i].Order,
                    Student = student
                };

                return View(T2vv);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Student/TestView
        public async Task<IActionResult> GetTest(int testTypeId, int studentId)
        {
            List<Question> tq = _context.Question.Where(q => q.TestTypeId == testTypeId).ToList();
            List<Option> to = new List<Option>();

            foreach (var item in tq)
            {
                var options = _context.Option.Where(o => o.QuestionId == item.Id);
                foreach(var opt in options)
                {
                    to.Add(opt); 
                }
            }

            var tsvm = new TestSetViewModel();

            tsvm.Questions = tq;
            tsvm.Options = to;
            tsvm.Student = _context.Student.Where(s => s.Id == studentId).SingleOrDefault();
            tsvm.User = await _userManager.GetUserAsync(User);

            return View(tsvm);
        }
    }
}
