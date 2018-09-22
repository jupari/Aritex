using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Aritex.Common.Models;
using Aritex.Domain.Models;
using Aritex.API.Models;


namespace Aritex.API.Controllers
{
    public class VentasDiaController : ApiController
    { 
        // GET: api/Titulo_Tela
        public IQueryable<VentasDia> GetVentasDia()
        {
            List<VentasDia> Vd = new List<VentasDia>();
            using (BDAritex bd = new BDAritex())
            {
                var res= bd.Database.SqlQuery<VentasDia>("ListaEmpaque_Consulta_ventas_diario_unoee_sp").ToList();
                Vd = (List<VentasDia>)res;
            }
            var query = Vd.AsQueryable();
            return query;
        }

    }
}
