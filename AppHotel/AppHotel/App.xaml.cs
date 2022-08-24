using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppHotel.View;
using AppHotel.Model;

namespace AppHotel
{
    public partial class App : Application
    {
        public List<Suite> lista_suites = new List<Suite>
        {
            new Suite()
            {
                Nome = "Super Luxo",
                DiariaAdulto = 110.0,
                DiariaCrianca = 55.0
            },

            new Suite()
            {
                Nome = "Executiva",
                DiariaAdulto = 90.0,
                DiariaCrianca = 45.0
            },

             new Suite()
            {
                Nome = "Básica",
                DiariaAdulto = 45.0,
                DiariaCrianca = 20.0
            },
        };

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
