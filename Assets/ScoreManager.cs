using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ScoreManager : MonoBehaviour, IPunObservable
{
    // Start is called before the first frame update

    public Text[] text;

    int score = 0;


    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int i)
    {
        score += i;

        UpdateScore();
    }

    private void UpdateScore()
    {
        for (int i =0; i<text.Length;i++)
        {
            text[i].text = "Score: " + score;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(score);
        }
        else
        {
           score = (int)stream.ReceiveNext();
            UpdateScore();
        }
    }
}
