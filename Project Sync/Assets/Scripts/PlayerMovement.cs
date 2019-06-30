using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.velocity = movement * speed; // All this block does is let the player 1 move.
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
        if (Vector3.Distance(movement, new Vector3(0.0f, 0.0f, 0.0f))!= 0)
        {
            gameObject.transform.Rotate(0, 0, 0, Space.Self);
        }
    }
}

//gameObject.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);