using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class IPsCheck : MonoBehaviour
{
    public InputField InputIP;

    private IPsData IPs_Data;
    private IPgenerator IP_generator;
    private static string CurrentIP;

    private static bool FirstIPreached;
    private static bool SecondIPreached;
    private static bool ThirdIPreached;
    private static bool FourthIPreached;

    public void GetUserIP()
    {
        CurrentIP = InputIP.text;
        Debug.Log($"{CurrentIP}");
    }

    public void CheckMatchesIP()
    {
        // Загружаем данные из JSON файла
        string filePath = System.IO.Path.Combine(Application.persistentDataPath, "generated_ips.json");
        if (System.IO.File.Exists(filePath))
        {
            string json = System.IO.File.ReadAllText(filePath);
            IPs_Data = JsonUtility.FromJson<IPsData>(json);
            
            // Проверяем совпадение с ПЕРВЫМ IP в списке
            if (IPs_Data.ipAddresses.Count > 0 && IPs_Data.ipAddresses[0] == CurrentIP)
            {
                FirstIPreached = true;
                Debug.Log($"{FirstIPreached}");
            }
            else
            {
                Debug.Log($"{FirstIPreached}");
            }
            if (IPs_Data.ipAddresses.Count > 0 && IPs_Data.ipAddresses[1] == CurrentIP)
            {
                SecondIPreached = true;
                Debug.Log($"{SecondIPreached}");
            }
            else
            {
                Debug.Log($"{SecondIPreached}");
            }
            if (IPs_Data.ipAddresses.Count > 0 && IPs_Data.ipAddresses[2] == CurrentIP)
            {
                ThirdIPreached = true;
                Debug.Log($"{ThirdIPreached}");
            }
            else
            {
                Debug.Log($"{ThirdIPreached}");
            }
            if (IPs_Data.ipAddresses.Count > 0 && IPs_Data.ipAddresses[3] == CurrentIP)
            {
                FourthIPreached = true;
                Debug.Log($"{FourthIPreached}");
            }
            else
            {
                Debug.Log($"{FourthIPreached}");
            }
        }
        else
        {
            Debug.LogError("Файл с IP-адресами не найден!");
        }
    }
}
