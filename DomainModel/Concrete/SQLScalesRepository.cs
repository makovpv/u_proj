using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Abstract;
using System.Data.Linq;
using DomainModel.Entities;

namespace DomainModel.Concrete
{
    public class SQLScalesRepository: IScalesRepository
    {

        public IQueryable<Scale> Scales
        {
            get { return scaleTable; }
        }

        private Table<Scale> scaleTable;
        public SQLScalesRepository(string ConnectionString)
        {
            scaleTable = (new DataContext(ConnectionString)).GetTable<Scale>();
        }

        public void SaveToDB (Scale pScale)
        {
            if (pScale.Id == 0)
                scaleTable.InsertOnSubmit(pScale);
            else
            {
                scaleTable.Attach(pScale);
                scaleTable.Context.Refresh(RefreshMode.KeepCurrentValues, pScale);
            }
            scaleTable.Context.SubmitChanges();
        }

    }
}
