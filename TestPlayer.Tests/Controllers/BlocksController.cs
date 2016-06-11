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
    }
}
