using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel : MonoBehaviour
{
    public Animator anim;
    public GameObject menu;
    private GameObject[] clones;
    private GameObject[] dialogueTriggers;
    private DialogueTrigger triggerController;
    private GameObject musicPlayer;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.name == "Player")
        {
            player = other.transform.gameObject;
            Destroy(player);
            anim.SetBool("IsOpen", true);
            clones = GameObject.FindGameObjectsWithTag("Clone");
            foreach (GameObject clone in clones)
            {
                Destroy(clone);
            }
            musicPlayer = GameObject.FindGameObjectWithTag("MusicPlayer");
            Destroy(musicPlayer);
            dialogueTriggers = GameObject.FindGameObjectsWithTag("DialogueTrigger");
            foreach (GameObject trigger in dialogueTriggers)
            {
                //triggerController = trigger.GetComponent<DialogueTrigger>();
               // triggerController.singletons = null;
                Destroy(trigger);
            }
        }//Play some music from this object
    }//Dialogue triggers not appearing when transitioning to next level
}
