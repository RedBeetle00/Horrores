using UnityEngine;
using Common;

public class ShkafScript : MonoBehaviour
{
    private void Update()
    {
        if (CommonVar.isUse == false)
        {
            CommonVar.canMove = true;
            CommonVar.inShkaf = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (CommonVar.isUse == true)
        {
            CommonVar.canMove = false;
            CommonVar.inShkaf = true;
        }
    }
}