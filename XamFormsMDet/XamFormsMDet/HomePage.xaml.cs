using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamFormsMDet.Views;

namespace XamFormsMDet
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {

        public MainPage MasterDetailMainPage;

        public HomePage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            MasterDetailMainPage = new MainPage();

            Navigation.PushAsync(MasterDetailMainPage);
        }
    }
}