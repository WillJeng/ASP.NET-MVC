using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Runtime.Intrinsics.Arm;

namespace BussinessService.Service
{
    public static class PwdService
    {
        public static string PwdSHA256Hash(string pwdstr, string salt)
        {
            //建立一個空值字串
            var result = string.Empty;
            using (var sha256 = new SHA256CryptoServiceProvider())
            {
                //將字串編碼成UTF8 bytes[]
                var bytes = Encoding.UTF8.GetBytes(pwdstr + salt.ToUpper());
                //取得雜湊值bytes[]
                var hash = sha256.ComputeHash(bytes);
                //在轉成base64 string
                result = Convert.ToBase64String(hash);
            }
            return result;
        }
    }
}
