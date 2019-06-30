using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private Rigidbody rb;

    private MovementRecorder movementRec;

    public GameObject player;

    public GameObject nextTrigger;

    private bool triggered;

    public bool enableSpace;

    public static List<string> singletons = new List<string>();

    private void Start()
    {
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();
        movementRec = player.GetComponent<MovementRecorder>();
        DontDestroyOnLoad(gameObject);
    }

    private void Awake() //Stops object from duplicating when scene reloads
    {
        string gameObjectIdentifier = gameObject.name;

        if (!singletons.Contains(gameObjectIdentifier))
        {
            singletons.Add(gameObjectIdentifier);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /*private void Update()
    {
        print(triggered);
        if (triggered)
        {
            Destroy(gameObject);
        }
    }*/

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        if (enableSpace)
        {
            movementRec.spaceEnabled = true;
        }
        nextTrigger.SetActive(true);
        triggered = true;
        print(triggered);
        transform.position = new Vector3(100, 100, 100);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.name == "Player")
        {
            TriggerDialogue();
        }
    }
}

//YESSSSSSSSSSSS!
//Memorial to the fact that I spent like 8 hours on this on the 16th of June, 2019
//Rip, still not entirely working, check level 2 :(
//And 2nd trigger of level 1 :(
//Triggers that are activated right before reload do not despawn
