using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DomainModel;
using DomainModel.Abstract;
using DomainModel.Concrete;

namespace TestPlayer.Controllers
{
    public class TestsController : Controller
    {
        public int PageSize = 4;
        
        private ITestsRepository testsRepository;
        public TestsController(ITestsRepository testsRepository)
        {
            this.testsRepository = testsRepository;
            
            ///testsRepository = new FakeTestsRepository();

            //временное жесткое строка подключения - до устнаовки IoC
            //string connString = @"Server=home\sqlexpress;Database=tester_data;Trusted_Connection=yes;";
            //testsRepository = new SQLTestsRepository(connString);
        }

        public ViewResult List(string tag, int page)
        {
            var TestsInCategory = (tag == null) ? testsRepository.Tests : testsRepository.Tests.Where(x => x.tags == tag);
            
            int numTests = TestsInCategory.Count();
            ViewData["TotalPages"] = (int)Math.Ceiling((double)numTests / PageSize);
            ViewData["CurrentPage"] = page;
            ViewData["CurrentCategory"] = tag;
            
            return View(TestsInCategory
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList()
                );
        }

        public ViewResult Edit(int id)
        {
            DomainModel.Entities.Test tst = testsRepository.Tests.Where(p => p.id == id).FirstOrDefault();
            return View(tst);
        }

        public ViewResult Play(int id) // SubjectID
        {
            //DomainModel.Entities.Test tst = testsRepository.Tests.Where(p => p.id == id).FirstOrDefault();
            return View(id);
        }

        //[System.Web.Services.WebMethod]
        //public static string AAA(int id)
        //{
        //    return "RRR";
        //}

        public ViewResult Info(int id)
        {
            
            return View();
        }

        public void Create()
        {
        }

        public void GoToBlock()
        {
        }
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Scale()
        {
            return View();
        }

        public ViewResult ForDefaultRoute()
        {
            return View();
        }

        public string Get5(int id)
        {

            DomainModel.Entities.Test tst = testsRepository.Tests.Where(p => p.id == id).FirstOrDefault();


            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            //string ss = js.Serialize(tst);
            return js.Serialize(tst);
        }
        
    }
}
