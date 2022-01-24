using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using LitJson;
using UnityEngine.UI;
using System.Security.Cryptography;
using System.Text;

class Taiyaki_data
{
    public int[] taiyaki = new int[Data_base.Taiyaki.Length];
    public int[] Member = new int[Data_base.Battle_Member.Length];
    public Taiyaki_data()
    {
        for (int i = 0; i < taiyaki.Length; i++)
            taiyaki[i] = Data_base.Taiyaki[i];
        for (int i = 0; i < Member.Length; i++)
            Member[i] = Data_base.Battle_Member[i];
    }
}

public class Save_Load_Base : MonoBehaviour
{
    public void Save()
    {
        List<Taiyaki_data> td_list = new List<Taiyaki_data>();
        td_list.Add(new Taiyaki_data());
        JsonData Taiyaki_array = JsonMapper.ToJson(td_list);
        //Taiyaki_array = Encrypt(Taiyaki_array.ToString(), "tai");
        File.WriteAllText(Application.persistentDataPath + "/Taiyaki_array.json", Taiyaki_array.ToString());
        Debug.Log("Save Done");
    }

    public void Load()
    {
        FileInfo fil = new FileInfo(Application.persistentDataPath + "/Taiyaki_array.json");
        if (fil.Exists)
        {
            string str = File.ReadAllText(Application.persistentDataPath + "/Taiyaki_array.json");
            //str = Decrypt(str, "tai");
            JsonData Taiyaki_load = JsonMapper.ToObject(str);

            for (int i = 0; i < Data_base.Taiyaki.Length; i++)
                Data_base.Taiyaki[i] = (int)Taiyaki_load[0]["taiyaki"][i];

            for (int i = 0; i < Data_base.Battle_Member.Length; i++)
                Data_base.Battle_Member[i] = (int)Taiyaki_load[0]["Member"][i];
            Debug.Log("Load done");
        }
        else
        {
            Debug.Log("Load fail");
        }
    }




    public static string Decrypt(string textToDecrypt, string key)

    {

        RijndaelManaged rijndaelCipher = new RijndaelManaged();

        rijndaelCipher.Mode = CipherMode.CBC;

        rijndaelCipher.Padding = PaddingMode.PKCS7;



        rijndaelCipher.KeySize = 128;

        rijndaelCipher.BlockSize = 128;

        byte[] encryptedData = Convert.FromBase64String(textToDecrypt);

        byte[] pwdBytes = Encoding.UTF8.GetBytes(key);

        byte[] keyBytes = new byte[16];

        int len = pwdBytes.Length;

        if (len > keyBytes.Length)

        {

            len = keyBytes.Length;

        }

        Array.Copy(pwdBytes, keyBytes, len);

        rijndaelCipher.Key = keyBytes;

        rijndaelCipher.IV = keyBytes;

        byte[] plainText = rijndaelCipher.CreateDecryptor().TransformFinalBlock(encryptedData, 0, encryptedData.Length);

        return Encoding.UTF8.GetString(plainText);

    } //디코딩
    public static string Encrypt(string textToEncrypt, string key)

    {

        RijndaelManaged rijndaelCipher = new RijndaelManaged();

        rijndaelCipher.Mode = CipherMode.CBC;

        rijndaelCipher.Padding = PaddingMode.PKCS7;



        rijndaelCipher.KeySize = 128;

        rijndaelCipher.BlockSize = 128;

        byte[] pwdBytes = Encoding.UTF8.GetBytes(key);

        byte[] keyBytes = new byte[16];

        int len = pwdBytes.Length;

        if (len > keyBytes.Length)

        {

            len = keyBytes.Length;

        }

        Array.Copy(pwdBytes, keyBytes, len);

        rijndaelCipher.Key = keyBytes;

        rijndaelCipher.IV = keyBytes;

        ICryptoTransform transform = rijndaelCipher.CreateEncryptor();

        byte[] plainText = Encoding.UTF8.GetBytes(textToEncrypt);

        return Convert.ToBase64String(transform.TransformFinalBlock(plainText, 0, plainText.Length));

    } //인코딩
}
