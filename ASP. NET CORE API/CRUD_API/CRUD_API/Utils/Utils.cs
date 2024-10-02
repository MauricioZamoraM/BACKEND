using System.Data;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

public static class Utils
{
    public static string Get_Configuration_Key(string key)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();

        return configuration[key];
    }

    public static string Desencrypt(string text)
    {
        if (text == null)
        {
            return null;
        }

        string key = Get_Configuration_Key("Key_Encrypt:key");
        string entrada = text.Replace("-", "+").Replace("_", "/").Replace(":", "=");
        byte[] llave;
        byte[] arreglo = Convert.FromBase64String(entrada); // Arreglo donde guardaremos la cadena descovertida.
                                                            // Ciframos utilizando el Algoritmo MD5.
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
        md5.Clear();
        //Ciframos utilizando el Algoritmo 3DES.
        TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
        tripledes.Key = llave;
        tripledes.Mode = CipherMode.ECB;
        tripledes.Padding = PaddingMode.PKCS7;
        ICryptoTransform convertir = tripledes.CreateDecryptor();
        byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length);
        tripledes.Clear();
        string cadena_descifrada = UTF8Encoding.UTF8.GetString(resultado); // Obtenemos la cadena
        return cadena_descifrada; // Devolvemos la cadena
    }

    public static string Get_Connection_String(string key)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
        return configuration.GetConnectionString(key);
    }

    public static string Get_Decrypted_Connection_String(string key)
    {
        return Get_Connection_String(key);
    }

    public static bool IsNullable(this Type type)
    {
        return Nullable.GetUnderlyingType(type) != null;
    }

    public static string DateTime_Format_BD(DateTime date)
    {
        //vamos a utilizar el formato YYYYMMDD HH:mm:SS
        string dateFormatted = string.Format("{0}{1}{2} {3}:{4}:{5}:{6}", PadLeft(date.Year, 4), PadLeft(date.Month), PadLeft(date.Day), PadLeft(date.Hour), PadLeft(date.Minute), PadLeft(date.Second), PadLeft(date.Millisecond));
        return dateFormatted;
    }

    public static string PadLeft(int number, int length = 2, char fillChar = '0')
    {
        return number.ToString().PadLeft(length, fillChar);
    }
}
