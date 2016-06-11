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
    public class BlocksController : Controller
    {


        private IBlocksRepository blocksRepository;
        public BlocksController(IBlocksRepository blocksRepository)
        {
            this.blocksRepository = blocksRepository;
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ViewResult List(int TestID)
        public ViewResult List()
        { 
            //var TestBlock = blocksRepository.Blocks.Where(x=> x.test_id == TestID);
           //return View(TestBlock);

            return View();
            //return View(blocksRepository.Blocks.ToList());
        }

        public System.Web.Mvc.ViewResult Index()
        {
            return View();
        }

    }
}
