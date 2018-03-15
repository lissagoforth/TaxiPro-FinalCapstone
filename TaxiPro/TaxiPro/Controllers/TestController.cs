using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Videos, Questions and corresponding options
        public IActionResult GetQuestionSet(int id)
        {
            IQueryable<Question> tq = _context.Question.Where(q => q.TestTypeId == id);
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
                Videos = unique
            };
            return View(tsvm);
        }

        // GET: Test/VideoView
        public IActionResult VideoView()
        {
            GetQuestionSet(2);
            return View();
        }
    }
}