using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppHotel.Model;

namespace AppHotel.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastrarHospedagem : ContentPage
    {
        App PropriedadesApp;

        public CadastrarHospedagem()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            PropriedadesApp = (App)Application.Current;

            lbl_usuario.Text = App.Current.Properties["usuario_logado"].ToString();

            pck_suite.ItemsSource = PropriedadesApp.lista_suites;

            dtpck_checkin.MinimumDate = DateTime.Now;
            dtpck_checkin.MaximumDate = DateTime.Now.AddMonths(6);

            dtpck_checkout.MinimumDate = DateTime.Now.AddDays(1);
            dtpck_checkout.MaximumDate = DateTime.Now.AddMonths(6).AddDays(1);
        }

        private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
        {
            DatePicker elemento = (DatePicker)sender;

            dtpck_checkout.MinimumDate = elemento.Date.AddDays(1);
            dtpck_checkout.MaximumDate = elemento.Date.AddMonths(6).AddDays(1);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new CalcularHospedagem()
                {
                    BindingContext = new Hospedagem()
                    {
                        QntAdultos = Convert.ToInt32(lbl_qnt_adultos.Text),
                        QntCriancas = Convert.ToInt32(lbl_qnt_criancas.Text),
                        QuartoEscolhido = (Suite)pck_suite.SelectedItem,
                        DataCheckIn = dtpck_checkin.Date,
                        DataCheckOut = dtpck_checkout.Date
                    }
                });
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            bool confirmar = await DisplayAlert("Tem certeza?", "Desconectar sua conta?", "Sim", "Não");

            if (confirmar)
            {
                App.Current.Properties.Remove("usuario_logado");
                App.Current.MainPage = new Login();
            }
        }
    }
}