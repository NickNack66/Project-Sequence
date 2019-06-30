using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserController : MonoBehaviour
{

    //public GameObject player;
    public float range;
    public float movementSpeed;
    private bool moving = false;
    float distanceTravelled = 0;
    Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving == false)
        {
            transform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime);
            Vector3 fwd = transform.TransformDirection(Vector3.forward);
            RaycastHit hit;
            if(Physics.Raycast(transform.position, fwd, out hit, range, 9, QueryTriggerInteraction.Collide))
            {
                Debug.DrawLine(transform.position, hit.point);
                if (hit.transform.name == "Player")
                {
                    Debug.Log("Player detected by chaser!");
                    moving = true;
                }
            }
            
        }
        if (moving)
        {
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
            if(Vector3.Distance(transform.position, lastPosition) == range)
            {
                moving = false;
            }
        }
    }
}
