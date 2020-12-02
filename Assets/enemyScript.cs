using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Linq;
using UnityEngine.AI;
using TMPro;

public class enemyScript : MonoBehaviourPunCallbacks, IPunObservable
{
    public enum AttackType {spell, melee}
    public AttackType attackType;
    public int health;
    public int maxHealth;
    public Slider healthBar;


    public float fireRate = 1f;
    private float nextshot = 0f;

    private EnemyManager manager;
    public List<GameObject> players;

    public Animator attack;

    public float attackDistance = 1;
    public float forgetDistance = 50;

    public NavMeshAgent agent;

    public Vector3 target;

    public Transform shotPos;

    private Rigidbody rb;

    private ScoreManager sManager;

    public int score = 10;



    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        sManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        manager.enemies.Add(this);
        rb = this.GetComponent<Rigidbody>();

        players = new List<GameObject>();

        UpdatePlayerList();

        health = maxHealth;

        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }


    // Update is called once per frame
    void Update()
    {
        if (!manager.enemies.Contains(this))
        {
            manager.enemies.Add(this);
        }
    }


    private void FixedUpdate()
    {
        //might be better to use navmesh if we have time

        findClosestPlayer();
        transform.LookAt(target);

        rb.velocity = new Vector3(0,0,0);

        if (Vector3.Distance(this.transform.position, target) < forgetDistance)
        {

            this.transform.LookAt(target);
            if (Vector3.Distance(this.transform.position, target) <= attackDistance)
            {
                //attack
                //Debug.LogError("Enemey attack");

                if (attackType == AttackType.melee)
                {
                    attack.SetBool("attacking", true);
                }
                else
                {
                    if (Time.time > nextshot)
                    {
                        nextshot = Time.time + fireRate;

                        PhotonNetwork.Instantiate("enemyProjectile", shotPos.position, shotPos.rotation);
                    }
                }

            }
            else
            {
                if (attackType == AttackType.melee)
                {
                    attack.SetBool("attacking", false);
                }
                //move
                agent.SetDestination(target);
            }
        }
    }

    public void takeDamage(int i) 
    {
        health -= i;
        healthBar.value = health;

        if (health <= 0)
            die();
    }

    void die()
    {
        GameObject popUp =PhotonNetwork.Instantiate("popUpScore", this.transform.position+new Vector3(0,.05f,0),this.transform.rotation);
        popUp.GetComponent<TextMeshPro>().text = "+" + score;

        manager.enemies.Remove(this);

        sManager.addScore(score);
        PhotonNetwork.Destroy(this.GetComponent<PhotonView>());

        Destroy(this);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(health);
        }
        else
        {
            health = (int)stream.ReceiveNext();
        }
    }

    private void findClosestPlayer()
    {
        Vector3 close= new Vector3();
        if (players.Count > 0)
        {
            close = players.ElementAt(0).transform.position;

            foreach (GameObject gO in players)
            {
                if (Vector3.Distance(this.transform.position, close) < Vector3.Distance(this.transform.position, gO.transform.position))
                {
                    close = gO.transform.position;
                }
            }
        }
        target = close;
    }


    public void UpdatePlayerList()
    {
        //Debug.LogError("in this");
        players = manager.players;
    }
}
