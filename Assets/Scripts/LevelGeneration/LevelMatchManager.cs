using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMatchManager : Singleton<LevelMatchManager>
{
    #region     Config Parameters
    [SerializeField] LevelTheme levelTheme;
    //[SerializeField] Wave[] waves;
    [SerializeField] float matchDuration;


    #endregion  Config Parameters

    #region     Components
    LevelGenerator levelGenerator;

    #endregion  Components

    #region     Other Data
    public static float matchTime { get; private set; }
    bool isPaused; //PLACEHOLDER for GameManager Script.
    [HideInInspector] public List<GameObject> enemies = new List<GameObject>(); //Replace GameObject with EnemyScript
    int currentWave;
    float currentWaveTime;
    //float secondCounter;
    bool dropshipAppeared;

    EnemySpawnList currentEnemySpawnList;
    struct EnemySpawnList
    {
        public LevelTheme.EnemyLevel.EnemySpawn[] enemies;
        public float[] spawnBuildup;

        public EnemySpawnList(LevelTheme.EnemyLevel.EnemySpawn[] enemies)
        {
            this.enemies = enemies;
            this.spawnBuildup = new float[enemies.Length];
        }
    }

    #endregion  Other Data




   


    public void InitializeLevel(LevelTheme theme, float matchDuration, Vector2Int levelSize)
    {
        Start();
        levelGenerator.levelSize = levelSize;
        levelGenerator.GenerateLevel(levelTheme);
        matchTime = 0f;
        levelTheme = theme;
        this.matchDuration = matchDuration;
        ActivateWave(0);
    }



    void Start()
    {
        levelGenerator=GetComponent<LevelGenerator>();
    }

    void Update()
    {
        if (GameManager.instance.isPaused) return;
        matchTime += Time.deltaTime;
        currentWaveTime += Time.deltaTime;
        //secondCounter += Time.deltaTime;

        if(currentWaveTime >= levelTheme.enemyProgressionInterval && currentWave < levelTheme.enemyLevels.Length - 1)
        {
            currentWave++;
            currentWaveTime = 0f;
            ActivateWave(currentWave);
        }

        for (int i = 0; i < currentEnemySpawnList.enemies.Length; i++)
        {
            currentEnemySpawnList.spawnBuildup[i] += Time.deltaTime * currentEnemySpawnList.enemies[i].densityMult;
            if (currentEnemySpawnList.spawnBuildup[i] >= 1)
            {
                SpawnEnemy(currentEnemySpawnList.enemies[i].prefab.gameObject);
                currentEnemySpawnList.spawnBuildup[i]--;
            }
        }


        /*
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
         */

        if (matchTime >= matchDuration && !dropshipAppeared) LevelDurationReach();

    }


    void ActivateWave(int level)
    {
        LevelTheme.EnemyLevel.EnemySpawn[] currentLevelArray = levelTheme.enemyLevels[level].enemies;
        LevelTheme.EnemyLevel.EnemySpawn[] previousLevelArray = (level == 0) ? new LevelTheme.EnemyLevel.EnemySpawn[0] : levelTheme.enemyLevels[level-1].enemies;

        LevelTheme.EnemyLevel.EnemySpawn[] enemies = new LevelTheme.EnemyLevel.EnemySpawn[currentLevelArray.Length + previousLevelArray.Length];
        currentLevelArray.CopyTo(enemies, 0); previousLevelArray.CopyTo(enemies, currentLevelArray.Length);
        currentEnemySpawnList = new EnemySpawnList(enemies);
    }

    /*
    void WaveSpawn()
    {
        for (int spawnOption = 0; spawnOption < waves[currentWave].spawnOptions.Length; spawnOption++)
        {
            for (int i = 0; i < (int)waves[currentWave].spawnOptions[spawnOption].densityPerSecond; i++)
            {
                SpawnEnemy(waves[currentWave].spawnOptions[spawnOption].enemy.gameObject);
            }
        }
    }

    [Serializable]
    public struct Wave
    {
        [Serializable]
        public struct EnemySpawn
        {
            public EnemyBehavior enemy;
            public float densityPerSecond;
        }
        public EnemySpawn[] spawnOptions;
        public float waveDuration;
    }
     */

    void SpawnEnemy(GameObject enemy)
    {
        GameObject instance = Instantiate(enemy, levelGenerator.GetRandomSpotInBounds(), Quaternion.identity);
        enemies.Add(instance);
    }

    void LevelDurationReach()
    {
        dropshipAppeared = true;

        //Place Code here for appearence of the Dropship.
    }

}
