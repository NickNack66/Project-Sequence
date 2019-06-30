using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    public AudioClip[] clips;
    private AudioSource audioSource;

    public static List<string> singletons = new List<string>();

    // Use this for initialization
    void Start () {
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.clip = GetRandomClip();
        audioSource.Play();
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


    // Update is called once per frame
    private AudioClip GetRandomClip () {
        return clips[Random.Range(0, clips.Length)];
	}
}
