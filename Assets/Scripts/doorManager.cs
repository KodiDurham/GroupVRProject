using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorManager : MonoBehaviour
{
    public Animator door; //or animator to call open

    bool isOpen = false;

   public bool[] hasKeys;

    // Start is called before the first frame update
    void Start()
    {

    }


    public void updateKey(int i, bool hasKey)
    {
        hasKeys[i] = hasKey;
        testKeys();
    }

    public void testKeys()
    {
        bool hasAllKeys = true;
        foreach(bool key in hasKeys)
        {
            if (key == false)
            {
                hasAllKeys = false;
                break;
            }
        }

        if (hasAllKeys)
        {
            openDoor();
        }
    }

    public void openDoor()
    {
        Debug.Log("OPEN DOOR!!!");
        if(!isOpen)
            door.SetBool("open", true);
        isOpen = true;
    }
}
