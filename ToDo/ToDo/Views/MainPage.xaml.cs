using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using ToDo.ViewModels;
using ToDo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ToDo.Views
{
    /// <summary>
    ///  Xamlでコンパイルする
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var viewModels = new MainViewModel();
            viewModels.Items = BlePeripheralFiltableCollection.MakeSampleData();
            this.BindingContext = viewModels;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DetailPage());
        }
    }
}