using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Abstract;
using System.Data.Linq;
using DomainModel.Entities;

namespace DomainModel.Concrete
{
    public class SQLTestsRepository: ITestsRepository
    {
        private Table<Test> testsTable;
        public SQLTestsRepository(string ConnectionString)
        {
            testsTable = (new DataContext(ConnectionString)).GetTable<Test>();
        }

        public IQueryable<Test> Tests
        {
            get { return testsTable; }
        }


        public Test GetTestByID(int TestID)
        {
            throw new NotImplementedException();
        }

        public void DeleteTest(int TestID)
        {
            throw new NotImplementedException();
        }
    }
}
