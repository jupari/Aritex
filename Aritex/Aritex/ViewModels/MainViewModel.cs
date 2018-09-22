namespace Aritex.ViewModels
{
    using Views;
    public class MainViewModel
    {
        #region Propiedades
        public U_CotizacionViewModel U_Cotizacion { get; set; }
        public U_ResultadoCotizacionViewModel U_ResultadoCotizacion { get; set; }
        public ContenidoViewModel Contenido { get; set; }
        public LoginViewModel Login { get; set; }
        #endregion
        #region Constructores
        public MainViewModel()
        {
            instance = this;
            //this.U_Cotizacion = new U_CotizacionViewModel();
            this.Contenido = new ContenidoViewModel();
        }
        #endregion
        #region Commandos

        #endregion
        #region Metodos

        #endregion
        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}
