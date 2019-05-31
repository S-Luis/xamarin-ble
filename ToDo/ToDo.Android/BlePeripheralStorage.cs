using System;

[assembly:Xamarin.Forms.Dependency(typeof(ToDo.Droid.BlePeripheralStorage))]
namespace ToDo.Droid
{
    public class BlePeripheralStorage:ToDo.Views.IBlePeripheralStorage
    {
        public System.IO.Stream OpenReader(string fileName)
        {
            var docs = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = System.IO.Path.Combine(docs, fileName);
            if (System.IO.File.Exists(path))
            {
                return System.IO.File.OpenRead(path);
            }
            else
            {
                return null;
            }
        }
        public System.IO.Stream OpenWriter(string fileName)
        {
            var docs = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = System.IO.Path.Combine(docs, fileName);

            return System.IO.File.OpenWrite(path);
        }
        public BlePeripheralStorage()
        {
        }
    }
}
