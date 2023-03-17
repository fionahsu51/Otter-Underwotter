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

    // Start is called before the first frame update
    void Start()
    {
        spawnInterval = 4f;
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= spawnInterval) {
            time = 0f;
            int gotRand = 0;
            if (transform.position.y > -77f) {
                gotRand = Random.Range(0, 4);
            }
            else gotRand = Random.Range(3, 6);

            gotRand = 0;
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

        }
        
    }
}
