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

    }

}
