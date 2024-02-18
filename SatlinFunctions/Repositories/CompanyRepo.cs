using SatlinFunctions.Back.Data;
using SatlinFunctions.Models;
using System.Linq;

namespace SatlinFunctions.Back.Repositories
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
