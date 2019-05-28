using System;
using System.Text.RegularExpressions;

namespace ToDo.Models
{
    public class BlePeripheral : Helpers.ObservableObject
    {
        public const string UuidRegex = "^[0-9a-zA-A]{8}-[0-9a-zA-A]{4}-[0-9a-zA-A]{4}-[0-9a-zA-A]{4}-[0-9a-zA-A]{12}";
        public enum Properties
        {
            Read = 0,
            Write,
            Notify
        };
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
        private Properties property;
        public Properties Property
        {
            get { return property; }
            set { SetProperty(ref property, value); }
        }

        public static BlePeripheral CreateNewItem()
        {
            return new BlePeripheral()
            {
                isOn = false,
                isPaired = false,
                serviceUuid = null,
                characteristicUuid = null,
                characteristicDescriptorUuid = null,
                property = Properties.Notify
            };
        }
        public BlePeripheral CopyItem(BlePeripheral target)
        {
            target = target ?? new BlePeripheral();

            target.isOn = this.isOn;
            target.isPaired = this.isPaired;
            target.serviceUuid = this.serviceUuid;
            target.characteristicUuid = this.characteristicUuid;
            target.characteristicDescriptorUuid = this.characteristicDescriptorUuid;
            target.property = this.property;

            return target;
        }
    }
}
