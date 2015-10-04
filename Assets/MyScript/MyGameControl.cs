using UnityEngine;
using System.Collections;

public class MyGameControl : MonoBehaviour
{
    float screenWidth = Screen.width;
    float screenHeight = Screen.height;
    public GameObject enemyPrefab;
    public GameObject powerUp;
    public Transform playerTrans;
    public static bool hasPowerUp = false;
    int spawnNum = 6;
    float spawnTime = 3;

    // Use this for initialization
    void Start()
    {
        playerTrans = GameObject.Find("Cube").GetComponent<Transform>();
        Invoke("EnemySpawn", spawnTime);
        Debug.Log("width" + screenWidth);
        Debug.Log("height" + screenHeight);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void EnemySpawn()
    {
        int t = spawnNum;
        //Random a = new Random();
        int a = Random.Range(0, 2);
        int b = Random.Range(0, 2);
        if (a == 0) a = -1;
        if (b == 0) b = -1;
        Instantiate(enemyPrefab, playerTrans.position + new Vector3(a * Random.Range(2, 9), 0, b * Random.Range(2, 3)), Quaternion.identity);
        Instantiate(enemyPrefab, playerTrans.position + new Vector3(-a * Random.Range(2, 9), 0, -b * Random.Range(2, 3)), Quaternion.identity);
        if (Random.Range(-5, 10) > 5 && !hasPowerUp)
        {
            Instantiate(powerUp, playerTrans.position + new Vector3(a * Random.Range(2, 9), 0, b * Random.Range(2, 3)), Quaternion.identity);
            hasPowerUp = true;
        }
        if (spawnTime > 0.5f) spawnTime = spawnTime / 1.3f;
        else spawnTime = 0.5f;
        Invoke("EnemySpawn", spawnTime);
    }
}
