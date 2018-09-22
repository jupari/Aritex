namespace Aritex.Domain.Models
{
    using System.Data.Entity;

    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<Aritex.Common.Models.Titulo_Tela> Titulo_Tela { get; set; }

        public System.Data.Entity.DbSet<Aritex.Common.Models.VentasDia> VentasDias { get; set; }
    }
}
