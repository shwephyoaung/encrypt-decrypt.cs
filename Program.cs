using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string inputFile = "test.txt";
        string encryptedFile = "encrypted.txt";
        string decryptedFile = "decrypted.txt";

        string key = "abcdefghijklmnopqrstuvwxyz"; // Replace with your own secret key

        EncryptFile(inputFile, encryptedFile, key);
        DecryptFile(encryptedFile, decryptedFile, key);

        Console.WriteLine(EncryptText(encryptedFile, key));
        Console.WriteLine(DecryptText(decryptedFile, key));
        
        Console.WriteLine("Encryption and decryption completed successfully.");

    }

    static void EncryptFile(string inputFile, string encryptedFile, string key)
    {
        string content = File.ReadAllText(inputFile);
        string encryptedContent = EncryptText(content, key);
        File.WriteAllText(encryptedFile, encryptedContent);
    }

    static void DecryptFile(string encryptedFile, string decryptedFile, string key)
    {
        string encryptedContent = File.ReadAllText(encryptedFile);
        string decryptedContent = DecryptText(encryptedContent, key);
        File.WriteAllText(decryptedFile, decryptedContent);
    }

    static string EncryptText(string input, string key)
    {
        StringBuilder encryptedText = new StringBuilder();

        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                char encryptedChar = key[(char.ToLower(c) - 'a') % key.Length];
                if (char.IsUpper(c))
                    encryptedChar = char.ToUpper(encryptedChar);

                encryptedText.Append(encryptedChar);
            }
            else
            {
                encryptedText.Append(c);
            }
        }

        return encryptedText.ToString();
    }

    static string DecryptText(string input, string key)
    {
        StringBuilder decryptedText = new StringBuilder();

        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                char decryptedChar = key[(char.ToLower(c) - 'a' + key.Length) % key.Length];
                if (char.IsUpper(c))
                    decryptedChar = char.ToUpper(decryptedChar);

                decryptedText.Append(decryptedChar);
            }
            else
            {
                decryptedText.Append(c);
            }
        }

        return decryptedText.ToString();
    }
}






