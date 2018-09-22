namespace Aritex.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using Aritex.Services;
    using Microcharts;
    using Views;
    using Common.Models;
    using datachar = Microcharts.Entry;
    using SkiaSharp;
    using Mvvmicro;
    using System.Collections.Generic;
    using Xamarin.Forms;
    using System.Linq;

    public class ContenidoViewModel : BaseViewModel
    {
        #region Atributos
        private ApiService apiService;
        private ObservableCollection<VentasDia> ventasDia;
        private string co;
        private decimal valor;
        private Chart graficoVentas;
        private float valor001;
        private float valor002;
        private float valor003;
        private float valor004;
        private float valor008;
        private float valor009;
        private float valor019;
        private float valor025;
        private static readonly SKColor AccentColor = SKColor.Parse("#2C5DF9");
        private static readonly SKColor AccentDarkColor = SKColor.Parse("#484F64");
        private static readonly SKColor OrangeColor = SKColor.Parse("#FFD45F");
        private static readonly SKColor GreenColor = SKColor.Parse("#26C3AC");
        private static readonly SKColor PinkColor = SKColor.Parse("#FA6978");
        private static readonly SKColor AzulColor = SKColor.Parse("#2E2EFE");
        private static readonly SKColor VerdeColor = SKColor.Parse("#5FE103");
        private static readonly SKColor NavyColor = SKColor.Parse("#3D72BE");
        private static readonly SKColor FucsiaColor = SKColor.Parse("#E638D5");
        private static readonly SKColor RojoColor = SKColor.Parse("#E60658");
        #endregion
        #region Propiedades
        public ObservableCollection<VentasDia> VentasDia
        {
            get { return this.ventasDia; }
            set { this.SetValue(ref this.ventasDia, value); }
        }
        public string CO
        {
            get { return this.co; }
            set { this.SetValue(ref this.co, value); }
        }
        public decimal Valor
        {
            get { return this.valor; }
            set { this.SetValue(ref this.valor, value); }
        }
        public Chart GraficoVentas
        {
            get { return this.graficoVentas; }
            set { this.SetValue(ref this.graficoVentas, value); }
        }
        public  float Valor001
        {
            get { return this.valor001; }
            set { this.SetValue(ref this.valor001, value); }
        }
        public float Valor002
        {
            get { return this.valor002; }
            set { this.SetValue(ref this.valor002, value); }
        }
        public float Valor003
        {
            get { return this.valor003; }
            set { this.SetValue(ref this.valor003, value); }
        }
        public float Valor004
        {
            get { return this.valor004; }
            set { this.SetValue(ref this.valor004, value); }
        }
        public float Valor008
        {
            get { return this.valor008; }
            set { this.SetValue(ref this.valor008, value); }
        }
        public float Valor009
        {
            get { return this.valor009; }
            set { this.SetValue(ref this.valor009, value); }
        }
        public float Valor019
        {
            get { return this.valor019; }
            set { this.SetValue(ref this.valor019, value); }
        }
        public float Valor025
        {
            get { return this.valor025; }
            set { this.SetValue(ref this.valor025, value); }
        }
        public SKColor ColNacional =>NavyColor;
        public SKColor ColCEDICALI => AccentColor;
        public SKColor ColCEDIMEDELLIN => VerdeColor;
        public SKColor ColLA70 => GreenColor;
        public SKColor ColBQUILLA => PinkColor;
        public SKColor ColREMATE => OrangeColor;
        public SKColor ColINSTITUCIONAL => AzulColor;
        public SKColor ColSALOMIA => FucsiaColor;


        #endregion
        #region Constructores
        public ContenidoViewModel()
        {
            this.apiService = new ApiService();
            this.LoadDatosVentas();

        }
        #endregion
        #region metodos
         private async void LoadDatosVentas()
        {
            try
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
                var response = await apiService.GetList<VentasDia>("http://181.48.119.100:3058", "/api", "/ventasdia");

                if (!response.IsSuccess)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Error",
                        response.Message,
                        "Aceptar"
                        );
                    return;
                }
                var list = (List<VentasDia>)response.Result;
                this.ventasDia = new ObservableCollection<VentasDia>(list);



                this.Valor001 = float.Parse(VentasDia.Where(p => p.CO == "001").Select(r => r.Valor).FirstOrDefault().ToString()) / 1000;
                this.Valor002 = float.Parse(VentasDia.Where(p => p.CO == "002").Select(r => r.Valor).FirstOrDefault().ToString()) / 1000;
                this.Valor003 = float.Parse(VentasDia.Where(p => p.CO == "003").Select(r => r.Valor).FirstOrDefault().ToString()) / 1000;
                this.Valor004 = float.Parse(VentasDia.Where(p => p.CO == "004").Select(r => r.Valor).FirstOrDefault().ToString()) / 1000;
                this.Valor008 = float.Parse(VentasDia.Where(p => p.CO == "008").Select(r => r.Valor).FirstOrDefault().ToString()) / 1000;
                this.Valor009 = float.Parse(VentasDia.Where(p => p.CO == "009").Select(r => r.Valor).FirstOrDefault().ToString()) / 1000;
                this.Valor019 = float.Parse(VentasDia.Where(p => p.CO == "019").Select(r => r.Valor).FirstOrDefault().ToString()) / 1000;
                this.Valor025 = float.Parse(VentasDia.Where(p => p.CO == "025").Select(r => r.Valor).FirstOrDefault().ToString()) / 1000;

 
                List<datachar> datacharlist = new List<datachar>()
                {
                    new datachar(Valor001)
                    {
                        Color=NavyColor,
                        TextColor=NavyColor,
                        Label="NACIONAL",
                        ValueLabel=Valor001.ToString(),
                    },
                    new datachar(Valor002)
                    {
                        Color=AccentColor,
                        TextColor=AccentColor,
                        Label="CCA",
                        ValueLabel=Valor002.ToString(),
                    },
                    new datachar(Valor003)
                    {
                        Color=VerdeColor,
                        TextColor=VerdeColor,
                        Label="CMED",
                        ValueLabel=Valor003.ToString(),
                    },
                    new datachar(Valor004)
                    {
                        Color=GreenColor,
                        TextColor=GreenColor,
                        Label="OU70",
                        ValueLabel=Valor004.ToString(),
                    },
                    new datachar(Valor008)
                    {
                        Color=PinkColor,
                        TextColor=PinkColor,
                        Label="CBQUILLA",
                        ValueLabel=Valor008.ToString(),
                    },
                    new datachar(Valor009)
                    {
                        Color=OrangeColor,
                        TextColor=OrangeColor,
                        Label="REMATE",
                        ValueLabel=Valor009.ToString(),
                    },
                    new datachar(Valor019)
                    {
                        Color=AzulColor,
                        TextColor=AzulColor,
                        Label="INSTITUCIONAL",
                        ValueLabel=Valor019.ToString(),
                    },
                    new datachar(Valor025)
                    {
                        Color=FucsiaColor,
                        TextColor=FucsiaColor,
                        Label="SALOMIA",
                        ValueLabel=Valor025.ToString(),
                    },
                };

                GraficoVentas = new Microcharts.BarChart()
                {
                    Entries = datacharlist,
                };
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    ex.Message,
                    "Aceptar"
                    );

            }

        }


        #endregion
        #region Commands

        #endregion
    }
}
