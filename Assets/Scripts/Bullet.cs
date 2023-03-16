using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;
    public float scale = 0.3f;
    private Rigidbody2D rb;

    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        transform.localScale = new Vector3(scale, scale, 1.0f);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision){
        
        Enemy enemy = collision.GetComponent<Enemy>();
        Chest chest = collision.GetComponent<Chest>();
        if(enemy != null){
            enemy.takeDamage(damage);
            Destroy(gameObject);
        }else if(chest != null){
            chest.Open();
            Destroy(gameObject);
        }    
    }
}
