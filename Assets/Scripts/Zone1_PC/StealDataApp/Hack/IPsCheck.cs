// IPsCheck.cs
using UnityEngine;
using UnityEngine.UI;
using Common;

public class IPsCheck : MonoBehaviour
{
    public InputField InputIP;

    private IPsData IPs_Data => IPDataManager.GetIPsData();

    public void GetUserIP()
    {
        // Теперь IP обрабатывается напрямую из InputField
    }

    public void CheckMatchesIP()
    {
        string currentIP = InputIP.text;

        if (string.IsNullOrEmpty(currentIP))
        {
            Debug.LogError("IP input is empty!");
            return;
        }

        if (!IPDataManager.HasData())
        {
            Debug.LogError("No IPs data available!");
            return;
        }

        bool matchFound = false;

        for (int i = 0; i < IPs_Data.ipAddresses.Count; i++)
        {
            if (IPs_Data.ipAddresses[i] == currentIP)
            {
                SetIPReached(i);
                Debug.Log($"IP {i+1} matched: {currentIP}");
                matchFound = true;
                break;
            }
        }

        if (!matchFound)
        {
            Debug.Log($"No match found for IP: {currentIP}");
        }
    }

    private void SetIPReached(int index)
    {
        switch (index)
        {
            case 0: 
                CommonVar.FirstIPreached = true; 
                Debug.Log($"First IP reached: {CommonVar.FirstIPreached}");
                break;
            case 1: 
                CommonVar.SecondIPreached = true; 
                Debug.Log($"Second IP reached: {CommonVar.SecondIPreached}");
                break;
            case 2: 
                CommonVar.ThirdIPreached = true; 
                Debug.Log($"Third IP reached: {CommonVar.ThirdIPreached}");
                break;
            case 3: 
                CommonVar.FourthIPreached = true; 
                Debug.Log($"Fourth IP reached: {CommonVar.FourthIPreached}");
                break;
        }
        CommonVar.inDanger = true;
    }
}