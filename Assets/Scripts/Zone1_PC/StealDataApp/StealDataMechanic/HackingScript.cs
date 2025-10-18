using UnityEngine;
using UnityEngine.UI;

public class HackingScript : MonoBehaviour
{
    public InputField InputIP;
    
    private IPsData IPsDatA; // classes
    private IPgenerator IPgeneratoR;

    private static string IP_Input;

    public void checkIPs()
    {
        Debug.Log($"{IPsDatA.ipAddresses.Count}");

    }
    
}
