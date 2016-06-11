using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Entities;

namespace DomainModel.Abstract
{
    public interface ITestsRepository
    {
        IQueryable<Test> Tests { get; }
        Test GetTestByID(int TestID);
        void DeleteTest(int TestID);
    }
}
