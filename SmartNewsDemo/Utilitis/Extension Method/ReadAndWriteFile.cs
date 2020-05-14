using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SmartNewsDemo.Utilitis.Extension_Method
{
    public class ReadAndWriteFile
    {
        public static string GetJsonData(string JsonFileName)
        {
           
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(ReadAndWriteFile)).Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.Common.Storage.{JsonFileName}");
            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                return json;
            }
        }
    }
}
