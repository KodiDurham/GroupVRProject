using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class staffShot : MonoBehaviour
{
    private PhotonGrabbable grabbable;
    public OVRInput.Button shootButton;
    public Transform shotPos;
    public GameObject projectile;

    public AudioSource shotSound;

    // Start is called before the first frame update
    void Start()
    {
        grabbable = GetComponent<PhotonGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbable.isGrabbed && OVRInput.GetDown(shootButton, grabbable.grabbedBy.GetController()))
        {
            //Debug.LogError("Shoot!!");
            shoot();
        }
    }

    public void shoot()
    {

        shotSound.Play();
        VibeManager.singleton.triggerViberationController(shotSound.clip, grabbable.grabbedBy.GetController());

        //PhotonNetwork.Instantiate("playerProjectileLeadUp", shotPos.position, shotPos.rotation);

        PhotonNetwork.Instantiate("playerProjectile", shotPos.position, shotPos.rotation);



    }
}
