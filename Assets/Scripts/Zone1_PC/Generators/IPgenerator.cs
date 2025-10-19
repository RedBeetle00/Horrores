// IPgenerator.cs
using UnityEngine;
using System;
using System.Collections.Generic;

public class IPgenerator : MonoBehaviour
{
    private System.Random random = new System.Random();

    public void GenerateNsaveIPs()
    {
        IPsData data = new IPsData();
        data.generationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        data.ipAddresses = new List<string>();
        
        Debug.Log($"Generating IPs at: {data.generationTime}");

        for (int i = 0; i < 4; i++)
        {
            string ip = GenerateInvalidIP();
            data.ipAddresses.Add(ip);
            Debug.Log($"IP {i+1}: {ip}");
        }
        
        IPDataManager.SaveIPsData(data);
    }

    private string GenerateInvalidIP()
    {
        string[] invalidPatterns = {
            $"{random.Next(256, 999)}.{random.Next(0, 256)}.{random.Next(0, 256)}.{random.Next(0, 256)}", // Первый октет > 255
            $"{random.Next(0, 256)}.{random.Next(256, 999)}.{random.Next(0, 256)}.{random.Next(0, 256)}", // Второй октет > 255
            $"{random.Next(0, 256)}.{random.Next(0, 256)}.{random.Next(256, 999)}.{random.Next(0, 256)}", // Третий октет > 255
            $"{random.Next(0, 256)}.{random.Next(0, 256)}.{random.Next(0, 256)}.{random.Next(256, 999)}", // Четвертый октет > 255
            $"{random.Next(0, 256)}.{random.Next(0, 256)}.{random.Next(0, 256)}.{random.Next(0, 256)}.{random.Next(1, 100)}", // 5 октетов
            $"{random.Next(0, 256)}.{random.Next(0, 256)}", // Только 2 октета
            $"{-random.Next(1, 100)}.{random.Next(0, 256)}.{random.Next(0, 256)}.{random.Next(0, 256)}", // Отрицательный октет
            $"{random.Next(0, 256)}.{random.Next(0, 256)}.{random.Next(0, 256)}.{-random.Next(1, 100)}", // Отрицательный последний октет
        };
        
        return invalidPatterns[random.Next(0, invalidPatterns.Length)];
    }
}
