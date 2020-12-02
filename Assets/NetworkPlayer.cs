using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{
    public GameObject head;
    public GameObject leftHand;
    public GameObject rightHand;

    private PhotonView photonView;

    private GameObject headRig;
    private GameObject leftHRig;
    private GameObject rightHRig;

    //public EnemyManager eManager;

    // Start is called before the first frame update
    void Start()
    {
        //eManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();

        //eManager.addPlayer(this);
        //eManager.players.Add(this.gameObject.transform.GetChild(0).GetChild(0).gameObject);

        photonView = GetComponent<PhotonView>();
        
        GameObject playerController = GameObject.Find("OVRPlayerController");

        headRig = GameObject.Find("CenterEyeAnchor");
        leftHRig = GameObject.Find("LeftHandAnchor");
        rightHRig = GameObject.Find("RightHandAnchor");

        leftHand.GetComponent<OVRGrabber>().m_parentTransform = leftHRig.transform;
        leftHand.GetComponent<OVRGrabber>().m_player = playerController;

        rightHand.GetComponent<OVRGrabber>().m_parentTransform = rightHRig.transform;
        rightHand.GetComponent<OVRGrabber>().m_player = playerController;

        if (photonView.IsMine)
        {
            head.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            //rightHand.gameObject.SetActive(false);
            //leftHand.gameObject.SetActive(false);
            ///head.gameObject.SetActive(false);

            MapPos(head, headRig);
            MapPos(leftHand, leftHRig);
            MapPos(rightHand, rightHRig);
        }
    }

    void MapPos(GameObject target, GameObject node)
    {
        
        target.transform.position = node.transform.position;

        if (node == leftHRig)
            target.transform.rotation = node.transform.rotation * Quaternion.Euler(0, 0, 90);
        else if (node == rightHRig)
            target.transform.rotation = node.transform.rotation * Quaternion.Euler(0, 0, -90);
        else
            target.transform.rotation = node.transform.rotation;

    }
}
