using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    //change to name of enemy prefabs for multiple
    public Transform enemyPrefab;
    public Transform SpawnPoint;

    public float timeBetweenWaves = 3f;
    private float countdown = 2f;
    private int waveIndex = 0;
    //add a text UI for this to hold
    //public Text waveCountDown;

    private void Update()
    {
        if(countdown <= 0)
        {
            StartCoroutine(SpawnWave());

            countdown = timeBetweenWaves;

        }

        countdown -= Time.deltaTime;
        //wont work till UI is added for public wave count down
        //waveCountDown.text = Mathf.Round(countdown).ToString();

    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }

        
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }

}
