using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class RestRoomDoorOpen : MonoBehaviour, IResetInterface
{
    Animator animator;
    public static RestRoomDoorOpen openInstance;
    private bool openEnableFlag = true; //ドアが閉まっているときをtrue、開いているときをfalse
    private void Awake()
    {
        if (openInstance is null)
        {
            openInstance = this;
        }

        animator = GetComponent<Animator>();
    }

    public void ExcecuteDoorAction()
    {
        if (openEnableFlag)
        {
            Debug.Log("ドアを開けます");
            animator.Play("OpenDoorAnimation", 0);
            openEnableFlag = false;
        }
        else
        {
            Debug.Log("ドアを閉めます");
            animator.Play("CloseDoorAnimation", 0);
            openEnableFlag = true;
        }
    }

    public void InitialzedObject()
    {
        openEnableFlag = true;
        animator.Play("CloseDoorAnimation", 0);
    }
}
