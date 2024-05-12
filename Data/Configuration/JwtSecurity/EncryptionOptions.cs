using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtSecurity
{
    public  class EncryptionOptions
    {
        public static string Section = "Application:Encryption";
        public string EncryptionKey { get; set; }
    }
}
