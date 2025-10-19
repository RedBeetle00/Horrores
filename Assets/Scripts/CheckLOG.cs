using UnityEngine;
using UnityEngine.UI;
using Common;

public class CheckLOG : MonoBehaviour
{
    [SerializeField] public GameObject LogInSystem;
    [SerializeField] public GameObject HackingField;

    public void Checkc()
    {
        if (CommonVar.usedbefore == false)
        {
            LogInSystem.SetActive(true);
            HackingField.SetActive(false);
        }
        else
        {
            LogInSystem.SetActive(false);
            HackingField.SetActive(true);
        }
    }
}
