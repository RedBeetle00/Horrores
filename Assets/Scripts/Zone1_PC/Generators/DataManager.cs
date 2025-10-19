// IPDataManager.cs
using UnityEngine;
using System.IO;
using System.Collections.Generic;

public static class IPDataManager
{
    private static IPsData _cachedData;
    private static string _filePath => Path.Combine(Application.persistentDataPath, "generated_ips.json");

    public static IPsData GetIPsData()
    {
        if (_cachedData == null)
        {
            LoadIPsData();
        }
        return _cachedData;
    }

    public static void SaveIPsData(IPsData data)
    {
        _cachedData = data;
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(_filePath, json);
        Debug.Log($"IPs data saved to: {_filePath}");
    }

    private static void LoadIPsData()
    {
        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);
            _cachedData = JsonUtility.FromJson<IPsData>(json);
            Debug.Log("IPs data loaded from file");
        }
        else
        {
            _cachedData = new IPsData() { 
                generationTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                ipAddresses = new List<string>() 
            };
            Debug.Log("Created new IPs data");
        }
    }

    public static void ClearCache()
    {
        _cachedData = null;
    }

    public static bool HasData()
    {
        return _cachedData != null && _cachedData.ipAddresses != null && _cachedData.ipAddresses.Count > 0;
    }
}