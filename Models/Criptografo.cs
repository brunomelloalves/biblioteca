using System;
using System.Security.Cryptography;
using System.Text;



namespace Biblioteca.Models
{
    public class Criptografo
    {
        public static string TextoCriptografado(string textoClaro){
            MD5 MDHasher = MD5.Create();
            byte[] By = Encoding.Default.GetBytes(textoClaro);
            byte[] bitesCriptografados = MDHasher.ComputeHash(By);

            StringBuilder SB = new StringBuilder();

            foreach(byte b in bitesCriptografados){
                string DebugB = b.ToString("x2");
                SB.Append(DebugB);
            }
            return SB.ToString();
        }
    }
}