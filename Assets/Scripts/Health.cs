using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    public float health;
    // Update is called once per frame
    void Update()
    {
        if(health == 0){
            Debug.Log("health 0");

            SceneManager.LoadScene("Game_Over");
        }
    }

    void OnTriggerEnter2D(Collider2D collision){

        Debug.Log("collision");

        Enemy enemy = collision.GetComponent<Enemy>();

        if(enemy != null){
            health -= 10;
        }
        
    }
}
