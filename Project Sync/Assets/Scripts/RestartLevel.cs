using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{

    public SceneFader sceneFader;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            sceneFader.FadeTo(SceneManager.GetActiveScene().buildIndex);
            GameObject[] clones = GameObject.FindGameObjectsWithTag("Clone");
            foreach (GameObject clone in clones)
            {
                Destroy(clone);
            }
        }

    }
}
