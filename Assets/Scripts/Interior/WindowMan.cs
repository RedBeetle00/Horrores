using UnityEngine;
using Common;
public class WindowMan : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
        if (CommonVar.isUse)
        {
            ManWindow();
        }
    }
    public void ManWindow()
    {
        spriteRenderer.enabled = true;
    }
}