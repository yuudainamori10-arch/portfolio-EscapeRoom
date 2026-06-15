using UnityEngine;

public class BoxLidStateManagement : MonoBehaviour, IResetInterface
{
    public static BoxLidStateManagement boxLidStateManagementInstance;
    Animator animator;

    private void Awake()
    {
        if (boxLidStateManagementInstance is null)
        {
            boxLidStateManagementInstance = this;
        }
        animator = GetComponent<Animator>();
    }

    public void InitialzedObject()
    {
        //” ‚Ì‚Ó‚½‚ð•Â‚¶‚é
        animator.Play("Idle", 0, 0f);
    }

    public void OpenLid()
    {
        animator.Play("OpenLid", 0);
    }
}
