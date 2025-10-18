using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

public class PcScript : MonoBehaviour
{
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (CommonVar.isUse)
        {
            SceneManager.LoadScene("PcScene");
        }
    }
}
