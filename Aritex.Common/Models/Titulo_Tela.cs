namespace Aritex.Common.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Titulo_Tela
    {
        [Key]
        public int IdTitulo { get; set; }

        [Required]
        public string Descripcion { get; set; }

        public string Genero { get; set; }

        public string Tipo_Cuello { get; set; }

        public double Peso { get; set; }

        public double Factor { get; set; }

        public double Consumo { get; set; }

        public double PxK { get; set; }

        public bool Activo { get; set; }

    }
}
