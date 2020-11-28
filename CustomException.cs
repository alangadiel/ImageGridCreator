using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ImageGridCreator
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }

    public static class ExceptionExtensions
    {
        public static string CustomMessage(this Exception ex) => 
            ex switch
            {
                CustomException _ => ex.Message,
                FormatException _ => "Numeros no validos.",
                DirectoryNotFoundException _ => "No existe el directorio.",
                Exception _ => ex.ToString(),
            };
    }
}
