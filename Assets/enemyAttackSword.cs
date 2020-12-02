using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttackSword : MonoBehaviour
{

    public int damage=25;
    private int mod = 1;

    public float fireRate = 1f;
    private float nextshot = 0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextshot)
        {
            nextshot = Time.time + fireRate;

            mod = 1;
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 12)
        {
            collision.gameObject.GetComponent<PlayerHealthScript>().takeDamage(damage*mod);
        }

        if(collision.gameObject.layer == 10)
        {
            mod = 0;
            nextshot = Time.time + fireRate;

        }
    }

}
