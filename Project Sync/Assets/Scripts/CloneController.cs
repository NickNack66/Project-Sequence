using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneController : MonoBehaviour
{

    private GameObject player;
    private MovementRecorder recorder;

    private List<Vector3> numsAct = new List<Vector3>();
    private int frame;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        recorder = player.transform.GetComponent<MovementRecorder>();
        numsAct = recorder.numsRecord;
        print(numsAct.Count);
        DontDestroyOnLoad(gameObject);
        frame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") == true)
        {
            //Reset position
            frame = 0;
        }
        StartCoroutine("Playback");
    }

    private IEnumerator Playback()
    {
        transform.position = (numsAct[frame]);
        frame += 1;
        yield return null;
    }
}
