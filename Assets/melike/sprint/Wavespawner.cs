using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float spawnRate;
    }

public class Wavespawner : MonoBehaviour
{

    public List<Wave> waves = new List<Wave>();
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 5f;

    public TMP_Text waveCountdownText;

    private int currentWaveIndex = 0;
    private bool isSpawning = false;

    public static int enemiesAlive = 0;


    void Update()
    {

        if (enemiesAlive > 0 || isSpawning)
            return;

        if (currentWaveIndex >= waves.Count)
        {
            Debug.Log("Tüm dalgalar tamamlandı!");
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        isSpawning = true;

        Wave wave = waves[currentWaveIndex];

        enemiesAlive = wave.enemyCount;


        for (int i = 0; i < wave.enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(wave.spawnRate);
        }

        currentWaveIndex++;
        isSpawning = false;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

}
