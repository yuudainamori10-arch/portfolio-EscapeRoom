using UnityEngine;

public class DrawerOpen : MonoBehaviour, IResetInterface
{
    [SerializeField] private Transform drawer;
    public static DrawerOpen drawerOpenInstance;
    Animator animator;
    private bool openDrawerFlag = false;

    public Transform GetAnchor() => drawer;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        if (drawerOpenInstance is null)
        {
            drawerOpenInstance = this;
        }
    }

    public void OnClickDrawer()
    {
        animator.Play("DrawerOpen", 0);
        openDrawerFlag = true;
    }

    public void InitialzedObject()
    {
        //Drawer‚ð•Â‚¶‚é
        animator.Play("Idle", 0, 0f);
        openDrawerFlag = false;
    }

    public bool GetDrawerOpenFlag()
    {
        return openDrawerFlag;
    }
}