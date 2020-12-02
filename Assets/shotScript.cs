using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class shotScript : MonoBehaviour
{
    Rigidbody rb;

    public int damage = 10;

    public float speed=10;

    public float range = 50;

    public AvatarLayer layer;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = this.transform.position;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layer.layerIndex && layer.layerIndex == 12)
        {
            other.gameObject.GetComponent<PlayerHealthScript>().takeDamage(damage);
            die();

        }

        if(layer.layerIndex == 12 && other.gameObject.layer != 13)
            die();

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == layer.layerIndex)
        {
            other.gameObject.GetComponent<enemyScript>().takeDamage(damage);
            
        }

        if(!(other.gameObject.layer == 9))
            die();

    }


    // Update is called once per frame
    void Update()
    {
        



    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * speed);

        if (Vector3.Distance(startPos, this.transform.position) >= range)
            die();

    }

    void die()
    {

        GameObject explode = PhotonNetwork.Instantiate("ProjectileExplode", this.transform.position, this.transform.rotation);
        PhotonNetwork.Destroy(this.GetComponent<PhotonView>());

        
    }

}
