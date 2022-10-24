using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using TMPro;
using UnityEngine;

public class DecryptionManager : MonoBehaviour
{
    
    [SerializeField] private TMP_InputField _textField;
    private string _key;
    
    public void DecryptMessage()
    {
        _textField.text = DecryptString(_key, _textField.text);
    }

    public void SetKey(String key)
    {
        _key = key;
    }

    
    private string DecryptString(string key, string cipherText)  
    {
    
        byte[] iv = new byte[16];  
        byte[] buffer = Convert.FromBase64String(cipherText);

        using (Aes aes = Aes.Create())
        {
            aes.Key = CreateKey(key);
            aes.IV = iv;  
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);  
  
            using (MemoryStream memoryStream = new MemoryStream(buffer))  
            {  
                using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))  
                {  
                    using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))  
                    {  
                        return streamReader.ReadToEnd();  
                    }  
                }  
            }  
        }  
    } 
    
    private static byte[] CreateKey(string password, int keyBytes = 32)
    {
        const int Iterations = 300;
        var keyGenerator = new Rfc2898DeriveBytes(password, new byte[] { 10, 20, 30 , 40, 50, 60, 70, 80}, Iterations);
        return keyGenerator.GetBytes(keyBytes);
    }

}
