using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private PlayerInput playerInput;
    public IInteractable iShkaf;
    public IInteractable iPc;
    public IInteractable ibath;
    public IInteractable iBed;
    public GameObject shkav;
    public GameObject pc;
    public GameObject bath;
    public GameObject bed;


    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        iShkaf = shkav.GetComponent<IInteractable>();
        iPc = pc.GetComponent<IInteractable>();
        ibath = bath.GetComponent<IInteractable>();
        iBed = bed.GetComponent<IInteractable>();
    }

    void Update()
    {
        if (PlayerInput.playerInputUse.WasPressedThisFrame())
        {
            TryInteract();
        }
    }

    private void TryInteract()
    {
        iShkaf.Interact();
        iPc.Interact();
        ibath.Interact();
        iBed.Interact();
    }
}