using System;

namespace oracleuuid.Converters
{
    public static class UuIdConverter
    {
        public static string ConvertFromString(FromType type, string value)
        {
            try
            {
                return type switch
                {
                    FromType.FromHex => value.OracleToDotNet(),
                    FromType.FromUuId => value.DotNetToOracle(),
                    _ => throw new NotImplementedException()
                };
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static bool TryParseType(string commandValue, out FromType type)
        {
            var command = commandValue.Trim();
            switch (command)
            {
                case "-h":
                    type = FromType.FromHex;
                    return true;
                case "-g":
                    type = FromType.FromUuId;
                    return true;
                default:
                    type = 0;
                    return false;
            }
        }
    }
}