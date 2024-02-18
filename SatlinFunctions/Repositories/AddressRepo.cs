using SatlinFunctions.Back.Data;
using SatlinFunctions.Models;
using System.Linq;

namespace SatlinFunctions.Back.Repositories
{
    public class AddressRepo
    {
        BackContext context;

        public AddressRepo(BackContext Context) { this.context = Context; }

        #region Get
        public Address GetAddress(int id)
        {
            var query = from datos in this.context.Address
                        where datos.id == id
                        select datos;
            return query.FirstOrDefault();
        }
        #endregion
    }
}
