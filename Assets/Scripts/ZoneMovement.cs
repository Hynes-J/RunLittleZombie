using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneMovement : MonoBehaviour
{
    [SerializeField]
    float speed;




    private void Start()
    {
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
        transform.position += forwardMovement;
    }

}
