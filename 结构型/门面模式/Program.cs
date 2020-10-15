using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 门面模式
{
    class Program
    {
        /*
         * 外观（Facade）模式：外部与一个子系统的通信通过一个统一的外观角色进行，为子系统中的一组接口提供一个一致的入口，
         * 外观模式定义了一个高层接口，这个接口使得这一子系统更加容易使用。
         */

        /// <summary>
        /// 文件读取类：子系统A
        /// </summary>
        public class FileReader
        {
            public string Read(string fileNameSrc)
            {
                Console.WriteLine("读取文件，获取明文：");
                string result = string.Empty;
                using (System.IO.FileStream fsRead = new System.IO.FileStream(fileNameSrc, System.IO.FileMode.Open))
                {
                    int fsLen = (int)fsRead.Length;
                    byte[] heByte = new byte[fsLen];
                    int r = fsRead.Read(heByte, 0, heByte.Length);
                    result = System.Text.Encoding.UTF8.GetString(heByte);
                }

                return result;
            }
        }

        /// <summary>
        /// 数据加密类：子系统B
        /// </summary>
        public class CipherMachine
        {
            public string Encrypt(string plainText)
            {
                Console.WriteLine("数据加密，将明文转换为密文：");
                StringBuilder result = new StringBuilder();

                for (int i = 0; i < plainText.Length; i++)
                {
                    string ch = Convert.ToString(plainText[i] % 7);
                    result.Append(ch);
                }

                string encryptedResult = result.ToString();
                Console.WriteLine(encryptedResult);
                return encryptedResult;
            }
        }

        /// <summary>
        /// 文件保存类：子系统C
        /// </summary>
        public class FileWriter
        {
            public void Write(string encryptedStr, string fileNameDes)
            {
                Console.WriteLine("保存密文，写入文件：");
                byte[] myByte = System.Text.Encoding.UTF8.GetBytes(encryptedStr);
                using (System.IO.FileStream fsWrite = new System.IO.FileStream(fileNameDes, System.IO.FileMode.Append))
                {
                    fsWrite.Write(myByte, 0, myByte.Length);
                };

                Console.WriteLine("写入文件成功：100%");
            }
        }

        public class EncryptFacade
        {
            private FileReader reader;
            private CipherMachine cipher;
            private FileWriter writer;

            public EncryptFacade()
            {
                reader = new FileReader();
                cipher = new CipherMachine();
                writer = new FileWriter();
            }

            public void FileEncrypt(string fileNameSrc, string fileNameDes)
            {
                string plainStr = reader.Read(fileNameSrc);
                string encryptedStr = cipher.Encrypt(plainStr);
                writer.Write(encryptedStr, fileNameDes);
            }
        }

        static void Main(string[] args)
        {
            EncryptFacade facade = new EncryptFacade();
            facade.FileEncrypt("Facade/src.txt", "Facade/des.txt");

            Console.ReadKey();
        }
    }
}
