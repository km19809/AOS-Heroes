using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1Tower : MonoBehaviour {

    public GameObject T1MinionPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    private float countDown = 2f;

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
        Instantiate(T1MinionPrefab, spawnPoint.position, spawnPoint.rotation);
    }
  //아직 미니언 뽑는것 까지 밖에 구현 안됨.
}
