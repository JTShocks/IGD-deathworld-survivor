using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMatchManager : Singleton<LevelMatchManager>
{
    #region     Config Parameters
    [SerializeField] LevelTheme levelTheme;
    [SerializeField] Wave[] waves;


    #endregion  Config Parameters

    #region     Components
    LevelGenerator levelGenerator;

    #endregion  Components

    #region     Other Data
    public static float matchTime { get; private set; }
    bool isPaused; //PLACEHOLDER for GameManager Script.
    [HideInInspector] public List<GameObject> enemies = new List<GameObject>(); //Replace GameObject with EnemyScript
    int currentWave;
    float waveBeginTime = 0;
    float secondCounter;

    #endregion  Other Data







    void Start()
    {
        levelGenerator.GenerateLevel(levelTheme);
        matchTime = 0f;
    }

    void Update()
    {
        if (isPaused) return;
        matchTime += Time.deltaTime;
        secondCounter += Time.deltaTime;

        if (matchTime - waveBeginTime >= waves[currentWave].waveDuration)
        {
            waveBeginTime = matchTime;
            currentWave++;
        }

        if(secondCounter >= 1f)
        {
            secondCounter--;
            WaveSpawn();
        }

    }

    void WaveSpawn()
    {
        for (int spawnOption = 0; spawnOption < waves[currentWave].spawnOptions.Length; spawnOption++)
        {
            for (int i = 0; i < (int)waves[currentWave].spawnOptions[spawnOption].densityPerSecond; i++)
            {
                SpawnEnemy(waves[currentWave].spawnOptions[spawnOption].enemy);
            }
        }
    }

    [Serializable]
    public struct Wave
    {
        [Serializable]
        public struct EnemySpawn
        {
            public GameObject enemy;
            public float densityPerSecond;
        }
        public EnemySpawn[] spawnOptions;
        public float waveDuration;
    }

    void SpawnEnemy(GameObject enemy)
    {
        GameObject instance = Instantiate(enemy, levelGenerator.GetRandomSpotInBounds(), Quaternion.identity);
        enemies.Add(instance);
    }

}
