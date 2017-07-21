using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : StatusControls {

    public GameObject MinionPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countDown = 2f;

    public int towerHp=2000;
    public int towerAtk = 50;
    

    private void Awake()//earlier than statuscontrols.start
    {
        maxHp = towerHp;
        atk = towerAtk;
    }

    void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime;
    }

    IEnumerator SpawnWave() // 미니언들은 5마리씩 뽑는다.
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(MinionPrefab, spawnPoint.position, spawnPoint.rotation);
    }
  //아직 미니언 뽑는것 까지 밖에 구현 안됨.
}
