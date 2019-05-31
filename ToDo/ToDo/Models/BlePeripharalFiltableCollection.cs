using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ToDo.Models
{
    public class BlePeripheralFiltableCollection : ObservableCollection<BlePeripheral>
    {
        // 元のリストデータ（変更後のデータとは別に保持する）
        private List<BlePeripheral> _items;

        public BlePeripheralFiltableCollection() : base()
        {
            _items = new List<BlePeripheral>();
        }
        public BlePeripheralFiltableCollection(List<BlePeripheral> items) : base(items)
        {
            _items = items;
        }
        public new void Add(BlePeripheral item)
        {
            _items.Add(item);
            base.Add(item);
        }
        public new bool Remove(BlePeripheral item)
        {
            // 元のリストデータから削除
            bool b = _items.Remove(item);
            // 
            this.Remove(item);

            return b;
        }
        public new void Insert(int index, BlePeripheral item)
        {
            _items.Insert(index, item);
        }
        public void Update(int id, BlePeripheral item)
        {
            var it = this._items.First(x => x.Id == id);
            if (it != null)
            {
                _items.Remove(it);
                _items.Add(item);
            }
        }
        public static BlePeripheralFiltableCollection MakeSampleData()
        {
            string uuid = "00001111-2222-3333-4444-666666666666";
            string uuid2 = "99999999-2222-3333-4444-222344576554";
            string uuid3 = "88888888-2222-3333-4444-987654345676";
            var lst = new List<BlePeripheral>
            {
                new BlePeripheral() { Id = 1, Name = "1st", IsOn = false, IsPaired = false, ServiceUuid = uuid, CharacteristicUuid = uuid, CharacteristicDescriptorUuid = uuid, /*Property = BlePeripheral.Properties.Notify*/ },
                new BlePeripheral() { Id = 2, Name = "2nd", IsOn = true, IsPaired = true, ServiceUuid = uuid2, CharacteristicUuid = uuid3, CharacteristicDescriptorUuid = uuid2, /*Property = BlePeripheral.Properties.Notify*/ },
                new BlePeripheral() { Id = 3, Name = "3rd", IsOn = false, IsPaired = true, ServiceUuid = uuid3, CharacteristicUuid = uuid2, CharacteristicDescriptorUuid = uuid3, /*Property = BlePeripheral.Properties.Notify*/ }
            };

            return new BlePeripheralFiltableCollection(lst);
        }
        public bool SaveAsXml(System.IO.Stream st)
        {
            try
            {
                st.SetLength(0);
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(BlePeripheralFiltableCollection));
                xs.Serialize(st, this);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        public bool LoadFromXml(System.IO.Stream st)
        {
            try
            {
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(BlePeripheralFiltableCollection));
                var newItems = xs.Deserialize(st) as BlePeripheralFiltableCollection;
                this._items = newItems._items;
                newItems._items.All(x => { base.Add(x); return true; });
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
    }
    }
