using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using UnityEngine;

public class EncryptionManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _textField;
    private String _key;
    
    public void EncryptMessage()
    {
        _textField.text = EncryptString(_key, _textField.text);
    }
    
    public void SetKey(String key)
    {
        _key = key;
    }
    
    private string EncryptString(string key, string plainText)  
    {  
        byte[] iv = new byte[16];  
        byte[] array;  
        
        using (Aes aes = Aes.Create())
        {
            aes.Key = CreateKey(key);  
            aes.IV = iv;  
        
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);  
        
            using (MemoryStream memoryStream = new MemoryStream())  
            {  
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))  
                {  
                    using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))  
                    {  
                        streamWriter.Write(plainText);  
                    }  
        
                    array = memoryStream.ToArray();  
                }  
            }  
        }  
        
        return Convert.ToBase64String(array);  
        
        // using (var aes = new AesManaged())
        // {
        //     aes.Key = CreateKey(key);
        //     aes.Mode = CipherMode.ECB;
        //     byte[] bytes = Encoding.UTF8.GetBytes(plainText);
        //     using (var encryptor = aes.CreateEncryptor())
        //     {
        //         byte[] result = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
        //         return Encoding.ASCII.GetString(result);
        //     }
        // }
    }
    
    private static byte[] CreateKey(string password, int keyBytes = 32)
    {
        const int Iterations = 300;
        var keyGenerator = new Rfc2898DeriveBytes(password, new byte[] { 10, 20, 30 , 40, 50, 60, 70, 80}, Iterations);
        return keyGenerator.GetBytes(keyBytes);
    }

}
