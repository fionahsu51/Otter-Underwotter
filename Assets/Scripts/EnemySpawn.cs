using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject pufferfish;
    public GameObject stingray;
    public GameObject wolfEel;
    public GameObject seaAngel;
    private float time;
    private float spawnInterval;
    private int maximumEnemiesOnScreen;

    // Start is called before the first frame update
    void Start()
    {
        spawnInterval = 3.5f;
        maximumEnemiesOnScreen = 6;
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= spawnInterval) {
            time = 0f;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            int nearbyEnemies = 0;
            foreach (GameObject enemy in enemies) {
                if (Vector3.Distance(transform.position, enemy.transform.position) < 9f) {
                    nearbyEnemies++;
                }
            }
            if (nearbyEnemies < maximumEnemiesOnScreen) {
                int gotRand = 0;
                if (transform.position.y > -77f) {
                    gotRand = Random.Range(0, 4);
                }
                else gotRand = Random.Range(3, 6);
                if (gotRand == 0) { //pufferfish swarm
                    //first layer
                    Vector3 pos = new Vector3(transform.position.x - 7f, transform.position.y - 13f, transform.position.z);
                    Instantiate(pufferfish, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x - 3f, transform.position.y - 14f, transform.position.z);
                    Instantiate(pufferfish, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x + 3f, transform.position.y - 14f, transform.position.z);
                    Instantiate(pufferfish, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x + 7f, transform.position.y - 13f, transform.position.z);
                    Instantiate(pufferfish, pos, Quaternion.identity);
                    //second layer
                    pos = new Vector3(transform.position.x - 8f, transform.position.y - 15f, transform.position.z);
                    Instantiate(pufferfish, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x - 3f, transform.position.y - 16f, transform.position.z);
                    Instantiate(pufferfish, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x + 3f, transform.position.y - 16f, transform.position.z);
                    Instantiate(pufferfish, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x + 8f, transform.position.y - 15f, transform.position.z);
                    Instantiate(pufferfish, pos, Quaternion.identity);
                }
                else if (gotRand == 1) { //Sunlight Melange (Pufferfish, rays and eel)
                    Vector3 pos = new Vector3(transform.position.x - 7f, transform.position.y - 13f, transform.position.z);
                    Instantiate(stingray, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x - 3f, transform.position.y - 16f, transform.position.z);
                    Instantiate(pufferfish, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x + 3f, transform.position.y - 16f, transform.position.z);
                    Instantiate(pufferfish, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x + 7f, transform.position.y - 14.5f, transform.position.z);
                    Instantiate(stingray, pos, Quaternion.identity);
                    //two wolf eels as second layer
                    pos = new Vector3(transform.position.x - 4f, transform.position.y - 16f, transform.position.z);
                    Instantiate(wolfEel, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x + 4f, transform.position.y - 16f, transform.position.z);
                    Instantiate(wolfEel, pos, Quaternion.identity);
                }
                else if (gotRand == 2) { //Puffs n' Eels
                    //first layer
                    Vector3 pos = new Vector3(transform.position.x - 7f, transform.position.y - 13f, transform.position.z);
                    Instantiate(pufferfish, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x, transform.position.y - 14f, transform.position.z);
                    Instantiate(pufferfish, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x + 7f, transform.position.y - 13f, transform.position.z);
                    Instantiate(pufferfish, pos, Quaternion.identity);
                    //second layer
                    pos = new Vector3(transform.position.x - 11f, transform.position.y - 3f, transform.position.z);
                    Instantiate(wolfEel, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x + 11f, transform.position.y - 3f, transform.position.z);
                    Instantiate(wolfEel, pos, Quaternion.identity);
                }
                else if (gotRand == 3) { //Stingray Gauntlet
                    float beginning = transform.position.y - 12f;
                    float separation = 1.5f;
                    Vector3 pos = new Vector3(transform.position.x - 7f, beginning, transform.position.z);
                    Instantiate(stingray, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x + 7f, beginning - separation, transform.position.z);
                    Instantiate(stingray, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x - 7f, beginning - 2 * separation, transform.position.z);
                    Instantiate(stingray, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x + 7f, beginning - 3 * separation, transform.position.z);
                    Instantiate(stingray, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x - 7f, beginning - 4 * separation, transform.position.z);
                    Instantiate(stingray, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x + 7f, beginning - 5 * separation, transform.position.z);
                    Instantiate(stingray, pos, Quaternion.identity);
                } else if (gotRand == 4) { //Wolf eel swarm
                    //left side
                    Vector3 pos = new Vector3(transform.position.x - 8f, transform.position.y - 6f, transform.position.z);
                    Instantiate(wolfEel, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x - 8f, transform.position.y - 9f, transform.position.z);
                    Instantiate(wolfEel, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x - 7f, transform.position.y - 13f, transform.position.z);
                    Instantiate(wolfEel, pos, Quaternion.identity);
                    //right side
                    pos = new Vector3(transform.position.x + 8f, transform.position.y - 6f, transform.position.z);
                    Instantiate(wolfEel, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x + 8f, transform.position.y - 9f, transform.position.z);
                    Instantiate(wolfEel, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x + 7f, transform.position.y - 13f, transform.position.z);
                    Instantiate(wolfEel, pos, Quaternion.identity);
                } else if (gotRand == 5) { //Sea Angels Rising
                    Vector3 pos = new Vector3(transform.position.x - 7.5f, transform.position.y - 13f, transform.position.z);
                    Instantiate(seaAngel, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x - 4.5f, transform.position.y - 13f, transform.position.z);
                    Instantiate(seaAngel, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x - 1.5f, transform.position.y - 13f, transform.position.z);
                    Instantiate(seaAngel, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x + 1.5f, transform.position.y - 13f, transform.position.z);
                    Instantiate(seaAngel, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x + 4.5f, transform.position.y - 13f, transform.position.z);
                    Instantiate(seaAngel, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x + 7.5f, transform.position.y - 13f, transform.position.z);
                    Instantiate(seaAngel, pos, Quaternion.identity);
                } else if (gotRand == 6) { //Angels n' Stingrays
                    //Sea Angels
                    Vector3 pos = new Vector3(transform.position.x - 4.5f, transform.position.y - 13f, transform.position.z);
                    Instantiate(seaAngel, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x - 1.5f, transform.position.y - 13f, transform.position.z);
                    Instantiate(seaAngel, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x + 1.5f, transform.position.y - 13f, transform.position.z);
                    Instantiate(seaAngel, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x + 4.5f, transform.position.y - 13f, transform.position.z);
                    Instantiate(seaAngel, pos, Quaternion.identity);
                    //Stingrays
                    pos = new Vector3(transform.position.x - 7f, transform.position.y - 14f, transform.position.z);
                    Instantiate(stingray, pos, Quaternion.identity);
                    pos = new Vector3(transform.position.x + 7f, transform.position.y - 15f, transform.position.z);
                    Instantiate(stingray, pos, Quaternion.identity);
                }
            }

        }
        
    }
}
