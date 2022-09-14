using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHotel.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        App PropriedadesApp;

        public Login()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            PropriedadesApp = (App)Application.Current;
        }

        private async void btn_entrar_Clicked(object sender, EventArgs e)
        {
            string usuario_digitado = user.Text;
            string senha_digitada = pass.Text;

            string usuario_correto = "gama";
            string senha_correta = "123";

            if (usuario_correto == usuario_digitado && senha_correta == senha_digitada)
            {
                App.Current.Properties.Add("usuario_logado", usuario_digitado);
                App.Current.MainPage = new NavigationPage(new CadastrarHospedagem());
            }
            else
            {
                await DisplayAlert("Erro", "Dados incorretos.", "Ok");
            }
        }
    }
}