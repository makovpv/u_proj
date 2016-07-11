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
    class ScalesControllerTest
    {
        [Test]
        public void testForList()
        {
            IScalesRepository rep = MockScalesRepository(
                new Scale() { name = "Первая шкала", Id = 10, test_id = 1 },
                new Scale() { name = "Вторая шкала", Id = 20, test_id = 1 },
                new Scale() { name = "Вторая шкала", Id = 30, test_id = 2 }
                );
            ScalesController scl_contr = new ScalesController(rep);

            var aa = scl_contr.List(1);
            var my_scales = (IQueryable<Scale>)aa.Model;
            Assert.AreEqual(my_scales.Count(), 2);

            aa = scl_contr.List(3);
            my_scales = (IQueryable<Scale>)aa.Model;
            Assert.AreEqual(my_scales.Count(), 0);
        }

        static IScalesRepository MockScalesRepository(params Scale[] scales)
        {
            var mockScaleRepos = new Moq.Mock<IScalesRepository>();
            mockScaleRepos.Setup(x => x.Scales).Returns(scales.AsQueryable());
            return mockScaleRepos.Object;
        }
    }
}
