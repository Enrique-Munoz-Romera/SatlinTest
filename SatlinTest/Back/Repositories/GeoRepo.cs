using SatlinTest.Back.Data;
using SatlinTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SatlinTest.Back.Repositories
{
    public class GeoRepo
    {
        BackContext context;

        public GeoRepo(BackContext Context) { this.context = Context;  }

        #region Get
        public Geo GetGeo(int id)
        {
            var query = from datos in this.context.Geo
                        where datos.id == id
                        select datos;
            return query.FirstOrDefault();
        }
        #endregion
    }
}
