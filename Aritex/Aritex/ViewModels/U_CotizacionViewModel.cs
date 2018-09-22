namespace Aritex.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Common.Models;
    using GalaSoft.MvvmLight.Command;
    using Services;
    using Xamarin.Forms;
    using Views;
    using System.Linq;

    public class U_CotizacionViewModel: BaseViewModel
    {
        #region Atributos
        private ApiService apiService;
        private ObservableCollection<Titulo_Tela> u_Cotizacion;
        private List<Titulo_Tela> myList;
        private ParametrosCotizacion parametrosCotizacion;
        private bool isEnabled;
        private bool isEnabledTC;
        private string genero;
        private string tipoPrenda;
        private string tipoCuello;
        private string tituloTela;
        private decimal costoHilaza;
        private decimal costoTejeduria;
        private decimal resCotizar;

        #endregion
        #region Propiedades
        public ParametrosCotizacion ParametrosCotizacion
        {
            get { return this.parametrosCotizacion; }
            set { this.SetValue(ref this.parametrosCotizacion, value); }
        }
        public List<Titulo_Tela> MyList
        {
            get { return this.myList; }
            set { this.SetValue(ref this.myList, value); }
        }

        public ObservableCollection<Titulo_Tela> U_Cotizacion
        {
            get { return this.u_Cotizacion; }
            set { this.SetValue(ref this.u_Cotizacion, value); }
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { this.SetValue(ref this.isEnabled, value); }
        }
        public bool IsEnabledTC
        {
            get { return this.isEnabledTC; }
            set { this.SetValue(ref this.isEnabledTC, value); }
        }
        public string Genero
        {
            get { return this.genero; }
            set { this.SetValue(ref this.genero, value); }
        }
        public string TipoPrenda
        {
            get { return this.tipoPrenda; }
            set { this.SetValue(ref this.tipoPrenda, value); }
        }
        public string TipoCuello
        {
            get { return this.tipoCuello; }
            set { this.SetValue(ref this.tipoCuello, value); }
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
        #region Constructor
        public U_CotizacionViewModel()
        {
            this.apiService = new ApiService();
            this.LoadTitulos();
            this.IsEnabledTC = false;
        }
        #endregion
        #region Commands
        public ICommand SelCamisetaComand
        {
            get
            {
                return new RelayCommand(SelCamiseta);
            }
        }

        private void SelCamiseta()
        {
            this.TipoPrenda = "Tipo Camiseta";
            this.IsEnabled = false;
            this.IsEnabledTC = true;
        }

        public ICommand SelPoloComand
        {
            get
            {
                return new RelayCommand(SelPolo);
            }

        }

        private void SelPolo()
        {
            this.TipoPrenda = "Tipo Polo";
            this.IsEnabled = false;
            this.IsEnabledTC = false;
        }

        public ICommand CotizarCommand
        {
            get
            {
                return new RelayCommand(Cotizar);
            }
        }

        private async void Cotizar()
        {
            if (string.IsNullOrEmpty(this.Genero))
            {
                await Application.Current.MainPage.DisplayAlert(
                            "Error",
                            "Debe escoger el Genero",
                            "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.TituloTela))
            {
                await Application.Current.MainPage.DisplayAlert(
                            "Error",
                            "Debe escoger un titulo de tela",
                            "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.TituloTela))
            {
                this.TipoPrenda = "No aplica";
                return;
            }


            if (this.CostoHilaza<0)
            {
                await Application.Current.MainPage.DisplayAlert(
                            "Error",
                            "El costo de la hilaza debe ser mayor a 0",
                            "Aceptar");
                return;
            }
            if (this.CostoTejeduria < 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                            "Error",
                            "El costo de la tejeduria debe ser mayor a 0",
                            "Aceptar");
                return;
            }

            this.MyList =(List<Titulo_Tela>)this.U_Cotizacion.Where(p => p.Descripcion.ToLower().Contains(this.TituloTela.ToLower())).ToList();

            if (this.MyList != null || this.MyList.Count >0)
            {
                var res = this.MyList.Where(p => p.Genero.ToLower().Contains(this.Genero.ToLower())).ToList();
                if (res == null || res.Count == 0)
                {
                    await Application.Current.MainPage.DisplayAlert(
                                "Error",
                                "El titulo "+ this.TituloTela + "no tiene el genero " + this.Genero,
                                "Aceptar");
                    return;
                }
                var respxk = res.Select(p=>p.PxK).FirstOrDefault();
                var pxk = decimal.Parse(respxk.ToString());

                if (this.TipoPrenda == "Tipo Camiseta")
                {
                    this.ParametrosCotizacion = new ParametrosCotizacion
                    {
                        Genero = this.genero,
                        TipoPrenda = this.TipoPrenda,
                        TipoCuello = this.TipoCuello,
                        TituloTela = this.TituloTela,
                        CostoHilaza = this.CostoHilaza,
                        CostoTejeduria = this.CostoTejeduria,
                        ResCotizar = (this.CostoHilaza + CostoTejeduria) * pxk,
                        Imagen = "camiseta",
                    };
                }
                else
                {
                    this.ParametrosCotizacion = new ParametrosCotizacion
                    {
                        Genero = this.genero,
                        TipoPrenda = this.TipoPrenda,
                        TipoCuello = this.TipoCuello,
                        TituloTela = this.TituloTela,
                        CostoHilaza = this.CostoHilaza,
                        CostoTejeduria = this.CostoTejeduria,
                        ResCotizar = (this.CostoHilaza + CostoTejeduria) * pxk,
                        Imagen = "polo",
                    };
                }

            }

            MainViewModel.GetInstance().U_ResultadoCotizacion = new U_ResultadoCotizacionViewModel(ParametrosCotizacion);
            await Application.Current.MainPage.Navigation.PushAsync(new U_ResultadoCotizacion());
        }

        public ICommand CancelarCommand
        {
            get
            {
                return new RelayCommand(Cancelar);
            }
        }

        private async void Cancelar()
        {
            MainViewModel.GetInstance().U_Cotizacion = new U_CotizacionViewModel();
            await App.Navigator.PushAsync(new U_CotizacionPage());
        }
        #endregion
        #region Metodos
        private async void LoadTitulos()
        {
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                     connection.Message,
                    "Aceptar"
                    );
                return;
            }
            //var url = Application.Current.Resources["UrlAPI"].ToString();
            //var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            //var controller = Application.Current.Resources["UrlController"].ToString();
            //var response = await apiService.GetList<Titulo_Tela>(url,prefix,controller);
            var response = await apiService.GetList<Titulo_Tela>("http://181.48.119.100:3058","/api" , "/titulo_tela");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Aceptar");
                return;
            }

            var list = (List<Titulo_Tela>)response.Result;
            this.U_Cotizacion = new ObservableCollection<Titulo_Tela>(list);
        }
        #endregion
    }
}
