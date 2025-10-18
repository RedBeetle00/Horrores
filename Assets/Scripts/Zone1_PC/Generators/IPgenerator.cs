using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;


[System.Serializable]
public class IPsData
{
    public string generationTime;
    public List<string> ipAddresses;
}

public class IPgenerator : MonoBehaviour
{
    private System.Random random = new System.Random();

    public void GenerateNsaveIPs()
    {
        IPsData data = new IPsData();
        data.generationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        data.ipAddresses = new List<string>();
        Debug.Log($"{data.generationTime}");

        for (int i = 0; i < 16; i++)
        {
            string ip = $"{random.Next(1, 255)}.{random.Next(0, 256)}.{random.Next(0, 256)}.{random.Next(1, 255)}";
            data.ipAddresses.Add(ip);
            Debug.Log($"IP {i+1}: {ip}");

            SaveToJson(data);
        }
    }

    private void SaveToJson(IPsData data)
    {
        string json = JsonUtility.ToJson(data, true);
        string filePath = Path.Combine(Application.persistentDataPath, "generated_ips.json");
        Debug.Log($"{filePath}");
        
        File.WriteAllText(filePath, json);
    }

}
