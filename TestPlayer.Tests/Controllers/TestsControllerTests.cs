using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DomainModel.Abstract;
using DomainModel.Entities;
using TestPlayer.Controllers;

namespace TestPlayer.Tests.Controllers
{
    [TestFixture]
    class TestsControllerTests
    {
        [Test]
        public void List_Presents_Correct_Page_Of_Tests()
        {
            ITestsRepository repository = MockTestsRepository(
                new Test { name = "T1" }, new Test { name = "T2" }, new Test { name = "T3" }, new Test { name = "T4" }, new Test { name = "T5" }
                );
            TestsController controller = new TestsController(repository);
            controller.PageSize = 3;

            var result = controller.List(null, 2);
            Assert.IsNotNull(result, "Didn't render view");
            var tests = result.ViewData.Model as IList<Test>;
            Assert.AreEqual(2, tests.Count, "Got wrong number of tests");

            Assert.AreEqual(2, (int)result.ViewData["CurrentPage"], "wrong page number");
            Assert.AreEqual(2, (int)result.ViewData["TotalPages"], "wrong page count");

            Assert.AreEqual("T4", tests[0].name);
            Assert.AreEqual("T5", tests[1].name);
        }
        [Test]
        public void List_Includes_All_Categories_When_Its_NULL()
        {
            ITestsRepository rep = MockTestsRepository(
                new Test { name = "T1", tags = "AA" }, new Test { name = "T2", tags = "BB" }
                );
            TestsController contr = new TestsController(rep);
            contr.PageSize = 3;
            
            var res = contr.List(null, 1);
            Assert.IsNotNull(res, "Didn't render view");

            var mytests = (IList<Test>)res.Model;
            Assert.AreEqual (mytests.Count, 2, "неверное кол-во элементов");
            Assert.AreEqual("T1", mytests[0].name);
            Assert.AreEqual("T2", mytests[1].name);
        }
        [Test]
        public void List_Filtered_By_Category_When_Requested()
        {
            ITestsRepository rep = MockTestsRepository(
                new Test { name = "T1", tags = "AA" }, new Test { name = "T2", tags = "BB" }, new Test { name="T3", tags="BB"}
                );
            TestsController contr = new TestsController(rep);
            contr.PageSize = 3;

            var res = contr.List("AA", 1);
            Assert.IsNotNull(res, "Didn't render view");

            var mytests = (IList<Test>)res.Model;
            Assert.AreEqual(mytests.Count, 1, "неверное кол-во элементов");
            
            Assert.AreEqual("T1", mytests[0].name);
            Assert.AreEqual("T2", mytests[1].name);

            Assert.AreEqual("BB", res.ViewData["CurrentCategory"]);
        }

        static ITestsRepository MockTestsRepository(params Test[] tests)
        { 
            var mockTestsRepos = new Moq.Mock<ITestsRepository>();
            mockTestsRepos.Setup(x=> x.Tests).Returns(tests.AsQueryable());
            return mockTestsRepos.Object;
        }
    }
}
