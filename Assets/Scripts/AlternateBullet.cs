using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateBullet : MonoBehaviour
{
    public float speed;
    public float damage;
    private Rigidbody2D rb;
    public float range = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0){
            Destroy(gameObject);
        }
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        Destroy(gameObject, range); // Destroy bullet after 0.5 seconds
    }

    void OnTriggerEnter2D(Collider2D collision){
        
        Enemy enemy = collision.GetComponent<Enemy>();
        Chest chest = collision.GetComponent<Chest>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
            Destroy(gameObject);
        }else if(chest != null){
            chest.Open();
            Destroy(gameObject);
        }     
    }
}
