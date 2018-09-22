namespace Aritex.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class VentasDia
    {
        [Key]       
        public string  CO { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
    }
}
