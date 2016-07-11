using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Abstract;
using DomainModel.Entities;
using System.Data.Linq;

namespace DomainModel.Concrete
{
    public class SQLBlocksRepository: IBlocksRepository
    {
        private Table<Block> blocksTable;
        public SQLBlocksRepository(string ConnectionString)
        {
            blocksTable = (new DataContext(ConnectionString)).GetTable<Block>();
        }

        public IQueryable<Block> Blocks
        {
            get { return blocksTable; }
        }

        public Block GetBlockByID(int BlockID)
        {
            return null; // wtf
        }
    }
}
