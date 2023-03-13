using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFish : MonoBehaviour
{

    public GameObject[] fishLeft;
    public GameObject[] fishRight;
    public GameObject jellyfish;
    private float halfLength;
    private float halfHeight;
    private float fishSpawnInterval;
    private float jellySpawnInterval;
    private float fishTime;
    private float /*peanutbutter*/jellyTime;
    
    private float sunFishSpawnInterval;
    private float sunJellySpawnInterval;


    // Start is called before the first frame update
    void Start()
    {
        halfLength = 10f;
        halfHeight = 6f;
        fishTime = 0f;
        /*peanutbutter*/jellyTime = 0f;
        fishSpawnInterval = 0.3f;
        /*peanutbutter*/jellySpawnInterval = 0.6f;

        sunFishSpawnInterval = fishSpawnInterval;
        sunJellySpawnInterval = jellySpawnInterval;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= -80f) {
            fishSpawnInterval = sunFishSpawnInterval;
            /*peanutbutter*/jellySpawnInterval = sunJellySpawnInterval;
        } else if (transform.position.y < -80f) {
            fishSpawnInterval = sunFishSpawnInterval * 3f;
            /*peanutbutter*/jellySpawnInterval = sunJellySpawnInterval * 3f;
        }

        fishTime += Time.deltaTime;
        if (fishTime > fishSpawnInterval ) {
            fishTime = 0f;
            float atY = Random.Range(transform.position.y - halfHeight * 1.5f, transform.position.y + halfHeight * 1.5f);
            int leftOrRight = Random.Range(0, 2);
            if (leftOrRight == 0) { //left
                GameObject randFish = fishLeft[Random.Range(0, fishLeft.Length)];
                Vector3 pos = new Vector3(transform.position.x + halfLength, atY, transform.position.z);
                Instantiate(randFish, pos, Quaternion.identity);
            }
            else if (leftOrRight == 1) { //right
                GameObject randFish = fishRight[Random.Range(0, fishLeft.Length)];
                Vector3 pos = new Vector3(transform.position.x - halfLength, atY, transform.position.z);
                Instantiate(randFish, pos, Quaternion.identity);
            }
        }

        /*peanutbutter*/jellyTime += Time.deltaTime;
        if (/*peanutbutter*/jellyTime > /*peanutbutter*/jellySpawnInterval) {
            /*peanutbutter*/jellyTime = 0f;
            float atX = Random.Range(transform.position.x - halfLength * 1.5f, transform.position.x + halfLength * 1.5f);
            Vector3 pos = new Vector3(atX, transform.position.y - halfHeight, transform.position.z);
            Instantiate(/*peanutbutter*/jellyfish, pos, Quaternion.identity);
        }
        
    }
}
