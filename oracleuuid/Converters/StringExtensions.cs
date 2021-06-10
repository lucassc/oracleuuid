using System;

namespace oracleuuid.Converters
{
    public static class StringExtensions
    {
        public static string OracleToDotNet(this string text)
        {
            var bytes = ParseHex(text);
            var guid = new Guid(bytes);
            return guid.ToString();
        }

        public static string DotNetToOracle(this string text)
        {
            var guid = new Guid(text);
            return BitConverter.ToString(guid.ToByteArray()).Replace("-", "");
        }

        private static byte[] ParseHex(string text)
        {
            var ret = new byte[text.Length / 2];
            for (var i = 0; i < ret.Length; i++)
            {
                ret[i] = Convert.ToByte(text.Substring(i * 2, 2), 16);
            }

            return ret;
        }
    }
}