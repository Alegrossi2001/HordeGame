using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager1 : MonoBehaviour
{
    //this is the list of all active enemies on the map
    public List<GameObject> enemies = new List<GameObject>();
    //this is the array where we store all enemies. 
    [SerializeField] private GameObject[] enemyArray = new GameObject[1];

    //wave system
    private int waveCount;
    private int waveOnLevel = 7;
    private float waveTextTimer;
    private float spawnRate = 1.0f;
    private float timesBetweenWaves = 1.0f;
    [SerializeField] private Text wavesText;
    private int enemyOnMap;

    private int wave;

    private bool isWaveActive = true;
    private bool stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waveSpawner());
        enemyOnMap = 20;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void AddEnemyToList(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    IEnumerator waveSpawner()
    {
        while(isWaveActive == true && stopSpawning == false)
        {
            Vector3 spawnPos = new Vector3(UnityEngine.Random.Range(-20f, 20f), UnityEngine.Random.Range(-20f, 20f), 0);
            isWaveActive = false;
            wavesText.text = "Wave " + waveCount + 1;
            for (int i = 0; i < waveOnLevel; i++)
            {
                for(int n = 0; n < enemyOnMap; n++)
                {
                    GameObject enemy = enemyArray[0];
                    Instantiate(enemy, spawnPos, transform.rotation);
                    AddEnemyToList(enemy);
                    enemyOnMap += UnityEngine.Random.Range(20, 30);
                }
                GameObject enemyClone = Instantiate(enemyArray[0], spawnPos, Quaternion.identity);
                yield return new WaitForSeconds(spawnRate);
            }
        }
    }

    public void EndEnemyWaves()
    {
        stopSpawning= true;
        GameObject[] en = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in en)
        {
            GameObject.Destroy(enemy);
        }
    }
}
