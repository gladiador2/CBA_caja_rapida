using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace CBA.FlowV2.Services.Base
{
    //Funcionalidades extraidas de la siguiente URL. Utiliza el algoritmo simetrico AES
    //https://tekeye.uk/visual_studio/encrypt-decrypt-c-sharp-string
    //Don't forget the using System.Security.Cryptography; statement when you add this class
    public static class EncriptarService
    {
        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        private const string initVector = "nlQ97VJPEycHnK3s";
        // This constant is used to determine the keysize of the encryption algorithm
        private const int keysize = 256;

        public static string Encriptar(string texto_plano)
        {
            return Encriptar(texto_plano, VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.ContrasenhaEncriptacion));
        }

        public static string Encriptar(string texto_plano, string contrasena)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(texto_plano);
            PasswordDeriveBytes password = new PasswordDeriveBytes(contrasena, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Desencriptar(string texto_cifrado)
        {
            return Desencriptar(texto_cifrado, VariablesSistemaEntidadService.GetValorString(Definiciones.VariablesDeSistema.ContrasenhaEncriptacion));
        }

        public static string Desencriptar(string texto_cifrado, string contrasena)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(texto_cifrado);
            PasswordDeriveBytes password = new PasswordDeriveBytes(contrasena, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
    }

}
