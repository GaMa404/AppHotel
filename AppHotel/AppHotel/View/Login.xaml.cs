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
        string usuario_correto = "gama";
        string senha_correta = "123";

        public Login()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void btn_entrar_Clicked(object sender, EventArgs e)
        {
            string usuario_digitado = user.Text;
            string senha_digitada = pass.Text;

            if (usuario_correto == usuario_digitado && senha_correta == senha_digitada)
            {
                try
                {
                    await Navigation.PushAsync(new View.CadastrarHospedagem());
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", ex.Message, "Ok");
                }
            }
            else
            {
                await DisplayAlert("Erro", "Dados incorretos.", "Ok");
            }
        }
    }
}