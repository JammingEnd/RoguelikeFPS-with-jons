using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float JumpHeight;
    [SerializeField] private float SlideSpeed;
    [SerializeField] private float raycastDistance;

    private bool isSprinting;
    private bool isSliding;
    bool isJumping;
    private Rigidbody rb;

    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        if (!isSliding)
        {
            Move();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }
        else
        {
            if (isSprinting == true)
            {
                speed /= 1.6f;
                gameObject.GetComponentInChildren<Camera>().fieldOfView -= 20;
                isSprinting = false;
            }
        }
        if (Input.GetKey(KeyCode.C) && isJumping != true)
        {
            Sliding();
        }
        else
        {
            if (isSliding == true)
            {
                if(isSliding == true)
                {
                    gameObject.GetComponentInChildren<Camera>().fieldOfView -= 20;

                }

                isSliding = false;
                animator.SetBool("isSlidingAni", false);

            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    /// <summary>
    /// move in all 2d axis using unity build-in move input (wasd movement) and multiplies that with speed and a fixed update
    /// </summary>
    private void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed * Time.fixedDeltaTime;

        Vector3 newPosition = rb.position + rb.transform.TransformDirection(movement);
        rb.MovePosition(newPosition);
    }
    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
    private void Jump()
    {
        if(isJumping == false)
        {
            rb.AddForce(rb.transform.up * JumpHeight, ForceMode.Impulse);
        }
    }

    private void Run()
    {
        if (isSprinting == false)
        {
            speed *= 1.6f;
            gameObject.GetComponentInChildren<Camera>().fieldOfView += 20;
        }

        isSprinting = true;
    }

    private void Sliding()
    {
        animator.SetBool("isSlidingAni", true);

        if (isSliding == false)
        {
            //play sliding animation
            rb.AddForce(transform.forward * SlideSpeed, ForceMode.VelocityChange);
            gameObject.GetComponentInChildren<Camera>().fieldOfView += 20;
        }
        isSliding = true;
    }
}