using System;
using System.Collections.Generic;

namespace LuisSocial.Util
{
    public class Cadenas
    {
        public static string Url { get; } = "http://adamacontactos.azurewebsites.net/api";
        public static IDictionary<object, object> Session { get; set; } = 
            new Dictionary<object, object>();
    }
}