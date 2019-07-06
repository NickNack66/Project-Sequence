using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementRecorder : MonoBehaviour
{
    bool isRec = true;
    public List<Vector3> numsRecord = new List<Vector3>();
    public GameObject Clone;
    public bool spaceEnabled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRec == true)
        {
            numsRecord.Add(transform.position);
;        }
        if(Input.GetKeyDown("space") == true)
        {
            //if (spaceEnabled)
            //{
                isRec = false;
                Instantiate(Clone, new Vector3(0, (float)0.75, 0), new Quaternion(0, 0, 0, 0));
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            //}
        }
    }
}
