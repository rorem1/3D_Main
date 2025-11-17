using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] private GameObject randomSpawn;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private int maxCoinCount = 50;
    private int curCoinCount = 0;

    BoxCollider spawnCollider;

    private void Awake()
    {
        spawnCollider = randomSpawn.GetComponent<BoxCollider>();
        StartCoroutine(RandomSpawnCo());
    }
    Vector3 RandomPosition()
    {
        Vector3 originPos = randomSpawn.transform.position;

        float rangeX = spawnCollider.bounds.size.x;
        float rangeZ = spawnCollider.bounds.size.z;

        rangeX = Random.Range((rangeX / 2) * -1, rangeX / 2);
        rangeZ = Random.Range((rangeZ / 2) * -1, rangeZ / 2);
        Vector3 randomPos = new Vector3(rangeX, 3.0f, rangeZ);

        Vector3 respawnPos = originPos + randomPos;
        return respawnPos;
    }
    IEnumerator RandomSpawnCo()
    {
        while (true)
        {
            if(maxCoinCount <= curCoinCount)
            {
                yield break;
            }
            yield return new WaitForSeconds(1f);

            GameObject coin = Instantiate(coinPrefab,RandomPosition(), Quaternion.identity);
            curCoinCount++;

            Destroy(coin, 3f);
        }
    }
}
