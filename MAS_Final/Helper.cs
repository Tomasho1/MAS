using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace MAS_Final
{

    public abstract class Helper
    {
        private static Dictionary<Type, String> extents = new Dictionary<Type, String>();
        public static void SaveExtent<T>(String fileName)
        {
            Type typ = typeof(T);
            List<T> extent = (List<T>)typ.GetProperty("Extent", BindingFlags.Static | BindingFlags.Public).GetValue(null, null);

            if (extents.ContainsValue(fileName))
            {
                var x = extents.FirstOrDefault(x => x.Value == fileName).Key;
                extents.Remove(x);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, extent);
            extents.Add(typ, fileName);
            stream.Close();
        }

        public static void ReadExtent<T>()
        {
            try
            {
                Type typ = typeof(T);
                List<T> extent = (List<T>)typ.GetProperty("Extent", BindingFlags.Static | BindingFlags.Public).GetValue(null, null);

                if(!extents.ContainsKey(typ))
                {
                    throw new Exception("Ekstensja klasy nie została wcześniej zapisana");
                }
                extent.Clear();

                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(extents.GetValueOrDefault(typ), FileMode.Open, FileAccess.Read, FileShare.Read);
                extent = (List<T>)formatter.Deserialize(stream);
                typ.GetProperty("Extent", BindingFlags.Static | BindingFlags.Public).SetValue(typ, extent);
                stream.Close();
            }
            catch (FileNotFoundException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        public static void ShowExtent<T>()
        {
            Type typ = typeof(T);
            List<T> extent = (List<T>)typ.GetProperty("Extent", BindingFlags.Static | BindingFlags.Public).GetValue(null, null);

            foreach (T t in extent)
            {
                Console.WriteLine($"Obiekt: {t}");
            }
        }
    }
}
