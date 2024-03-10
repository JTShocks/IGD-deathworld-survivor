using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "NewLevelTheme", menuName = "ScriptableObjects/Level Theme", order = 1)]
public class LevelTheme : ScriptableObject
{
    public Tile baseFloorTile;

    public GameObject[] obstacles;

    [Tooltip("The density of Obstacles per 10 tiles of map.")]
    public float obstacleDensity;
    [Tooltip("The amount on either side of Obstacle Density that the amount of obstacles will randomly deviate.")]
    public float obstacleDensityVariance;

    [Header("Enemies"), Tooltip("The types of enemies that can spawn in this level.")]
    public EnemyLevel[] enemyLevels;

    [Serializable]
    public struct EnemyLevel
    {
        public EnemySpawn[] enemies;

        [Serializable]
        public struct EnemySpawn
        {
            public EnemyBehavior prefab;
            public float densityMult;
        }


    }

    public float enemyProgressionInterval;
}
