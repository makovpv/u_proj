using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainModel.Abstract;
using DomainModel.Entities;

namespace TestPlayer.Controllers
{
    public class ScalesController : Controller
    {
        //
        // GET: /Scales/

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Index(int? idTest)
        {
            return View();
        }

        private IScalesRepository scalesRepository;
        public ScalesController(IScalesRepository scalesRepository)
        {
            this.scalesRepository = scalesRepository;
            
            ///testsRepository = new FakeTestsRepository();

            //временное жесткое строка подключения - до устнаовки IoC
            //string connString = @"Server=home\sqlexpress;Database=tester_data;Trusted_Connection=yes;";
            //testsRepository = new SQLTestsRepository(connString);
        }

        //public ViewResult List(int? id)
        public ViewResult List(int id)
        {
            var TestScales = scalesRepository.Scales.Where(p=> p.test_id == id);
            return View(TestScales);
        }

        public ViewResult Edit(int id)
        {
            Scale sc = scalesRepository.Scales.Where(p => p.Id == id).FirstOrDefault();
            return View(sc);
        }
        
        
        public RedirectToRouteResult Save(Scale qq)
        {
            scalesRepository.SaveToDB(qq);
            return RedirectToAction("List", new { id = qq.test_id });
        }

        //public ViewResult List()
        //{
        //    return View();
        //}

    }
}
