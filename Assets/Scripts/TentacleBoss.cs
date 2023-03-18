using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TentacleBoss : Enemy
{
    private AudioSource deathSFX;
    LoadtheEnd endloader;
    // Start is called before the first frame update
    void Start()
    {
        endloader = GameObject.Find("Otter").GetComponent<LoadtheEnd>();
        deathSFX = GameObject.Find("Death_Anouncer").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        move();

        if (health <= 0)
        {
            healthPickupPrefab.SetActive(false);
            deathSFX.Play();
            endloader.StartCoroutine("LoadEnd");

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies){
                Enemy e = enemy.GetComponent<Enemy>();
                e.die();
            }

            die();
        }
    }

    public override void move()
    {

    }
}