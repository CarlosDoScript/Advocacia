using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Web;
using System.IO;
using System.Web.Mvc;

namespace BWProtocoloWebBusiness.Helper
{
    /// <summary>
    /// Classe que extende os métodos do framework
    /// </summary>
    public static class ExtensionMethods
    {
        #region Int16

        /// <summary>
        /// Método que converte um objeto para número inteiro de 16bits
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <returns>Retorna o número inteiro convertido</returns>
        public static Int16 ToInt16(this Object obj)
        {
            try { return Convert.ToInt16(obj); }
            catch { throw new Exception(String.Format("O valor informado não é um valor inteiro válido! Valor informado: '{0}'", obj)); }
        }

        /// <summary>
        /// Método que converte um objeto para número inteiro de 16bits
        /// </summary>
        /// <param name="obj">Número em objeto a ser convertido</param>
        /// <param name="returnValue">Valor de retorno se der erro na conversão</param>
        /// <returns>Retorna o número decimal convertido ou o valor informado se der erro</returns>
        public static Int16 ToInt16(this Object obj, Int16 returnValue)
        {
            try { return Convert.ToInt16(obj); }
            catch { return returnValue; }
        }

        /// <summary>
        /// Método que converte um texto para número
        /// </summary>
        /// <param name="text">Número em texto a ser convertido</param>
        /// <returns>Retorna o número inteiro convertido</returns>
        public static Int16 ToInt16(this String text)
        {
            try { return Convert.ToInt16(text); }
            catch { throw new Exception(String.Format("O valor informado não é um valor inteiro válido! Valor informado: '{0}'", text)); }
        }

        /// <summary>
        /// Método que converte um texto para número inteiro de 16bits
        /// </summary>
        /// <param name="obj">Número em texto a ser convertido</param>
        /// <param name="returnValue">Valor de retorno se der erro na conversão</param>
        /// <returns>Retorna o número decimal convertido ou o valor informado se der erro</returns>
        public static Int16 ToInt16(this String text, Int16 returnValue)
        {
            try { return Convert.ToInt16(text); }
            catch { return returnValue; }
        }

        #endregion

        public static string PrimeiraLetraMaiscula(string entrada)
        {
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(entrada);
        }

        public static string PrimeiraLetraPalavrasMaisculas(string entrada)
        {
            var textInfo = CultureInfo.GetCultureInfo("pt-BR").TextInfo;
            return textInfo.ToTitleCase(entrada);
        }

        #region Int32

        /// <summary>
        /// Método que converte um objeto para número inteiro de 32bits
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <returns>Retorna o número inteiro convertido</returns>
        public static Int32 ToInt32(this Object obj)
        {
            try { return Convert.ToInt32(obj); }
            catch { throw new Exception(String.Format("O valor informado não é um valor inteiro válido! Valor informado: '{0}'", obj)); }
        }

        /// <summary>
        /// Método que converte um objeto para número inteiro de 32bits
        /// </summary>
        /// <param name="obj">Número em objeto a ser convertido</param>
        /// <param name="returnValue">Valor de retorno se der erro na conversão</param>
        /// <returns>Retorna o número decimal convertido ou o valor informado se der erro</returns>
        public static Int32 ToInt32(this Object obj, Int32 returnValue)
        {
            try { return Convert.ToInt32(obj); }
            catch { return returnValue; }
        }

        /// <summary>
        /// Método que converte um texto para número
        /// </summary>
        /// <param name="text">Número em texto a ser convertido</param>
        /// <returns>Retorna o número inteiro convertido</returns>
        public static Int32 ToInt32(this String text)
        {
            try { return Convert.ToInt32(text); }
            catch { throw new Exception(String.Format("O valor informado não é um valor inteiro válido! Valor informado: '{0}'", text)); }
        }

        /// <summary>
        /// Método que converte um texto para número inteiro de 32bits
        /// </summary>
        /// <param name="obj">Número em texto a ser convertido</param>
        /// <param name="returnValue">Valor de retorno se der erro na conversão</param>
        /// <returns>Retorna o número decimal convertido ou o valor informado se der erro</returns>
        public static Int32 ToInt32(this String text, Int32 returnValue)
        {
            try { return Convert.ToInt32(text); }
            catch { return returnValue; }
        }

        #endregion

        #region Int64

        /// <summary>
        /// Método que converte um objeto para número inteiro de 64bits
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <returns>Retorna o número inteiro convertido</returns>
        public static Int64 ToInt64(this Object obj)
        {
            try { return Convert.ToInt64(obj); }
            catch { throw new Exception(String.Format("O valor informado não é um valor inteiro válido! Valor informado: '{0}'", obj)); }
        }

        /// <summary>
        /// Método que converte um objeto para número inteiro de 64bits
        /// </summary>
        /// <param name="obj">Número em objeto a ser convertido</param>
        /// <param name="returnValue">Valor de retorno se der erro na conversão</param>
        /// <returns>Retorna o número decimal convertido ou o valor informado se der erro</returns>
        public static Int64 ToInt64(this Object obj, Int64 returnValue)
        {
            try { return Convert.ToInt64(obj); }
            catch { return returnValue; }
        }

        /// <summary>
        /// Método que converte um texto para número
        /// </summary>
        /// <param name="text">Número em texto a ser convertido</param>
        /// <returns>Retorna o número inteiro convertido</returns>
        public static Int64 ToInt64(this String text)
        {
            try { return Convert.ToInt64(text); }
            catch { throw new Exception(String.Format("O valor informado não é um valor inteiro válido! Valor informado: '{0}'", text)); }
        }

        /// <summary>
        /// Método que converte um texto para número inteiro de 64bits
        /// </summary>
        /// <param name="obj">Número em texto a ser convertido</param>
        /// <param name="returnValue">Valor de retorno se der erro na conversão</param>
        /// <returns>Retorna o número decimal convertido ou o valor informado se der erro</returns>
        public static Int64 ToInt64(this String text, Int64 returnValue)
        {
            try { return Convert.ToInt64(text); }
            catch { return returnValue; }
        }

        #endregion

        #region decimal
        /// <summary>
        /// Método que converte um texto para decimal
        /// </summary>
        /// <param name="text">Número em texto a ser convertido</param>
        /// <returns>Retorna o número decimal convertido</returns>
        public static Decimal ToDecimal(this String text)
        {
            try { return Convert.ToDecimal(text); }
            catch { throw new Exception(String.Format("O valor informado não é um valor decimal válido! Valor informado: '{0}'", text)); }
        }

        /// <summary>
        /// Método que converte um texto para decimal
        /// </summary>
        /// <param name="text">Número em texto a ser convertido</param>
        /// <param name="returnValue">Valor de retorno se der erro na conversão</param>
        /// <returns>Retorna o número decimal convertido ou o valor informado se der erro</returns>
        public static Decimal ToDecimal(this String text, decimal returnValue)
        {
            try { return Convert.ToDecimal(text); }
            catch { return returnValue; }
        }

        /// <summary>
        /// Método que converte um objeto para um valor decimal
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <returns>Retorna o número decimal convertido</returns>
        public static Decimal ToDecimal(this Object obj)
        {
            try { return Convert.ToDecimal(obj); }
            catch { throw new Exception(String.Format("O valor informado não é um valor decimal válido! Valor informado: '{0}'", obj)); }
        }

        /// <summary>
        /// Método que converte um objeto para um valor decimal
        /// </summary>
        /// <param name="obj">Número em texto a ser convertido</param>
        /// <param name="returnValue">Valor de retorno se der erro na conversão</param>
        /// <returns>Retorna o número decimal convertido ou o valor informado se der erro</returns>
        public static Decimal ToDecimal(this Object obj, decimal returnValue)
        {
            try { return Convert.ToDecimal(obj); }
            catch { return returnValue; }
        }

        #endregion

        #region boolean

        /// <summary>
        /// Método que converte um objeto para um valor booleano
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <returns>Retorna o valor booleano convertido o erro na conversão</returns>
        public static Boolean ToBoolean(this Object obj)
        {
            try { return Convert.ToBoolean(obj); }
            catch { throw new Exception(String.Format("O valor informado não é um valor booleano válido! Valor informado: '{0}'", obj)); }
        }

        /// <summary>
        /// Método que converte um objeto para um valor booleano
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="returnValue">Valor de retorno se der erro na conversão</param>
        /// <returns>Retorna o valor booleano convertido ou o valor informado se der erro</returns>
        public static Boolean ToBoolean(this Object obj, bool returnValue)
        {
            try { return Convert.ToBoolean(obj); }
            catch { return returnValue; }
        }

        /// <summary>
        /// Método que converte um texto para um valor booleano
        /// </summary>
        /// <param name="text">Texto a ser convertido</param>
        /// <returns>Retorna o valor booleano convertido o erro na conversão</returns>
        public static Boolean ToBoolean(this string text)
        {
            try
            {
                var s = (text ?? "").Trim().ToLower();
                if (s == "true" || s == "1")
                {
                    return true;
                }
                else if (s == "false" || s == "0")
                {
                    return false;
                }
                return false;
            }
            catch { throw new Exception(String.Format("O valor informado não é um valor booleano válido! Valor informado: '{0}'", text)); }
            //try { return Convert.ToBoolean(text); }
            //catch { throw new Exception(String.Format("O valor informado não é um valor booleano válido! Valor informado: '{0}'", text)); }
        }

        /// <summary>
        /// Método que converte um texto para um valor booleano
        /// </summary>
        /// <param name="text">Texto a ser convertido</param>
        /// <param name="returnValue">Valor de retorno se der erro na conversão</param>
        /// <returns>Retorna o valor booleano convertido ou o valor informado se der erro</returns>
        public static Boolean ToBoolean(this string text, bool returnValue)
        {
            try { return Convert.ToBoolean(text); }
            catch { return returnValue; }
        }

        /// <summary>
        /// Método que converte um número para um valor booleano
        /// </summary>
        /// <param name="value">Número a ser convertido</param>
        /// <returns>Retorna o valor booleano convertido o erro na conversão</returns>
        public static Boolean ToBoolean(this Int16 value)
        {
            try { return Convert.ToBoolean(value); }
            catch { throw new Exception(String.Format("O valor informado não é um valor booleano válido! Valor informado: '{0}'", value)); }
        }

        /// <summary>
        /// Método que converte um número para um valor booleano
        /// </summary>
        /// <param name="value">Texto a ser convertido</param>
        /// <param name="returnValue">Número de retorno se der erro na conversão</param>
        /// <returns>Retorna o valor booleano convertido ou o valor informado se der erro</returns>
        public static Boolean ToBoolean(this Int16 value, bool returnValue)
        {
            try { return Convert.ToBoolean(value); }
            catch { return returnValue; }
        }

        /// <summary>
        /// Método que converte um número para um valor booleano
        /// </summary>
        /// <param name="value">Número a ser convertido</param>
        /// <returns>Retorna o valor booleano convertido o erro na conversão</returns>
        public static Boolean ToBoolean(this Int32 value)
        {
            try { return Convert.ToBoolean(value); }
            catch { throw new Exception(String.Format("O valor informado não é um valor booleano válido! Valor informado: '{0}'", value)); }
        }

        /// <summary>
        /// Método que converte um número para um valor booleano
        /// </summary>
        /// <param name="value">Texto a ser convertido</param>
        /// <param name="returnValue">Número de retorno se der erro na conversão</param>
        /// <returns>Retorna o valor booleano convertido ou o valor informado se der erro</returns>
        public static Boolean ToBoolean(this Int32 value, bool returnValue)
        {
            try { return Convert.ToBoolean(value); }
            catch { return returnValue; }
        }

        /// <summary>
        /// Método que converte um número para um valor booleano
        /// </summary>
        /// <param name="value">Número a ser convertido</param>
        /// <returns>Retorna o valor booleano convertido o erro na conversão</returns>
        public static Boolean ToBoolean(this Int64 value)
        {
            try { return Convert.ToBoolean(value); }
            catch { throw new Exception(String.Format("O valor informado não é um valor booleano válido! Valor informado: '{0}'", value)); }
        }

        /// <summary>
        /// Método que converte um número para um valor booleano
        /// </summary>
        /// <param name="value">Texto a ser convertido</param>
        /// <param name="returnValue">Número de retorno se der erro na conversão</param>
        /// <returns>Retorna o valor booleano convertido ou o valor informado se der erro</returns>
        public static Boolean ToBoolean(this Int64 value, bool returnValue)
        {
            try { return Convert.ToBoolean(value); }
            catch { return returnValue; }
        }
        #endregion


        /// <summary>
        /// Método que converte um texto para Data
        /// </summary>
        /// <param name="text">Número em texto a ser convertido</param>
        /// <returns>Retorna a Data convertida</returns>
        public static DateTime ToDate(this String text)
        {
            try { return Convert.ToDateTime(text); }
            catch { throw new Exception(String.Format("O valor informado não é um valor data válido! Valor informado: '{0}'", text)); }
        }


        /// <summary>
        /// Método que converte um texto para Guid
        /// </summary>
        /// <param name="text">Número em texto a ser convertido</param>
        /// <returns>Retorna a Guid convertida</returns>
        public static Guid ToGuid(this String text)
        {
            Guid guid = new Guid();
            try { guid = new Guid(text); }
            catch { guid = Guid.Empty; }
            return guid;
        }

        /// <summary>
        /// Método que converte um texto para Char
        /// </summary>
        /// <param name="text">Número em texto a ser convertido</param>
        /// <returns>Retorna o valor char convertido</returns>
        public static Char ToChar(this String text)
        {
            try { return Convert.ToChar(text); }
            catch { throw new Exception(String.Format("O valor informado não é um valor char válido! Valor informado: '{0}'", text)); }

        }

        /// <summary>
        /// Método que converte um texto para Double
        /// </summary>
        /// <param name="value">Número em texto a ser convertido</param>
        /// <returns>Retorna o valor Double convertido</returns>
        public static Double ToDouble(this String value)
        {
            Double dbl = new Double();
            try { dbl = Convert.ToDouble(value); }
            catch { throw new Exception(String.Format("O valor informado não é um valor double válido! Valor informado: '{0}'", value)); }
            return dbl;
        }

        /// <summary>
        /// Método que Gera uma quantidade desejada de um mesmo caractere. Usado, por exemplo, para fazer uma linha
        /// </summary>
        /// <param name="character">Caracter desejado</param>
        /// <param name="length">Tamanho desejado</param>
        /// <returns>Retorna o valor após concatenação</returns>
        public static String Fill(this String character, Int32 length)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
                sb.Append(character);

            return sb.ToString();
        }

        /// <summary>
        /// Metodo que retira de uma string: . - , / _ ( ) [ ]
        /// </summary>
        /// <param name="text">Texto de entrada</param>
        /// <returns>Texto sem caracteres especiais</returns>
        public static String ClearString(this String text)
        {
            string inputString = ".-,/_()[] ";
            string outputString = "";
            for (int i = 0; i < inputString.Length; i++)
                text = text.Replace(inputString[i].ToString(), outputString);

            return text;
        }

        /// <summary>
        /// Limpar documento como CPF e CNPJ
        /// </summary>
        /// <param name="text">Documento</param>
        /// <returns>Texto sem caracteres especiais</returns>
        public static String ClearDoc(this String text)
        {
            string inputString = ".-,/_()[]";
            string outputString = "";
            for (int i = 0; i < inputString.Length; i++)
                text = text.Replace(inputString[i].ToString(), outputString);

            return text;
        }

        /// <summary>
        /// Metodo que retira os careacteres passados de uma string
        /// /// </summary>
        /// <param name="text">Texto de entrada</param>
        /// <param name="inputString">String que deseja que sejam substituidas</param>
        /// <returns>Texto sem caracteres especiais</returns>
        public static String ClearString(this String text, String inputString)
        {
            string outputString = "";
            for (int i = 0; i < inputString.Length; i++)
                text = text.Replace(inputString[i].ToString(), outputString);

            return text;
        }

        /// <summary>
        /// Metodo que retira os acentos
        /// </summary>
        /// <param name="text">Texto com acento</param>
        /// <returns>Texto sem acento</returns>
        public static String RemoveAcent(this String text)
        {
            string inputString = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            string outputString = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";
            for (int i = 0; i < inputString.Length; i++)
                text = text.Replace(inputString[i].ToString(), outputString[i].ToString());
            return text;
        }

        /// <summary>
        /// Remove Espaços e Caracteres Inválidos
        /// </summary>
        /// <param name="text"></param>
        /// <param name="flag"></param>
        /// <returns>Nome Limpo Para Inserção</returns>
        public static String ThugLife(this String text, string flag)
        {
            string outputString = "";
            if (flag == "file")
                outputString = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-_ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç."; //file
            else
                outputString = "0123456789 ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzºª/|-_ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç."; //description

            string novo = "";
            for (int i = 0; i < text.Length; i++)
            {
                for (int x = 0; x < outputString.Length; x++)
                {
                    if (text[i] == outputString[x])
                    {
                        novo += text[i].ToString();
                        break;
                    }
                }
            }
            return novo;
        }

        /// <summary>
        /// Método que formata o nome retirando espaços em branco do meio do nome
        /// </summary>
        /// <param name="text">Texto a ser tratado</param>
        /// <returns>Retorna o nome formatado corretamente</returns>
        public static String FormatName(this String text)
        {
            if (text == null || text == String.Empty)
                return "";

            string[] nameArray = text.Split(' ');
            string nameNew = "";
            foreach (var item in nameArray)
                nameNew += (" " + item).TrimEnd();

            return nameNew.Trim();
        }

        /// <summary>
        /// Método que verifica se um texto é nulo. Já usa o Trim
        /// </summary>
        /// <param name="text">Texto a ser verificado</param>
        /// <returns>Retorna se é nulo ou não</returns>
        public static Boolean IsNullOrEmpty(this String text)
        {
            try
            {
                if (text == null)
                    return true;

                return String.IsNullOrEmpty(text.Trim());
            }
            catch { throw new Exception(String.Format("O valor informado não é um valor texto válido! Valor informado: '{0}'", text)); }
        }

        /// <summary>
        /// Método que verifica se uma Data é valida (PT-Br)
        /// </summary>
        /// <param name="texto">Texto a ser verificado</param>
        /// <returns>Retorna se é uma Data ou não</returns>
        public static Boolean IsData(this String texto)
        {
            try
            {
                if (texto == null)
                    return false;

                string[] format = new string[] { "dd/MM/yyyy" };
                DateTime datetime;

                if (DateTime.TryParseExact(texto, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime))
                    return true;
                else
                    return false;
            }
            catch { throw new Exception(String.Format("O valor informado não é uma data válida! Valor informado: '{0}'", texto)); }
        }

        /// <summary>
        /// Método que verifica se a string é um Número Inteiro
        /// </summary>
        /// <param name="texto">Texto a ser verificado</param>
        /// <returns>Retorna se é Inteiro ou não</returns>
        public static Boolean IsInt(this String texto)
        {
            try
            {
                if (texto == null)
                    return false;

                int i = 0;
                bool resultado = int.TryParse(texto, out i); //i now = 108  

                return resultado;

            }
            catch { throw new Exception(String.Format("O valor informado não é uma data válida! Valor informado: '{0}'", texto)); }
        }


        /// <summary>
        /// Coloca os traços no documento informado
        /// </summary>
        /// <param name="cpfcnpj">CPF ou CNPJ - Pode ser com pontos já ou não</param>
        /// <param name="colocaDescricao">Se é pra aparecer CPF ou CNPJ</param>
        /// <returns></returns>
        public static string FormatarCPFCNPJ(this string cpfcnpj, bool colocaDescricao = false)
        {
            try
            {
                var tmp = cpfcnpj.ClearString();

                if (tmp.Length == 14)
                    return (colocaDescricao ? "CNPJ: " : "") + Convert.ToUInt64(tmp).ToString(@"00\.000\.000\/0000\-00");
                else if (tmp.Length == 11)
                    return (colocaDescricao ? "CPF: " : "") + Convert.ToUInt64(tmp).ToString(@"000\.000\.000\-00");
                else
                    return (colocaDescricao ? "CPF/CNPJ: " : "") + cpfcnpj;
            }
            catch { return (colocaDescricao ? "CPF/CNPJ: " : "") + cpfcnpj; }
        }
        /// <summary>
        /// Coloca os traços no documento informado
        /// </summary>
        /// <param name="cep">Cep desejado - Pode ser com pontos já ou não</param>
        /// <returns></returns>
        public static string FormatarCEP(this string cep)
        {
            try
            {
                var tmp = cep.ClearString();

                if (tmp.Length == 8)
                    return Convert.ToUInt64(tmp).ToString(@"00000\-000");
                else
                    return cep;
            }
            catch { return cep; }
        }

        /// <summary>
        /// Coloca os traços no documento informado
        /// </summary>
        /// <param name="telefone">Telefone - Pode ser com pontos já ou não</param>
        /// <returns></returns>
        public static string FormatarTelefone(this string telefone)
        {
            try
            {
                var tmp = telefone.ClearString();

                if (tmp.Length == 9 || tmp.Length == 11)
                    return Convert.ToUInt64(tmp).ToString(@"00\ 00000\-0000");
                else if (tmp.Length == 8 || tmp.Length == 10)
                    return Convert.ToUInt64(tmp).ToString(@"00\ 0000\-0000");
                else
                    return telefone;
            }
            catch { return telefone; }
        }

        public static string Truncate(this string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }

        public static string CreateCSVTextFile<T>(this List<T> data)
        {
            var properties = typeof(T).GetProperties();
            var result = new StringBuilder();

            foreach (var row in data)
            {
                var values = properties.Select(p => p.GetValue(row, null)).Select(v => StringToCSVCell(Convert.ToString(v)));
                var line = string.Join(";", values);
                result.AppendLine(line);
            }

            return result.ToString();
        }

        private static string StringToCSVCell(string str)
        {
            bool mustQuote = (str.Contains(";") || str.Contains("\"") || str.Contains("\r") || str.Contains("\n"));
            if (mustQuote)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("\"");
                foreach (char nextChar in str)
                {
                    sb.Append(nextChar);
                    if (nextChar == '"')
                        sb.Append("\"");
                }
                sb.Append("\"");
                return sb.ToString();
            }

            return str;
        }

        /// <summary>
        /// Verifica se existem  número na string
        /// </summary>
        /// <param name="str">valor</param>
        /// <returns>True ou False</returns>
        public static Boolean ExisteNumero(this string str)
        {
            if (str.Where(c => char.IsNumber(c)).Count() > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verifica se existem  letra na string
        /// </summary>
        /// <param name="str">valor</param>
        /// <returns>True ou False</returns>
        public static Boolean ExisteLetra(this string str)
        {
            if (str.Where(c => char.IsLetter(c)).Count() > 0)
                return true;
            else
                return false;
        }

        public static string SalvarImagemPost(HttpPostedFileBase arquivo)
        {
            string destino = @"\Content\Blog\Postagens\Imagens";            
            string guid = Guid.NewGuid().ToString("N");

            string caminhoFisico = HttpContext.Current.Server.MapPath(destino);
            string fileExtension = Path.GetExtension(arquivo.FileName);

            string newFileName = guid + fileExtension;

            if (!Directory.Exists(caminhoFisico))
            {
                Directory.CreateDirectory(caminhoFisico);
            }

            string filePath = Path.Combine(caminhoFisico, newFileName);

            arquivo.SaveAs(filePath);

            return newFileName;
        }

        public static void DeletarImagemPost(string nomeArquivo)
        {
            string caminhoFisico = HttpContext.Current.Server.MapPath("~/Content/Blog/Postagens/Imagens");
            string filePath = Path.Combine(caminhoFisico, nomeArquivo);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public static int ContarPalavras(string texto)
        {
            string[] palavras = texto.Split(new char[] { ' ', '\t', '\n', '\r', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            return palavras.Length;
        }
        public static string CalcularTempoLeituraEstimado(int numeroPalavras)
        {
            if (numeroPalavras <= 0)
            {
                throw new ArgumentException("Número de palavras e média de palavras por minuto devem ser maiores que zero.");
            }
            
            double minutosEstimados = (double)numeroPalavras / 180;
            TimeSpan tempoEstimado = TimeSpan.FromMinutes(minutosEstimados);

            string tempoEstimadoString = "";

            if (tempoEstimado.Hours > 0)
            {
                tempoEstimadoString += $"{tempoEstimado.Hours} {(tempoEstimado.Hours == 1 ? "hora" : "horas")}";
            }

            if (tempoEstimado.Minutes > 0)
            {
                if (!string.IsNullOrEmpty(tempoEstimadoString))
                    tempoEstimadoString += ", ";

                tempoEstimadoString += $"{tempoEstimado.Minutes} {(tempoEstimado.Minutes == 1 ? "minuto" : "minutos")}";
            }


            return tempoEstimadoString + " de leitura";
        }
    }
}