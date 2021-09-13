using System.Collections;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float JumpHeight;
    [SerializeField] private float SlideSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float raycastDistance;

    private bool isSprinting;
    private bool isSliding;
    private bool isJumping;
    private bool canMove;
    private bool isClimbing, cancelClimb;
    private float fov;
    private Rigidbody rb;
    private Camera playerCam;
    private Animator animator;

    
    private bool hasFovAdd;

    private void Start()
    {
        canMove = true;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerCam = gameObject.GetComponentInChildren<Camera>();
        fov = playerCam.fieldOfView;
    }
    public void AssignVariables(float _speed, float _jumpHeight, float slideDistance, float _sprintSpeed)
    {
        speed = _speed;
        JumpHeight = _jumpHeight;
        SlideSpeed = slideDistance;
        sprintSpeed = 1.6f * Mathf.Sqrt(_sprintSpeed);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping)
            {
                Jump();
            }
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }
        else
        {
            if (isSprinting == true)
            {
                speed /= sprintSpeed;
                playerCam.fieldOfView -= 20;
                isSprinting = false;
            }
        }
        SlideUpdate();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void SlideUpdate()
    {
        if (Input.GetKeyDown(KeyCode.C) && isJumping != true)
        {
            Sliding();

            canMove = false;
            // isSliding = false;
        }
        else
       

        if (Input.GetKey(KeyCode.C))
        {
            isSliding = true;
            cancelClimb = true;
        }
        else
        {
            cancelClimb = false;
        }
        if (Input.GetKeyUp(KeyCode.C) && isSliding == true)
        {
            canMove = true;
            StartCoroutine(Cooldown(2));
            if (!hasFovAdd)
            {
                Debug.Log("add");

                playerCam.fieldOfView += 20;
            }
            hasFovAdd = true;

            animator.SetBool("isSlidingAni", false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            isClimbing = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            canMove = false;
            rb.useGravity = false;
            isJumping = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            canMove = true;
            rb.useGravity = true;
            isClimbing = false;

        }
    }

    private IEnumerator Cooldown(float amount)
    {
        while (isSliding == true)
        {
            isSliding = true;
            yield return new WaitForSeconds(amount);
            isSliding = false;

            StopAllCoroutines();
            yield break;
        }
    }

    /// <summary>
    /// move in all 2d axis using unity build-in move input (wasd movement) and multiplies that with speed and a fixed update
    /// </summary>
    private void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");
        if (canMove)
        {

            Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed * Time.fixedDeltaTime;

            Vector3 newPosition = rb.position + rb.transform.TransformDirection(movement);
            rb.MovePosition(newPosition);
        }
        if (!canMove && isSliding != true)
        {
           
            Vector3 movementUp = new Vector3(hAxis, vAxis, 0) * speed * Time.fixedDeltaTime;

            Vector3 newPositionUp = rb.position + rb.transform.TransformDirection(movementUp);
            rb.MovePosition(newPositionUp);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }

    private void Jump()
    {
        isJumping = true;
        if (!isClimbing)
        {
            rb.AddForce(transform.up * JumpHeight, ForceMode.Impulse);

        }
        if (isClimbing)
        {
            if (!Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, 1, 9))
            {
                rb.AddForce(transform.forward * JumpHeight, ForceMode.Impulse);
            }
            rb.AddForce(transform.up * JumpHeight, ForceMode.Impulse);
        }
    }

    private void Run()
    {
        if (isSprinting == false)
        {
            speed *= sprintSpeed;
            playerCam.fieldOfView += 20;
        }

        isSprinting = true;
    }

    private void Sliding()
    {
        animator.SetBool("isSlidingAni", true);
        if (isSliding == false)
        {
            //play sliding animation
            if(canMove == true)
            {
                rb.AddForce(transform.forward * SlideSpeed, ForceMode.VelocityChange);

                playerCam.fieldOfView -= 20;
                Debug.Log("remove");
                hasFovAdd = false;
            }
           
            isSliding = true;
        }
    }
}