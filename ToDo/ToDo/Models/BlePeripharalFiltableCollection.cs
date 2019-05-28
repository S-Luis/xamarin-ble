using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ToDo.Models
{
    public class BlePeripheralFiltableCollection:ObservableCollection<BlePeripheral>
    {
        // Original list data
        private List<BlePeripheral> _items;
        // For sorting
        private bool _dispCompleted;
        private int _sortOrder;

        public BlePeripheralFiltableCollection():base()
        {
            _items = new List<BlePeripheral>();
        }
        public BlePeripheralFiltableCollection(List<BlePeripheral> items) : base(items)
        {
            _items = items;
        }
        public new void Add(BlePeripheral item)
        {
            Items.Add(item);
        }
        public new bool Remove(BlePeripheral item)
        {
            bool b = _items.Remove(item);
            this.Remove(item);

            return b;
        }
        public new void Insert(int index,BlePeripheral item)
        {
            _items.Insert(index, item);
        }
        public static BlePeripheralFiltableCollection MakeSampleData()
        {
            string uuid = "00001111-2222-3333-4444-666666666666";
            string uuid2 = "99999999-2222-3333-4444-222344576554";
            string uuid3 = "88888888-2222-3333-4444-987654345676";
            var lst = new List<BlePeripheral>
            {
                new BlePeripheral() { Name = "1st children", IsOn = false, IsPaired = false, ServiceUuid = uuid, CharacteristicUuid = uuid, CharacteristicDescriptorUuid = uuid, Property = BlePeripheral.Properties.Notify },
                new BlePeripheral() { Name = "2nd children", IsOn = true, IsPaired = true, ServiceUuid = uuid2, CharacteristicUuid = uuid3, CharacteristicDescriptorUuid = uuid2, Property = BlePeripheral.Properties.Notify },
                new BlePeripheral() { Name = "3rd children", IsOn = false, IsPaired = true, ServiceUuid = uuid3, CharacteristicUuid = uuid2, CharacteristicDescriptorUuid = uuid3, Property = BlePeripheral.Properties.Notify }
            };

            return new BlePeripheralFiltableCollection(lst);
        }

    }

}
