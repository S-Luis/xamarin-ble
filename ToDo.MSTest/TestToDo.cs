using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDo.Models;

namespace ToDo.MSTest
{
    [TestClass]
    public class TestToDo
    {
        [TestMethod]
        public void TestInit()
        {
            var peripheral = new BlePeripheral();
            peripheral.IsOn = false;
            peripheral.IsPaired = false;
            Assert.IsFalse(peripheral.IsOn);
            Assert.IsFalse(peripheral.IsPaired);
            peripheral.ServiceUuid = "11111111-1111-1111-1111-111111111111";
            peripheral.CharacteristicUuid = "11111111-1111-1111-1111-111111111111";
            peripheral.CharacteristicDescriptorUuid = "11111111-1111-1111-1111-111111111111";
            //peripheral.Property = Properties.Notify;
            Console.WriteLine("Service UUID is " + peripheral.ServiceUuid);
            Assert.IsFalse(peripheral.IsOn);
            Assert.IsFalse(peripheral.IsPaired);
            Assert.AreEqual("11111111-1111-1111-1111-111111111111", peripheral.ServiceUuid);
            Assert.AreEqual("11111111-1111-1111-1111-111111111111", peripheral.CharacteristicUuid);
            Assert.AreEqual("11111111-1111-1111-1111-111111111111", peripheral.CharacteristicDescriptorUuid);
            //Assert.AreEqual(Properties.Notify, peripheral.Property);
        }
    }
}
