using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectZone : MonoBehaviour
{
    public AvatarLayer layer;
    public Vector3 rotation;

    public bool hasChanged=true;

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        
        if(other.gameObject.layer == layer.layerIndex)
        {
            OVRGrabbable grabObject =  other.gameObject.GetComponent<OVRGrabbable>();

            if (!grabObject.isGrabbed && hasChanged)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.gameObject.transform.SetParent(this.transform);
                other.gameObject.transform.localPosition = new Vector3(0, 0, 0);
                //other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                other.gameObject.transform.localRotation = Quaternion.Euler(rotation);
                other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                hasChanged = false;


                if (other.gameObject.layer == 10)
                {
                    other.GetComponent<shieldScript>().isInZone = true;
                }

            }
            else
            {
                
                if (grabObject.isGrabbed)
                {
                    other.GetComponent<Rigidbody>().useGravity = true;
                    other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    //other.gameObject.transform.SetParent(null);
                    hasChanged = true;


                    if (other.gameObject.layer == 10)
                    {
                        other.GetComponent<shieldScript>().isInZone = false;
                    }
                }
                    
            }

        }
    }
}
