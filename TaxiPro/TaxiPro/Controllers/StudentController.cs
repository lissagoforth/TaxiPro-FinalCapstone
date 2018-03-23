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
        public async Task<IActionResult> Details(int? studentId)
        {
            {
                var spvm = new StudentProfileViewModel()
                {
                    Student = _context.Student.Where(s => s.Id == studentId).SingleOrDefault(),
                    Events = _context.Event.Include("User").Where(e => e.StudentId == studentId).ToList(),
                    Results = new List<CourseViewModel>(),
            };


                foreach (var evt in spvm.Events)
                {
                    if (evt.EventTypeId == 2)
                    {
                        var bank = new List<StudentAnswer>();

                        bank = _context.StudentAnswer.Include(sa => sa.Option).ThenInclude(o => o.Question).Where(sa => sa.EventId == evt.Id).ToList();

                        if (bank.Count != 0)
                        {
                            spvm.Result = new CourseViewModel()
                            {
                                DateTime = evt.DateTime
                            };
                            spvm.Result.MapsTest = new TestResultViewModel();
                            spvm.Result.MapsTest.Answers = new List<StudentAnswer>();
                            spvm.Result.MapsTest.EventId = evt.Id;
                            spvm.Result.MapsTest.User = evt.User;
                            spvm.Result.MapsTest.Student = spvm.Student;

                            spvm.Result.OrdinancesTest = new TestResultViewModel();
                            spvm.Result.OrdinancesTest.Answers = new List<StudentAnswer>();
                            spvm.Result.OrdinancesTest.EventId = evt.Id;
                            spvm.Result.OrdinancesTest.User = evt.User;
                            spvm.Result.OrdinancesTest.Student = spvm.Student;

                            foreach(var a in bank)
                            {
                                if (a.Option.Question.TestTypeId == 2)
                                {
                                    spvm.Result.MapsTest.Answers.Add(a);
                                }
                                if (a.Option.Question.TestTypeId == 1)
                                {
                                    spvm.Result.OrdinancesTest.Answers.Add(a);
                                }

                            }
                            spvm.Result.MapsTest.Correct = GradeTest(spvm.Result.MapsTest);

                            spvm.Result.OrdinancesTest.Correct = GradeTest(spvm.Result.OrdinancesTest);
                            spvm.Results.Add(spvm.Result);
                        }

                    }
                }

                if (studentId == null)
                {
                    return NotFound();
                }

                var student = await _context.Student
                    .SingleOrDefaultAsync(m => m.Id == studentId);
                if (student == null)
                {
                    return NotFound();
                }

                return View(spvm);
            }
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
        public async Task<IActionResult> AddTest(TestViewModel testViewModel, int eventId)
        {
            var student = testViewModel.StudentId;

            var user = await _userManager.GetUserAsync(User);

            var tvm = new TestViewModel()
            {
                OptionIds = testViewModel.OptionIds,
                StudentId = student,
                User = user,
                TestTypeId = testViewModel.TestTypeId
            };

            foreach(var opt in tvm.OptionIds)
            {
                var sa = new StudentAnswer()
                {
                    StudentId = student,
                    OptionId = opt,
                    EventId = eventId
                };
                _context.StudentAnswer.Add(sa);
                await _context.SaveChangesAsync();
            }

            if (testViewModel.TestTypeId == 2)
            {
                return RedirectToAction("GetVideo", new {i = 0, test = 2, studentId = student, eventId = testViewModel.EventId});
            }

            return RedirectToAction("CourseComplete", new { studentId = student});
        }

        // GET: Students/AddEvent/5
        public async Task<IActionResult> GetEvent(int? studentId)
        {
            var spvm = new StudentProfileViewModel()
            {
                Student = _context.Student.Where(s => s.Id == studentId).SingleOrDefault(),
                Events = _context.Event.Where(e => e.StudentId == studentId).ToList()
            };

            var cvm = new CourseViewModel();

            foreach(var evt in spvm.Events)
            {
                if (evt.EventTypeId == 2)
                {
                    var tr = new TestResultViewModel()
                    {
                        Answers = _context.StudentAnswer.Where(sa => sa.EventId == evt.Id).ToList(),
                        Student = spvm.Student,
                        User = await _userManager.FindByIdAsync(evt.User.Id),
                        EventId = evt.Id,
                    };

                    int correct = GradeTest(tr);
                    tr.Correct = correct;

                    if (tr.Answers.SingleOrDefault().Option.Question.TestTypeId == 2)
                    {
                        cvm.MapsTest = tr;
                    }
                    else if(tr.Answers.SingleOrDefault().Option.Question.TestTypeId == 1)
                    {
                        cvm.OrdinancesTest = tr;
                    }   
                }
            }
            spvm.Results = new List<CourseViewModel>();
            spvm.Results.Add(cvm);

            if (studentId == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .SingleOrDefaultAsync(m => m.Id == studentId);
            if (student == null)
            {
                return NotFound();
            }

            return View(spvm);
        }

        // POST: Students/AddEvent/5
       // [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEvent(Event evnt)
        {
            
            if (evnt.EventTypeId == 2)
            {
                var evt = new Event()
                {
                    StudentId = evnt.StudentId,
                    User = await _userManager.GetUserAsync(User),
                    EventTypeId = evnt.EventTypeId
                };

                _context.Event.Add(evt);
                await _context.SaveChangesAsync();
                return RedirectToAction("StartMessageView", new { studentId = evnt.StudentId, eventId = evt.Id });
            }

            if(evnt.EventTypeId == 1)
            {
                var evt = new Event()
                {
                    StudentId = evnt.StudentId,
                    User = await _userManager.GetUserAsync(User),
                    EventTypeId = evnt.EventTypeId,
                    Content = evnt.Content
                };

                _context.Event.Add(evt);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { studentId = evnt.StudentId });
            }
            return RedirectToAction("Details", new { studentId = evnt.StudentId});
        }

        public IActionResult StartMessageView(int studentId, int eventId)
        {
            var student = new Student();
            student = _context.Student.Where(s => s.Id == studentId).SingleOrDefault();
       
            return View(student);
        }

        // GET: Videos
        public IActionResult GetVideo(int i, int test, int studentId, int eventId)
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
                    Student = student,
                    EventId = eventId
                };

                return View(T1vv);
            } else if (test == 2)
            {
                var T2vids = tv.Where(v => v.URL.Contains("Ordinance")).ToList();
                var T2vv = new VideoViewModel()
                {
                    URL = T2vids[i].URL,
                    Name = T2vids[i].Name,
                    Order = T2vids[i].Order,
                    Student = student,
                    EventId = eventId
                };

                return View(T2vv);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Student/TestView
        public async Task<IActionResult> GetTest(int testTypeId, int studentId, int eventId)
        {
            List<Question> tq = _context.Question.Where(q => q.TestTypeId == testTypeId).ToList();
            List<Option> to = new List<Option>();
            
                for(int i = 0; i < tq.Count(); i++)
                {
                var options = _context.Option.Where(o => o.QuestionId == tq[i].Id).ToList();
                    foreach (var opt in options)
                    {
                        to.Add(opt);
                    }
                }


            var tsvm = new TestSetViewModel();

            tsvm.Questions = tq;
            tsvm.Options = to;
            tsvm.Student = _context.Student.Where(s => s.Id == studentId).SingleOrDefault();
            tsvm.User = await _userManager.GetUserAsync(User);
            tsvm.EventId = eventId;
            tsvm.TestTypeId = testTypeId;

            return View(tsvm);
        }        
        
        // GET: Student/TestResultDetailView
        public async Task<IActionResult> TestDetail(int testTypeId, int studentId, int eventId)
        {
            var tq = _context.Question.Include("TestType").Where(q => q.TestTypeId == testTypeId).ToList();

            var ta = _context.StudentAnswer.Include(sa => sa.Option).ThenInclude(o => o.Question).Where(sa => sa.EventId == eventId && sa.Option.Question.TestTypeId == testTypeId).ToList();

            var to = _context.Option.Include("Question").Where(o => o.Question.TestTypeId == testTypeId).ToList();

            var trvm = new TestResultViewModel();

            trvm.Questions = tq;
            trvm.Options = to;
            trvm.Answers = ta;
            trvm.Student = _context.Student.Where(s => s.Id == studentId).SingleOrDefault();
            trvm.User = await _userManager.GetUserAsync(User);
            trvm.EventId = eventId;

            return View(trvm);
        }

        public int GradeTest(TestResultViewModel trvm)
        {
            int correct = 0;

            foreach(var a in trvm.Answers)
            {
                if(a.Option.IsCorrect == true)
                {
                    correct++;
                }
            }
            trvm.Correct = correct;
            return correct;
        }

        // GET: Students/Create
        public IActionResult CourseComplete(int studentId)
        {
            var student = new Student();
            student = _context.Student.Where(s => s.Id == studentId).SingleOrDefault();

            return View(student);
        }
    }
}
