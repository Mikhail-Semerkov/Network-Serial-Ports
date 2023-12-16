using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_Serial_Ports
{
    public class ToolModel
    {
        private byte[] FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                try
                {
                    raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
                }
                catch (System.Exception)
                {
                    //Do Nothing
                }

            }
            return raw;
        }

        public String Hex2String(String hex)
        {
            byte[] data = FromHex(hex);
            return Encoding.Default.GetString(data);
        }

        public String String2Hex(String str)
        {
            Byte[] data = Encoding.Default.GetBytes(str);
            return BitConverter.ToString(data);
        }

        public Byte[] Hex2Bytes(String hex)
        {
            return FromHex(hex);
        }

        public String Bytes2Hex(Byte[] bytes)
        {
            return BitConverter.ToString(bytes);
        }

    }
}
