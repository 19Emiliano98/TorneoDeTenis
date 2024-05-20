using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces.User
{
    public interface IEncryptionService
    {
        public string Encrypt(string name);
        public string Decrypt(string name);
    }
}
