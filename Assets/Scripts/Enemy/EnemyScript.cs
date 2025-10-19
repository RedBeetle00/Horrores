using UnityEngine;
using Common;

public class EnemyScript : MonoBehaviour
{
    private int timer;
    public SpriteRenderer sp;

    private void FixedUpdate()
    {
        timer += 1;
        Debug.Log(timer);
        ShowEnemy();
    }

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.enabled = false;
    }

    private void ShowEnemy()
    {
        if (timer > 100)
        {
            sp.enabled = true;
            if (!CommonVar.inBed && !CommonVar.inShkaf && !CommonVar.inBath)
            {
                Debug.Log("You Dead");
            }
        }
    }
}