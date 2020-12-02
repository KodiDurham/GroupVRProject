using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtCamScript : MonoBehaviour
{
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("CenterEyeAnchor").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cam.transform);
        //transform.LookAt(transform.position + cam.transform.rotation * Vector3.back, cam.transform.rotation * Vector3.up );
    }
}
