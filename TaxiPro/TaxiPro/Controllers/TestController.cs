using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaxiPro.Data;
using TaxiPro.Models;
using TaxiPro.Models.ViewModels;

namespace TaxiPro.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TestController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //public IActionResult StartMessageView(int id)
        //{
           // return View();
        //}

        // GET: Videos, Questions and corresponding options
        public async Task<IActionResult> GetTest(int testTypeId, int studentId)
        {
            IQueryable<Question> tq = _context.Question.Where(q => q.TestTypeId == testTypeId);
            IQueryable<Option> to = null;
            List<Video> tv = new List<Video>();

            foreach (var item in tq)
            {
                to = _context.Option.Where(o => o.QuestionId == item.Id);
                tv.Add(_context.Video.Single(v => v.Id == item.VideoId));
            }

            var unique = tv.Distinct().OrderBy(v => v.Order).ToList();

            var tsvm = new TestSetViewModel()
            {
                Questions = tq,
                Options = to,
                Videos = unique,
                User = await _userManager.GetUserAsync(User),
                Student = _context.Student.Where(s => s.Id == studentId).SingleOrDefault()
            };
            return View(tsvm);
        }

        // GET: Test/VideoView
        public IActionResult VideoView()
        {
            //GetQuestionSet();
            return View();
        }

        // GET: Test/TestView
        public IActionResult TestView()
        {
            var qsvm = new QuestionSetViewModel();
            //GetQuestionSet();

            return View(qsvm);
        }
    }
}