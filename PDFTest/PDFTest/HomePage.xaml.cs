using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PDFTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();


        }

        private async void Document1Button(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DocumentPage1());
        }

        private async void Document2Button(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DocumentPage2());
        }

        private async void Document3Button(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DocumentPage3());
        }

        private async void SettingsButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }

        private async void ExitButton(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ExitPage());
        }
    }
}