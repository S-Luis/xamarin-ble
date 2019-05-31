using System;
using System.Text.RegularExpressions;

namespace ToDo.Models
{
    public class BlePeripheral : Helpers.ObservableObject
    {
        [System.Xml.Serialization.XmlIgnore]
        static readonly string UuidRegex = "^[0-9a-zA-A]{8}-[0-9a-zA-A]{4}-[0-9a-zA-A]{4}-[0-9a-zA-A]{4}-[0-9a-zA-A]{12}";
        public enum Properties
        {
            Read = 0,
            Write,
            Notify
        };
        public int Id { get; set; }
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        private bool isOn;
        public bool IsOn
        {
            get { return isOn; }
            set { SetProperty(ref isOn, value); }
        }
        private bool isPaired;
        public bool IsPaired
        {
            get { return isPaired; }
            set { SetProperty(ref isPaired, value); }
        }
        private string serviceUuid;
        public string ServiceUuid
        {
            get { return serviceUuid; }
            set
            {
                if (Regex.IsMatch(value, @UuidRegex))
                {
                    SetProperty(ref serviceUuid, value);
                }
            }
        }
        private string characteristicUuid;
        public string CharacteristicUuid
        {
            get { return characteristicUuid; }
            set
            {
                if (Regex.IsMatch(value, @UuidRegex))
                {
                    SetProperty(ref characteristicUuid, value);
                }
            }
        }
        private string characteristicDescriptorUuid;
        public string CharacteristicDescriptorUuid
        {
            get { return characteristicDescriptorUuid; }
            set
            {
                if (Regex.IsMatch(value, @UuidRegex))
                {
                    SetProperty(ref characteristicDescriptorUuid, value);
                }
            }
        }
        /*private Properties property;
        public Properties Property
        {
            get { return property; }
            set { SetProperty(ref property, value); }
        }*/

        public static BlePeripheral CreateNewItem()
        {
            return new BlePeripheral()
            {
                name = "Inited",
                isOn = true,
                isPaired = false,
                serviceUuid = "00001111-2222-3333-4444-666666666666",
                characteristicUuid = "00001111-2222-3333-4444-666666666666",
                characteristicDescriptorUuid = "00001111-2222-3333-4444-666666666666",
                //Property = Properties.Notify
            };
        }
        public BlePeripheral CopyItem(BlePeripheral target)
        {
            target = target ?? new BlePeripheral();

            target.Name = this.Name;
            target.IsOn = this.isOn;
            target.IsPaired = this.isPaired;
            target.ServiceUuid = this.serviceUuid;
            target.CharacteristicUuid = this.characteristicUuid;
            target.CharacteristicDescriptorUuid = this.characteristicDescriptorUuid;
            //target.property = this.property;

            return target;
        }
    }
}
