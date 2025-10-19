using UnityEngine;
using Common;
using System.Collections;

public class InDanger : MonoBehaviour
{
    [SerializeField] public GameObject InDangerObject;

    // Update is called once per frame
    void Update()
    {
        if (CommonVar.inDanger)
            InDangerObject.SetActive(true);
        else
        {
            InDangerObject.SetActive(false);
        }
    }
}
