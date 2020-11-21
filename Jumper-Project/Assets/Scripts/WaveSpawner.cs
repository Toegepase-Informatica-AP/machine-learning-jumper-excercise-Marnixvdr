using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform obstaclePrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    //het duurt 2sec voor de eerste obstacle spawnt
    private float countdown = 2f;
    //aantal obstacle die per wave komen
    private int waveNumber = 0;
    private float waitSec = 0.5f;
  
    private void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        //na elke sec gaat er -1 van af
        countdown  -= Time.deltaTime;
    }
    //in deze methode kan met nu een pauze insteken
    IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            spawnObstacle();
            yield return new WaitForSeconds(waitSec);
        }
        if(waveNumber >= 4)
        {
            waveNumber = 0;
        }
    }
    
    /*
    private void Start()
    {
        Invoke("spawnObstacle", Random.Range(1.0f, 3.5f));
    }*/
    //aanmaken van obstacle
    void spawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
