using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace MAS_Final
{
    // <summary>
    // Statyczna klasa pomocnicza do zarządzania ekstensją i formowatowaniem wartości z enumów
    // <summary>
    public static class Helper
    {
        //Statyczna lista przechowująca wpisy na temat klas i nazwy pliku z jej ekstensją
        private static Dictionary<Type, String> extents = new Dictionary<Type, String>();

        //Zapisanie ekstensji klasy do pliku
        public static void SaveExtent<T>(String fileName)
        {
            Type typ = typeof(T);
            List<T> extent = (List<T>)typ.GetProperty("Extent", BindingFlags.Static | BindingFlags.Public).GetValue(null, null);

            if(extents.ContainsKey(typ))
            {
                extents.Remove(typ);
                File.Delete(fileName);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, extent);
            extents.Add(typ, fileName);
            stream.Close();
        }

        //Odczytanie ekstensji klasy z pliku
        public static void ReadExtent<T>()
        {
            try
            {
                Type typ = typeof(T);
                List<T> extent = (List<T>)typ.GetProperty("Extent", BindingFlags.Static | BindingFlags.Public).GetValue(null, null);

                if (!extents.ContainsKey(typ))
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

        //Wyświetlenie obiektów znajdujących się w ekstensji
        public static void ShowExtent<T>()
        {
            Type typ = typeof(T);
            List<T> extent = (List<T>)typ.GetProperty("Extent", BindingFlags.Static | BindingFlags.Public).GetValue(null, null);

            foreach (T t in extent)
            {
                Console.WriteLine($"Obiekt: {t}");
            }
        }

        //Uzyskanie opisu umieszczonego przy wartości w enumie
        public static string GetEnumDescription(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }
    }
}

