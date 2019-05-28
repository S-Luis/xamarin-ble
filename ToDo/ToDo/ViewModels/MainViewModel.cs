using System;
namespace ToDo.ViewModels
{
    public class MainViewModel:Helpers.ObservableObject
    {
        public Models.BlePeripheralFiltableCollection Items { get; set; }
        public MainViewModel()
        {
        }
    }
}
