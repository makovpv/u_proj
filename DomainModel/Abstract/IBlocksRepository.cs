using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Entities;

namespace DomainModel.Abstract
{
    public interface IBlocksRepository
    {
        IQueryable<Block> Blocks { get; }
        Block GetBlockByID(int BlockID);
    }
}
