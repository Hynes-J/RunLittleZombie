using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    [SerializeField]
    float speed;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);//could replace 0 by any other animation layer index
        anim.Play(state.fullPathHash, -1, Random.Range(0f, 1f));
        anim.speed = Random.Range(0.2f, 1.5f);
    }
    private void FixedUpdate()
    {
        //Add a raycast that checks if forward movement is blocked (or will keep going through objects)
        Vector3 horizontalMovement = transform.right * speed * Time.fixedDeltaTime;
        transform.position += horizontalMovement;
    }

   

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Crow")
        {
            Debug.Log("here");
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

    }
}
