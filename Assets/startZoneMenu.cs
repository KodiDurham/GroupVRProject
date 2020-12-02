using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class startZoneMenu : MonoBehaviour, IPunObservable
{
    public GameObject startMenu;
    public GameObject notEnough;

    public EnemyManager eManager;

    public int minPlayers = 2;

    public int playerCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        notEnough.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        updateThings();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            playerCount++;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 12)
        {
            playerCount--;
        }
    }


    void updateThings()
    {
        if (playerCount >= eManager.players.Count && playerCount > minPlayers - 1)
        {
            if (notEnough.active) { notEnough.SetActive(false); }
            if (!startMenu.active) { startMenu.SetActive(true);
                Debug.LogError("active");
            }
        }
        else
        {
            if (!notEnough.active) { notEnough.SetActive(true); }
            if (startMenu.active) { startMenu.SetActive(false);
                Debug.LogError("not active");
            }

        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(playerCount);
        }
        else
        {
            playerCount = (int)stream.ReceiveNext();

            

        }
    }

}
