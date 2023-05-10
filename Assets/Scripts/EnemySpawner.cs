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
    [SerializeField] float spawnRate = 1f;
    [SerializeField] bool canSpawn = true;
    [SerializeField] float countDown;
    private double accumulation;
    private System.Random ran = new System.Random();


    private void Awake()
    {
        Calculations(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
        //for (int i = 0; i < 20; i++)
        //{
        //    SpawnRandomEnemy(new Vector3(UnityEngine.Random.Range(-50, 50), 0, UnityEngine.Random.Range(-50, 50)));
        //}
    }
    private void Update()
    {
        if (countDown <= 0)
        {
            Modificaiton(.1f, .1f);
            countDown = 60f;
        }
        countDown -= Time.deltaTime;
    }
    public void Modificaiton(float healthMod, float speedMod)
    {
        Debug.Log("Upgrade");
        float newHealthMod = AIPlayer.instance.maxhealth * healthMod;
        AIPlayer.instance.maxhealth += newHealthMod;

        float newSpeedMod = AIPlayer.instance.maxSpeed * speedMod;
        AIPlayer.instance.maxSpeed += newSpeedMod;

    }
    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;
            SpawnRandomEnemy(new Vector3(UnityEngine.Random.Range(-30, 30), 0, UnityEngine.Random.Range(-30, 30)));
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
