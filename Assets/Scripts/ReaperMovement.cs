using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperMovement : MonoBehaviour
{
    [SerializeField]
    float speed;


    AudioSource audioData;

    Animator anim;

    PlayerMovement playerMovement;


    Rigidbody rb;

    private void Start()
    {
        audioData = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody>();
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();

        anim = GetComponentInChildren<Animator>();
        audioData.PlayDelayed(.5f);


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

        //Add a raycast that checks if forward movement is blocked (or will keep going through objects)
        Vector3 forwardMovement = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMovement);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerMovement.Kill();
            anim.SetTrigger("Attack");
            audioData.PlayDelayed(.5f);

        }
    }
}
