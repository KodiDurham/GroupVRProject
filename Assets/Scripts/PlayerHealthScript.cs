using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    public int maxHealth;
    public int health;

    public bool isDown;

    public int deathPen = -50;

    public OVRPlayerController playerController;

    public Transform SpawnPoint;

    public ScoreManager sManager;

    // Start is called before the first frame update
    void Start()
    {
        isDown = false;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int i)
    {
        health -= i;

        if (health <= 0)
        {
            death();
        }

    }

    void death()
    {
        playerController.EnableLinearMovement = false;
        isDown = true;
        //do something...
        sManager.addScore(deathPen);
        this.transform.position = SpawnPoint.position;
        this.transform.rotation = SpawnPoint.rotation;
        health = maxHealth;
        StartCoroutine(DieCo());
    }

    IEnumerator DieCo()
    {

        yield return new WaitForSeconds(1);

        playerController.EnableLinearMovement = true;
    }

}
