using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[Serializable]
public class Enemy
{
    public GameObject prefabs;
    [Range(0f, 100f)] public float possiblilty = 100;
    [HideInInspector] public double _weight;
   

}
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy[] enemies;
    private double accumulation;
    private System.Random ran = new System.Random();

    private void Awake()
    {
        Calculations(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            SpawnRandomEnemy(new Vector3(UnityEngine.Random.Range(-50, 50), 0, UnityEngine.Random.Range(-50, 50)));
        }
    }

    private void SpawnRandomEnemy(Vector3 position)
    {
        Enemy randomEnemy = enemies[GetRandomEnemyIndexOf()];
        Instantiate(randomEnemy.prefabs, position,Quaternion.identity, transform);

    }

    private int GetRandomEnemyIndexOf()
    {
        double r = ran.NextDouble() * accumulation;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i]._weight >= r)
            {
                return i;
            }
        }
        return 0;
    }

    private void Calculations()
    {
        accumulation = 0f;
        foreach (Enemy enemy in enemies) 
        {
            accumulation += enemy.possiblilty;
            enemy._weight = accumulation;
        }
    }
}
