using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectEnterTrigger : MonoBehaviour
{
    public int keyIndex;

    public GameObject key;

    public bool hasKey;

    public doorManager manager;

    // Start is called before the first frame update
    void Start()
    {
        hasKey = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject == key)
        {
            hasKey = true;
            manager.updateKey(keyIndex,hasKey);
            Debug.Log("key " + keyIndex + " in");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject == key)
        {
            hasKey = false;
            manager.updateKey(keyIndex,hasKey);
            Debug.Log("key " + keyIndex + " out");
        }
    }
}
