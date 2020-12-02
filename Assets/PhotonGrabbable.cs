using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonGrabbable : OVRGrabbable, IPunObservable
{
    private PhotonView photonView;

    public bool isGrabbedP;

    // Start is called before the first frame update
    protected override void Start()
    {
        isGrabbedP = false;
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        
        photonView.RequestOwnership();
        isGrabbedP = true;
        this.GetComponent<Rigidbody>().useGravity = false;
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        base.GrabBegin(hand, grabPoint);
        this.transform.SetParent(hand.gameObject.transform);
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        isGrabbedP = false;
        this.GetComponent<Rigidbody>().useGravity = true;
        base.GrabEnd(linearVelocity, angularVelocity);
        this.transform.SetParent(null);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(isGrabbedP);
        }
        else
        {
            isGrabbedP = (bool)stream.ReceiveNext();
        }
    }
}
