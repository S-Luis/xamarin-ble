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
        MainViewModel viewModels;
        public MainPage()
        {
            InitializeComponent();
            viewModels = new MainViewModel();
            viewModels.Items = BlePeripheralFiltableCollection.MakeSampleData();
            this.Load();
            this.BindingContext = viewModels;
            ReceiveMassage();
        }
        private void ReceiveMassage()
        {
            MessagingCenter.Subscribe<DetailPage, BlePeripheral>(this, "UpdateItem",(page, item) =>
            {
                viewModels.Items.Update(item.Id, item);
                this.Save();
            });
            MessagingCenter.Subscribe<DetailPage, BlePeripheral>(this, "AddItem", (page, item) =>
            {
                item.Id = viewModels.Items.Count + 1;
                viewModels.Items.Add(item);
                this.Save();
            });
        }
        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            var item = BlePeripheral.CreateNewItem();
            await Navigation.PushAsync(new DetailPage(item));
        }
        private async void OnItemSelected(object sender,SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as BlePeripheral;
            if (item == null) 
            {
                return;
            }
            await Navigation.PushAsync(new DetailPage(item));
            listView.SelectedItem = null;
        }
        IBlePeripheralStorage storage = DependencyService.Get<IBlePeripheralStorage>();
        private void Save()
        {
            using (var st = storage.OpenWriter("save.xml"))
            {
                viewModels.Items.SaveAsXml(st);
            }
        }
        private void Load()
        {
            var items = new BlePeripheralFiltableCollection();
            using(var st = storage.OpenReader("save.xml"))
            {
                if (st == null || items.LoadFromXml(st) == false)
                {
                    items = BlePeripheralFiltableCollection.MakeSampleData();
                }
                viewModels.Items = items;
            }
        }
    }

    public interface IBlePeripheralStorage
    {
        System.IO.Stream OpenReader(string fileName);
        System.IO.Stream OpenWriter(string fileName);
    }
}