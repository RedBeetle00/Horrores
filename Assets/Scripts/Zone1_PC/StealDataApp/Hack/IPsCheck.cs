using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using Common;

public class IPsCheck : MonoBehaviour
{
    public InputField InputIP;

    private IPsData IPs_Data;
    private IPgenerator IP_generator;
    private static string CurrentIP;

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
                CommonVar.FirstIPreached = true;
                Debug.Log($"{CommonVar.FirstIPreached}");
            }
            else
            {
                Debug.Log($"{CommonVar.FirstIPreached}");
            }
            if (IPs_Data.ipAddresses.Count > 0 && IPs_Data.ipAddresses[1] == CurrentIP)
            {
                CommonVar.SecondIPreached = true;
                Debug.Log($"{CommonVar.SecondIPreached}");
            }
            else
            {
                Debug.Log($"{CommonVar.SecondIPreached}");
            }
            if (IPs_Data.ipAddresses.Count > 0 && IPs_Data.ipAddresses[2] == CurrentIP)
            {
                CommonVar.ThirdIPreached = true;
                Debug.Log($"{CommonVar.ThirdIPreached}");
            }
            else
            {
                Debug.Log($"{CommonVar.ThirdIPreached}");
            }
            if (IPs_Data.ipAddresses.Count > 0 && IPs_Data.ipAddresses[3] == CurrentIP)
            {
                CommonVar.FourthIPreached = true;
                Debug.Log($"{CommonVar.FourthIPreached}");
            }
            else
            {
                Debug.Log($"{CommonVar.FourthIPreached}");
            }
        }
        else
        {
            Debug.LogError("Файл с IP-адресами не найден!");
        }
    }
}
