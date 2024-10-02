
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace InsAPIGenerics.Logic.Utils
{
    public static class General_Functions
    {

        #region Enccrypt
        public static string Encrypt (string text)
        {
            if (text == null)
            {
                return null;
            }

            string key = Get_Configuration_Key("Key_Encrypt:key");
            byte[] llave; //Arreglo donde guardaremos la llave para el cifrado 3DES.
            byte[] arreglo = UTF8Encoding.UTF8.GetBytes(text); //Arreglo donde guardaremos la cadena descifrada.
                                                                 // Ciframos utilizando el Algoritmo MD5.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            md5.Clear();
            //Ciframos utilizando el Algoritmo 3DES.
            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = llave;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateEncryptor(); // Iniciamos la conversión de la cadena
            byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length); //Arreglo de bytes donde guardaremos la cadena cifrada.
            tripledes.Clear();
            string salida = Convert.ToBase64String(resultado, 0, resultado.Length); // Convertimos la cadena y la regresamos.
            salida = salida.Replace("+", "-");
            salida = salida.Replace("/", "_");
            salida = salida.Replace("=", ":");
            return salida;
        }
#endregion
        #region Desencrypt
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
        #endregion
        #region Encriptar64
        public static string Encriptar64(this string _cadenaAencriptar)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_cadenaAencriptar);
            result = Convert.ToBase64String(encryted);
            return result;
        }
        #endregion
        #region DesEncriptar64
        public static string DesEncriptar64(this string _cadenaAdesencriptar)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_cadenaAdesencriptar);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
        #endregion

        #region GetMD5
        public static string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        #endregion

        #region "Configuraciones"
        public static string Get_Configuration_Key(string key)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build(); 
            
            return configuration[key];
        }
        #endregion
        #region SEGUNDOSAMILISEGUNDOS
        public static int ConvertSecondsToMiliseconds(int seconds)
        {
            return seconds * 1000;
        }
        #endregion
        #region "Métodos para Tablas"
        //-----------------------------------------------------------------------------------------
        public static object Table_To_JsonString(DataTable table)
        {
            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in table.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    dict[col.ColumnName] = (Convert.ToString(row[col]));
                }
                list.Add(dict);
            }
            return list;
        }
        //-------------------------------------------------------------------------------------------
        public static DataTable JsonStringToDataTable(string jsonString)
        {
            DataTable dt = new DataTable();
            string[] jsonStringArray = System.Text.RegularExpressions.Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");
            List<string> ColumnsName = new List<string>();
            foreach (string jSA in jsonStringArray)
            {
                string[] jsonStringData = System.Text.RegularExpressions.Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
                foreach (string ColumnsNameData in jsonStringData)
                {
                    try
                    {
                        int idx = ColumnsNameData.IndexOf(":");
                        string ColumnsNameString = ColumnsNameData.Substring(0, idx - 1).Replace("\"", "");
                        if (!ColumnsName.Contains(ColumnsNameString))
                        {
                            ColumnsName.Add(ColumnsNameString);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error Parsing Column Name : {ColumnsNameData} {ex.Message}");
                    }
                }
                break;
            }
            foreach (string AddColumnName in ColumnsName)
            {
                dt.Columns.Add(AddColumnName);
            }
            foreach (string jSA in jsonStringArray)
            {
                string[] RowData = System.Text.RegularExpressions.Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
                DataRow nr = dt.NewRow();
                foreach (string rowData in RowData)
                {
                    try
                    {
                        int idx = rowData.IndexOf(":");
                        string RowColumns = rowData.Substring(0, idx - 1).Replace("\"", "");
                        string RowDataString = rowData.Substring(idx + 1).Replace("\"", "");
                        nr[RowColumns] = RowDataString;
                    }
                    catch// (Exception ex)
                    {
                        continue;
                    }
                }
                dt.Rows.Add(nr);
            }
            return dt;
        }
        //-----------------------------------------------------------------------------------------
        public static object DataTable_To_JsonDictionary(DataTable table)
        {
            var list = new List<Dictionary<string, object>>();
            foreach (DataRow row in table.Rows)
            {
                var dict = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    dict[col.ColumnName] = row[col];
                }
                list.Add(dict);
            }
            return list;
        }

        #endregion

        #region "Métodos para fechas"
        //-----------------------------------------------------------------------------------------
        public static string TodayToddmmyyyy(int Num)
        {
            DateTime today = DateTime.Today;
            DateTime DaysEarlier = today.AddDays(Num);
            return DaysEarlier.ToString("dd/MM/yyyy");
        }
        //-------------------------------------------------------------------------------------------
        public static string TodayToyyyymmdd(int Num)
        {
            DateTime today = DateTime.Today;
            DateTime DaysEarlier = today.AddDays(Num);
            return DaysEarlier.ToString("yyyy-MM-dd");
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
      
        #endregion

    }
}
