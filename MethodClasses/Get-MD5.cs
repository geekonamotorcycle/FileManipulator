using FileManipulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileManipulator
{
    internal class Get_MD5 : IGet_MD5
    {
        public string FilePath { get; set; } = string.Empty;
        public string MD5Value { get; private set; } = string.Empty;

        public Get_MD5(string FilePath)
        {
            this.FilePath = FilePath;
            ReturnMD5();
        }

        private void ReturnMD5()
        {

            MD5 md5 = MD5.Create();
            var stream = File.OpenRead(FilePath);
            MD5Value = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
            stream.Close();
            md5.Clear();
        }
    }
}
