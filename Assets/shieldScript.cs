using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class shieldScript : MonoBehaviourPunCallbacks, IPunObservable
{

    public bool isInZone;
    public AudioSource hitSound;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(isInZone);
        }
        else
        {
            isInZone = (bool)stream.ReceiveNext();
            if (isInZone)
            {
                this.GetComponent<Rigidbody>().useGravity = false;
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isInZone = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isInZone && !this.GetComponent<PhotonGrabbable>().isGrabbed)
        {
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer != 12)
        {
            hitSound.Play();

            if (isInZone)
                VibeManager.singleton.triggerViberationController(hitSound.clip, OVRInput.Controller.LTouch);
        }
    }
}
