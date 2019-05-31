using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        // Editing item
        BlePeripheral _item;
        public DetailPage()
        {
            InitializeComponent();
        }
        public DetailPage(BlePeripheral item)
        {
            InitializeComponent();
            this.BindingContext = _item = item;
        }

        async void Save_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
            if(_item.Id == 0)
            {
                MessagingCenter.Send(this, "AddItem", _item);
            }
            else
            {
                MessagingCenter.Send(this, "UpdateItem", _item);
            }
        }
        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
    }
}