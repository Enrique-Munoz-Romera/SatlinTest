using SatlinTest.Back.Data;
using SatlinTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatlinTest.Back.Repositories
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
