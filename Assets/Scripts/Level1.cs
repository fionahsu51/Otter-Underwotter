using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{

    public float enemiesToSpawn;
    //private float progress = 0;
    public GameObject enemyPrefab;
    private float side = 1;
    private bool cleared = false;
    public GameObject chestPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DoCheck");
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesToSpawn == 0 && cleared == false){
            if (GameObject.FindWithTag("Enemy") == null) {
                cleared = true;
                Debug.Log("level done");
                Vector3 pos = new Vector3(0, 2.5f, 0);
                Instantiate(chestPrefab, pos, Quaternion.identity);
            }
        }

    }

    // Adapted from here, thank you marchall_box!
    // https://answers.unity.com/questions/17131/execute-code-every-x-seconds-with-update.html
    IEnumerator DoCheck() {
        for(;;) {
            if(enemiesToSpawn > 0){
                //Debug.Log(enemiesToSpawn);
                makeEnemy(0, 9 * side, Random.Range(-4.5f, 4.5f));
                side *= -1;
                enemiesToSpawn--;
            }
            yield return new WaitForSeconds(1.0f);
        }   
    }

    void makeEnemy(float type, float x, float y){
        Vector3 pos = new Vector3(x, y, 0);
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
}
