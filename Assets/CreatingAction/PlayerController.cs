using UnityEngine;

public class PlayerController : MonoBehaviour, IResetInterface
{
    public static PlayerController playerControllerInstance;
    private Rigidbody rb;
    private Animator anime;
    public Transform cameraTransform;
    private float speed;
    Vector3 startPosition;
    Quaternion startRotation;

    const float maxSpeed = 3.0f;
    const float power = 1.5f;

    private void Awake()
    {
        if (playerControllerInstance is null)
        {
            playerControllerInstance = this;

            startPosition = transform.position;
            startRotation = transform.rotation;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anime = GetComponent<Animator>();
    }

    void Update()
    {
        //キーボードの入力を受け取るプログラム
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        //歩くアニメーションの起動・停止
        anime.SetFloat("verticalScore", vertical);
        anime.SetFloat("horizontalScore", horizontal);

        speed = rb.linearVelocity.magnitude;

        if (speed < maxSpeed)
        {
            Vector3 moveDir = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                moveDir += transform.forward;
            }
            
            if (Input.GetKey(KeyCode.S))
            {
                moveDir  -= transform.forward;
            }
            
            if(Input.GetKey(KeyCode.D))
            {
                moveDir += transform.right;
            }
            
            if(Input.GetKey(KeyCode.A))
            {
                moveDir -= transform.right;
            }

            moveDir.Normalize();

            if (moveDir != Vector3.zero)
            {
                rb.AddForce(moveDir * power, ForceMode.Acceleration);
            }
            else
            {
                //減速する際に1未満の値で色々と試してみたところ、
                //0.99fがキャラクターが自然に停止したと感じる速度だった。
                rb.linearVelocity *= 0.99f;
            }
        }
    }

    public void InitialzedObject()
    {
        // 速度を初期化
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // 位置と回転を初期化
        rb.position = startPosition;
        rb.rotation = startRotation;
    }
}
