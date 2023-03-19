using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    public float health;
    public float speed;
    public float leftBound;
    public float rightBound;
    protected Rigidbody2D rb;
    protected Vector3 dir = Vector3.left;
    public float status = 0;
    public GameObject chestPrefab;
    public GameObject healthPickupPrefab;
    public GameObject deathBubblePrefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        /*if(health == 0){
            die();
        }*/
    }

    public void takeDamage(float dmg){

        health -= dmg;
        StartCoroutine("EnemyFlash");
    }

    public void die(){
        Instantiate(deathBubblePrefab, transform.position, transform.rotation);
        int drop = Random.Range(0, 10);
        if(drop <= 5){
            //Debug.Log("nothing");
        }else if(drop > 5 && drop <= 8){
            //Debug.Log("health pickup");
            Instantiate(healthPickupPrefab, transform.position, transform.rotation);
        }else{
            //Debug.Log("chest");
            Instantiate(chestPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    public abstract void move();

    // With help from here. Thank you Lethn!
    // https://forum.unity.com/threads/solved-blink-white-when-hit.788159/
    public IEnumerator EnemyFlash ()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
        StopCoroutine("EnemyFlash");
    }

    public IEnumerator Stun() {
        status = 1;
        GetComponent<SpriteRenderer>().color = Color.yellow;
        yield return new WaitForSeconds(2.0f);
        GetComponent<SpriteRenderer>().color = Color.white;
        status = 0;
        StopCoroutine("Stun");
    }

}
