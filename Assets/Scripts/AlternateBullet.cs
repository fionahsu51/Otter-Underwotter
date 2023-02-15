using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateBullet : MonoBehaviour
{
    public float speed;
    public float damage;
    private Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        Destroy(gameObject, 0.5f); // Destroy bullet after 0.5 seconds
    }

    void OnTriggerEnter2D(Collider2D collision){
        
        Enemy enemy = collision.GetComponent<Enemy>();

        if(enemy != null){
            enemy.takeDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
