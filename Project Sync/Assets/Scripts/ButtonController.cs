using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    private int objectCount = 0;

    public GameObject[] DoorsClosed;
    public GameObject[] DoorsOpen;
    private void OnTriggerEnter()
    {
        print("Button pressed");
        objectCount += 1;
        for (int i = 0; i < DoorsClosed.Length; i++)
        {
            Vector3 newPosition = DoorsClosed[i].transform.position;
            if (newPosition.y == (float)2)
            {
                newPosition.y = -0.95f;
            }
            DoorsClosed[i].transform.position = newPosition;
        }
        for (int i = 0; i < DoorsOpen.Length; i++)
        {
            Vector3 newPosition = DoorsOpen[i].transform.position;
            if (newPosition.y == -0.95f)
            {
                newPosition.y = (float)2;
            }
            DoorsOpen[i].transform.position = newPosition;
        }
    }

    private void OnTriggerExit()
    {
        objectCount -= 1;
        if (objectCount == 0)
        {
            for (int i = 0; i < DoorsClosed.Length; i++)
            {
                Vector3 newPosition = DoorsClosed[i].transform.position;
                if (newPosition.y == -0.95f)
                {
                    newPosition.y = 2f;
                }
                DoorsClosed[i].transform.position = newPosition;
            }
            for (int i = 0; i < DoorsOpen.Length; i++)
            {
                Vector3 newPosition = DoorsOpen[i].transform.position;
                if (newPosition.y == 2f)
                {
                    newPosition.y = -0.95f;
                }
                DoorsOpen[i].transform.position = newPosition;
            }
        }
        
    }
}
