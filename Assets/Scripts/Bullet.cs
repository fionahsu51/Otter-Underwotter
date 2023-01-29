using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;
    private Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision){

        Debug.Log("collision");
        
        Enemy enemy = collision.GetComponent<Enemy>();

        if(enemy != null){
            enemy.takeDamage(damage);
            Destroy(gameObject);
        }
        

    }
}
