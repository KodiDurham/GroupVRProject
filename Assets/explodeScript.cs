using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodeScript : MonoBehaviour
{
    public int timeToDie = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DieCo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// temp
    /// </summary>
    /// <returns></returns>
    IEnumerator DieCo()
    {

        yield return new WaitForSeconds(timeToDie);

        PhotonNetwork.Destroy(this.GetComponent<PhotonView>());

    }

}
