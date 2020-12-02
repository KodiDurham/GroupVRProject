using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class enemySpawner : MonoBehaviour, IPunObservable
{
    public EnemySpawnPoint[] points;
    public bool hasSpawned = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasSpawned && other.gameObject.layer == 12)
        {
            for(int i = 0; i < points.Length; i++)
            {
                if(points[i].type== enemyScript.AttackType.melee)
                {
                    PhotonNetwork.Instantiate("Enemy Melee", points[i].gameObject.transform.position, points[i].gameObject.transform.rotation);
                }
                else
                {
                    PhotonNetwork.Instantiate("Enemy Ranged", points[i].gameObject.transform.position, points[i].gameObject.transform.rotation);
                }
            }
            hasSpawned = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(hasSpawned);
        }
        else
        {
            hasSpawned = (bool)stream.ReceiveNext();
        }
    }
}
