using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    public float health;
    public GameObject bubble;
    public AudioSource healthSFX;
    public AudioSource[] hurtSounds;
    public AudioSource lowHPSound;
    // Update is called once per frame

    void Start()
    {
        lowHPSound.loop = true;
    }

    void Update()
    {

        //bubble = GameObject.Find("Bubble Health");
        bubble.transform.localScale = new Vector3(health/100 * 0.9128754f, health/100 * 0.9128754f, 0.9128754f);

        if(health <= 0){
            //Debug.Log("health 0");
            SceneManager.LoadScene("Game_Over");
        }

        if(health <= 20)
        {
            if(!lowHPSound.isPlaying)
            {
                lowHPSound.Play();
            }
        }

        if(health > 20)
        {
            if(lowHPSound.isPlaying)
            {
                lowHPSound.Stop();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision){

        //Debug.Log("collision");

        Enemy enemy = collision.GetComponent<Enemy>();
        HealthPickup healthpickup = collision.GetComponent<HealthPickup>();

        if(enemy != null){
            hurtSounds[Random.Range(0, hurtSounds.Length-1)].Play();
            health -= 10;
        }else if(healthpickup != null){
            health += 10;
            if(health > 100){
                health = 100;
            }
            healthSFX.Play();
            healthpickup.vanish();
        }
        
    }
}
