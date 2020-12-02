using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackScript : MonoBehaviour
{
    private PhotonGrabbable grabbable;

    public AudioSource hitSound;

    public AvatarLayer layer;
    public int damage=10;

    void Start()
    {
        grabbable = GetComponent<PhotonGrabbable>();
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.layer == layer.layerIndex)
    //    {
    //        other.gameObject.GetComponent<enemyScript>().takeDamage(damage);
    //    }
    //}


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == layer.layerIndex)
        {
            other.gameObject.GetComponent<enemyScript>().takeDamage(damage);
        }

        hitSound.Play();
        VibeManager.singleton.triggerViberationController(hitSound.clip, grabbable.grabbedBy.GetController());

    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
    }

}
