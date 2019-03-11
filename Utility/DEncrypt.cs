using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Commission.Utility
{
    class DEncrypt
    {
        static string defultKey = "CC780419";
  
        #region  ========加密========
        public static string Encrypt(string sString) 
		{
			return Encrypt(sString,defultKey);
		}

        /// <summary>
        /// 进行DES加密。
        /// </summary>
        /// <param name="sString">要加密的字符串。</param>
        /// <param name="sKey">密钥，且必须为8位。</param>
        /// <returns>以Base64格式返回的加密字符串。</returns>
        public static string Encrypt(string sString, string sKey)
        {
            if ("".Equals(sString))
                return "";
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = Encoding.UTF8.GetBytes(sString);
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Convert.ToBase64String(ms.ToArray());
                ms.Close();
                return str;
            }
        }

        #endregion



        #region ========解密========
        public static string Decrypt(string sString) 
		{
			return Decrypt(sString,defultKey);
		}

        /// <summary>
        /// 进行DES解密。
        /// </summary>
        /// <param name="sString">要解密的以Base64</param>
        /// <param name="sKey">密钥，且必须为8位。</param>
        /// <returns>已解密的字符串。</returns>
        public static string Decrypt(string sString, string sKey)
        {
            byte[] inputByteArray;
            if ("".Equals(sString))
                return "";
            try
            {
                inputByteArray = Convert.FromBase64String(sString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return str;
            }
        }

        #endregion
    }
}
