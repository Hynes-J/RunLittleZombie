using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed, horizontalSpeed, jumpForce;

    float horizontalInput, verticalInput;
    private int layerMask;
    [SerializeField]
    private LayerMask groundMask;

    private Animator anim;

    Rigidbody rb;

    private bool isAlive = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        layerMask = 1 << 3;

    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.gameRunning)
        {
            return;
        }


        if (GameManager.Instance)
        {
            speed += GameManager.Instance.gameSpeed;

        }

        Vector3 verticalMovement = transform.forward * -verticalInput * horizontalSpeed * Time.fixedDeltaTime;

        Vector3 forwardMovement = Vector3.zero;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1f, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            forwardMovement = Vector3.zero;

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            forwardMovement = transform.forward * speed * Time.fixedDeltaTime;


        }

        Vector3 horizontalMovement = transform.right * -horizontalInput * horizontalSpeed * Time.fixedDeltaTime;
        forwardMovement += verticalMovement;
        rb.MovePosition(rb.position + forwardMovement + horizontalMovement);


    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    public void Kill()
    {
        isAlive = false;
        anim.SetTrigger("Dead");

        GameManager.Instance.EndGame();

    }



    void Jump()
    {
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f,groundMask);
        if(isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
            anim.SetTrigger("Jump");
        }
    }
}
