using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> players;

    public int playerCount=0;

    public List<enemyScript> enemies;

    public int enemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        players = new List<GameObject>();
        enemies = new List<enemyScript>();

        //enemies.Clear();
        //players.Add(this.gameObject);
        //players.Remove(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (players.Count != playerCount)
        {
            foreach(enemyScript e in enemies)
            {
                e.UpdatePlayerList();
            }
            playerCount = players.Count;
        }

        //if (enemies.Count != enemyCount)
        //{
        //    foreach (enemyScript e in enemies)
        //    {
        //        e.UpdatePlayerList();
        //    }
        //    enemyCount = enemies.Count;
        //}
    }

    public void addEnemy(enemyScript other)
    {
        Debug.LogError("in"+ other.gameObject);
        enemies.Add(other);
        enemies.Remove(other);
        enemies.Add(other);
    }

    //public void removeEnemy(enemyScript e)
    //{
    //    enemies.Remove(e);
    //}

    //public void addPlayer(GameObject gO)
    //{
    //    Debug.LogError("in "+gO);
    //    //players.Add(gO);
    //    //players.Add(gO);

    //}

    //public void removePlayer(GameObject gO)
    //{
    //   // players.Remove(gO);

    //}

}
