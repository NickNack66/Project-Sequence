using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyBlock : MonoBehaviour
{
    private Vector3 startPos;
    public static List<string> singletons = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        startPos = transform.position;
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = startPos;
        }

    }
}
