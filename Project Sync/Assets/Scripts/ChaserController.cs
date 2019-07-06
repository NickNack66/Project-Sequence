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
    private Vector3[] directions;
    private Vector3 direction;
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
            directions = new Vector3[] { Vector3.left, Vector3.right, Vector3.forward, Vector3.back};

            hit = new RaycastHit[4];
            i = hit.Length;
            while (i > 0)
            {
                i--;
                if (Physics.SphereCast(transform.position, 1, directions[i], out hit[i], range, 9, QueryTriggerInteraction.Collide))
                {
                    if (hit[i].transform.name == "Player" || hit[i].transform.name == "Clone(Clone)")
                    {
                        Debug.Log("Player detected by chaser!");
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

        //On collision- kill clone
        //Crush player against walls?
    }
}
