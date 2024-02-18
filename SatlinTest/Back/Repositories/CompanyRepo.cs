using SatlinTest.Back.Data;
using SatlinTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatlinTest.Back.Repositories
{
    public class CompanyRepo
    {
        BackContext context;

        public CompanyRepo(BackContext Context) { this.context = Context; }

        #region Get
        public Company GetCompany(int id)
        {
            var query = from datos in this.context.Company
                        where datos.id == id
                        select datos;
            return query.FirstOrDefault();
        }
        #endregion
    }
}
