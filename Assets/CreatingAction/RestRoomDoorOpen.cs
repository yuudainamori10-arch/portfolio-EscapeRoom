using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class RestRoomDoorOpen : MonoBehaviour, IResetInterface
{
    Animator animator;
    public static RestRoomDoorOpen openInstance;
    private bool openEnableFlag = true; //ドアが閉まっているときをtrue、開いているときをfalse
    Collider[] parentColliders;
    Collider[] colliders;

    private void Awake()
    {
        if (openInstance is null)
        {
            openInstance = this;
        }

        animator = GetComponent<Animator>();
        parentColliders = GetComponentsInParent<Collider>(); ;
        colliders = GetComponentsInChildren<Collider>();
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
