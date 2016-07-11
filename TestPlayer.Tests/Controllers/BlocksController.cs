using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DomainModel.Abstract;
using DomainModel.Entities;

namespace TestPlayer.Tests.Controllers
{
    [TestFixture]
    class BlocksController
    {
        static IBlocksRepository MockBlocksRepository(params Block[] blocks)
        {
            var mockBlocksRepos = new Moq.Mock<IBlocksRepository>();
            mockBlocksRepos.Setup(x => x.Blocks).Returns(blocks.AsQueryable());
            return mockBlocksRepos.Object;
        }

        [Test]
        public void test1()
        {

            IBlocksRepository rep = MockBlocksRepository(new Block() {text="2222" });



            Assert.AreEqual(10, 10);
            Assert.AreEqual(3, 3);
            
            //IBlocksRepository rep = new MockBlocksRepository(null);


                //new Block() {comment="Ком к блоку" },
                //new Block() { comment = "Ком к блоку 2" }
                //);
            

        }

        [Test]
        public void test2()
        {
        }
    }
}
