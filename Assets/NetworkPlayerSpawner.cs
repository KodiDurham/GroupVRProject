using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;

    public EnemyManager eManager;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation);
        Debug.Log("player entered");
        eManager.players.Add(spawnedPlayerPrefab.gameObject.transform.GetChild(0).GetChild(0).gameObject);

    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();

        //eManager.players.Remove(spawnedPlayerPrefab.gameObject.transform.GetChild(0).GetChild(0).gameObject);

        PhotonNetwork.Destroy(spawnedPlayerPrefab);

        //eManager.removePlayer(spawnedPlayerPrefab);


    }

}
