using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BaliServer.Controllers
{
    class StaticController
    {
        /// <summary>
        /// Hàm mã hóa tin gửi đi
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] Encoding(Object obj)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms,obj);
            return ms.ToArray();
        }

        /// <summary>
        /// Hàm giải mã các đoạn tin gửi về
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Object Decoding(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            BinaryFormatter bf = new BinaryFormatter();
            return bf.Deserialize(ms);
        }
    }
}
