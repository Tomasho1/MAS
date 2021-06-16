using System;
using System.Collections.Generic;
using System.IO;
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
            Type type = typeof(T);
            List<T> extent = (List<T>)type.GetProperty("Extent").GetValue(type, null);
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, extent);
            extents.Add(type, fileName);
            stream.Close();
        }

        public static void ReadExtent<T>()
        {
            try
            {
                Type type = typeof(T);
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(extents.GetValueOrDefault(type), FileMode.Open, FileAccess.Read, FileShare.Read);
                List<T> extent = (List<T>)formatter.Deserialize(stream);
                stream.Close();
            }
            catch (FileNotFoundException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
