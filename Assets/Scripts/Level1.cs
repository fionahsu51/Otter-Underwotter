using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{

    //With help from this video. Thank you Code Monkey!
    //https://www.youtube.com/watch?v=gbFBWxtpgpQ

    public float enemiesToSpawn;
    //private float progress = 0;
    public Enemy[] enemyArray;
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
                Vector3 pos = new Vector3(0, 2.5f, 0);
                Instantiate(chestPrefab, pos, Quaternion.identity);
            }
        }

    }

    // Adapted from here, thank you marchall_box!
    // https://answers.unity.com/questions/17131/execute-code-every-x-seconds-with-update.html
    IEnumerator DoCheck() {
        foreach(Enemy enemy in enemyArray) {
            //Debug.Log(enemiesToSpawn);
            if(enemy.name == "PufferFish"){
                Vector3 pos = new Vector3(9*side, Random.Range(-4.5f, 4.5f), 0);
                Instantiate(enemy, pos, Quaternion.identity);
            }else if(enemy.name == "Sea Angel"){
                Vector3 pos = new Vector3(Random.Range(-2.5f, 2.5f), -4.5f, 0);
                Instantiate(enemy, pos, Quaternion.identity);
            }else{

            }
            
            side *= -1;
            enemiesToSpawn--;
            yield return new WaitForSeconds(1.0f);
        }   
    }
}
