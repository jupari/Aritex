namespace Aritex.ViewModels
{
    using Aritex.Common.Models;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;

    public class U_ResultadoCotizacionViewModel:BaseViewModel
    {
        #region Atributos
        private ParametrosCotizacion parametrosCotizacion;
        private string genero;
        private string tipoCuello;
        private string tituloTela;
        private string tipoPrenda;
        private decimal costoHilaza;
        private decimal costoTejeduria;
        private decimal resCotizar;
        #endregion
        #region Propiedades
        private ParametrosCotizacion ParametrosCotizacion
        {
            get { return this.parametrosCotizacion; }
            set { this.SetValue(ref this.parametrosCotizacion, value); }
        }
        public string Genero
        {
            get { return this.genero; }
            set { this.SetValue(ref this.genero, value); }
        }
        public string TipoCuello
        {
            get { return this.tipoCuello; }
            set { this.SetValue(ref this.tipoCuello, value); }
        }

        public string TipoPrenda
        {
            get { return this.tipoPrenda; }
            set { this.SetValue(ref this.tipoPrenda, value); }
        }

        public string TituloTela
        {
            get { return this.tituloTela; }
            set { this.SetValue(ref this.tituloTela, value); }
        }

        public decimal CostoHilaza
        {
            get { return this.costoHilaza; }
            set { this.SetValue(ref this.costoHilaza, value); }
        }
        public decimal CostoTejeduria
        {
            get { return this.costoTejeduria; }
            set { this.SetValue(ref this.costoTejeduria, value); }
        }
        public decimal ResCotizar
        {
            get { return this.resCotizar; }
            set { this.SetValue(ref this.resCotizar, value); }
        }
        #endregion
        #region Constructores
        public U_ResultadoCotizacionViewModel(ParametrosCotizacion parametrosCotizacion)
        {
            this.ParametrosCotizacion = parametrosCotizacion;
        }
        #endregion
        #region Metodos

        #endregion
        #region Commands
        public ICommand VolverCotizarCommand
        {
            get
            {
                return new RelayCommand(VolverCotizar);
            }
        }

        private void VolverCotizar()
        {
   
        }
        #endregion
    }
}
