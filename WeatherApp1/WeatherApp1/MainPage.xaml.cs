using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using WeatherApp;
using Xamarin.Forms;

namespace WeatherApp1
{
    public partial class MainPage : ContentPage
    {
        RestServices _restServices;
        public MainPage()
        {
            InitializeComponent();
            _restServices = new RestServices();
        }

        async void GetWeatherData(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_enterCity.Text))
            {
                Datatags1 weatherD = await _restServices.GetDatatags1(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
                BindingContext = weatherD;
            }

            string GenerateRequestUri(string endpoint)
            {
                string requestUri = endpoint;
                requestUri += $"?q={_enterCity.Text}";
                requestUri += "&units=metric"; 
                requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
                return requestUri;
            }
        }

    }
}
