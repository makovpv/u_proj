using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Entities;

namespace DomainModel.Abstract
{
    public interface IScalesRepository
    {
        IQueryable<Scale> Scales { get; }
        IQueryable<ScoreCalcType> ScoreCalcTypes {get;}

        void SaveToDB(Scale qq);
    }
}
