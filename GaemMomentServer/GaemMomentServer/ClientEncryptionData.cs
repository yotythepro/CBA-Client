using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GaemMomentServer
{
    internal class ClientEncryptionData
    {
        public string PublicKey;
        public string PrivateKey;
        public string ClientPublicKey;
        public string AESKey;
        public string IV;
        public bool ConnectionInitialized = false;

        public ClientEncryptionData(string ClientPublicKey)
        {
            RSACryptoServiceProvider rsa = new();
            PrivateKey = Encryption.GetKeyString(rsa.ExportParameters(true));
            PublicKey = Encryption.GetKeyString(rsa.ExportParameters(false));
            this.ClientPublicKey = ClientPublicKey;
        }
    }
}
