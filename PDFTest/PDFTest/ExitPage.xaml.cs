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
    public partial class ExitPage : ContentPage
    {
        public ExitPage()
        {
            InitializeComponent();
        }

        private void ExitAppButton(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private async void GoBackButton(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}