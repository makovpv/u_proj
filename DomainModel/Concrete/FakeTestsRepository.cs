using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Abstract;
using DomainModel.Entities;

namespace DomainModel.Concrete
{
    public class FakeTestsRepository: ITestsRepository
    {
        private static IQueryable<Test> fakeTests = new List<Test> {
            new Test {id=11, name="test #1", author="me"},
            new Test {id=12, name="test #2", author="he"}
            }.AsQueryable();

        public IQueryable<Test> Tests
        {
            get { return fakeTests; }
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
