using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserController : MonoBehaviour
{

    //public GameObject player;
    public float range;
    public float movementSpeed;
    public float retreatSpeed;
    private float movementPhase = 1;
    public Vector3 pushDir;
    public Collider outerCollider;
    private float pushForce = 1000000;
    public Vector3[] directions;
    private Vector3 direction;
    private Rigidbody rb;
    private PlayerMovement playerMovement;
    Vector3 lastPosition;
    RaycastHit[] hit;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (movementPhase == 1) //Detection
        {
            //directions = new Vector3[] { Vector3.left, Vector3.right, Vector3.forward, Vector3.back};
            outerCollider.enabled = true;
            hit = new RaycastHit[4];
            i = hit.Length;
            while (i > 0)
            {
                i--;
                if (Physics.SphereCast(transform.position, 1, directions[i], out hit[i], range, 9, QueryTriggerInteraction.Collide))
                {
                        if (hit[i].transform.name == "Player" || hit[i].transform.name == "Clone(Clone)")
                        {
                            direction = directions[i];
                            movementPhase = 2;
                        }
                }
            }
            
            
        }
        if (movementPhase == 2) //Chase
        {
            //Raycast to detect if a wall is directly in front; if so, move to stage 3
            transform.position += direction * Time.deltaTime * movementSpeed;
            if(Vector3.Distance(transform.position, lastPosition) > range)
            {
                movementPhase = 3;
            }
        }
        if (movementPhase == 3) //Retreat
        {
            transform.position = Vector3.MoveTowards(transform.position, lastPosition, retreatSpeed*Time.deltaTime);
            if (Vector3.Distance(transform.position, lastPosition) < 0.1)
            {
                movementPhase = 1;
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Player")
        {
            outerCollider.enabled = false;
            rb = other.transform.GetComponent<Rigidbody>();
            rb.AddForce(pushDir*pushForce);
            //playerMovement = other.transform.GetComponent<PlayerMovement>();
            //playerMovement.ChaserPush(pushDir);
        }
    }
}
