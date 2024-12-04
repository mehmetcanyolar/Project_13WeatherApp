using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Project_13WeatherApp
{
    public partial class Form1 : Form
    {
        FrmAsk frmAsk;

        public Form1(FrmAsk frmA)
        {
            InitializeComponent();
            this.frmAsk = frmA;
        }

       private async void Form1_Load(object sender, EventArgs e)
        {
           
            label2.Text = frmAsk.textBox1.Text;
            string a = label2.Text.ToLower();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city/"+a+"/EN"),
                Headers =
    {
        { "x-rapidapi-key", "8e2153b60cmshad87d4c02fb4d8fp1ddcabjsned53ab11d2ad" },
        { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var json = JObject.Parse(body);
                var value = json["main"]["temp"].ToString();
                lblFahrenheit.Text = value + " F";
                var valueWind = json["wind"]["speed"].ToString();
                lblWind.Text = valueWind+" km/h";
                var humidity = json["main"]["humidity"].ToString();
                lblHumidity.Text = humidity +" %";

                decimal valueCelsius = (decimal.Parse(value) - 32) * 5 / 9;
                lblCelcius.Text = valueCelsius.ToString("0.00");


                var openWeatherMainValue = json["weather"][0]["main"].ToString();

                string imagePath = @"C:\\Users\\mehme\\source\\repos\\Project_13WeatherApp\\Resources\\";

                string imageFileWeather = "";

                switch (openWeatherMainValue)
                {
                    case "Clouds":

                        imageFileWeather = "mostly-cloudy.png";
                        break;

                    case "Sun":
                        imageFileWeather = "sunny.png";
                        break;

                    case "Clear":
                        imageFileWeather = "partly-cloudy.png";
                        break;

                    case "Rain":
                        imageFileWeather = "rainy.png";
                        break;


                    case "Snow":
                        imageFileWeather = "snowy.png";
                        break;

                    default:
                        imageFileWeather = "mostly-cloudy.png";
                        break;
                }

                string finalWeatherImagePath = imagePath + imageFileWeather;
                pictureBox1.Image = Image.FromFile(finalWeatherImagePath);

            }


        }
    }
}
