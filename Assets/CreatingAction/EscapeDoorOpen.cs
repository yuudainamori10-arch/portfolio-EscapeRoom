using UnityEngine;

public class DoorOpen : MonoBehaviour, IResetInterface
{
    public static DoorOpen doorOpenInstance;
    Animator animator;
    Collider[] parentColliders;
    Collider[] colliders;

    private void Awake()
    {
        if (doorOpenInstance is null)
        {
            doorOpenInstance = this;
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        parentColliders = GetComponentsInParent<Collider>(); ;
        colliders = GetComponentsInChildren<Collider>();
    }

    public void OpenDoor()
    {
        //処理1_鍵が開いているかを確認
        if (ObjStateManager.managerInstance
            .HasFlag(ObjStateData.Type.UnlockedEscapeDoor.ToString()))
        {
            //処理2_脱出用ドアを開けるアニメーションを実行
            Debug.Log("OpenDoorメソッドを実行します");
            animator.Play("OpenDoorAnimation", 0);

            //ドアのあたり判定をなくす
            foreach (Collider col in colliders)
            {
                col.enabled = false;
            }
            foreach (Collider col in parentColliders)
            {
                col.enabled = false;
            }
        }
    }

    public void InitialzedObject()
    {
        animator.Play("CloseDoorAnimation", 0);

        //ドアのあたり判定を復活
        foreach (Collider col in colliders)
        {
            col.enabled = true;
        }
        foreach (Collider col in parentColliders)
        {
            col.enabled = true;
        }
    }
}
