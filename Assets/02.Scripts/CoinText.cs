using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinText : MonoBehaviour
{
    [SerializeField] private TextMeshPro coinText;
    [SerializeField] private GameObject coinPrefab;
    private int coinCount = 0;

    private void Update()
    {
        
    }
    //private void GetCoin()
    //{
    //    if(CompareTag("Coin"))
    //    {
    //        Debug.Log("Coin Collected");
    //        coinCount++;

    //        coinText.text = " " + coinCount;
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        
        //코인프리팹이 플레이어와 충돌했을때 점수증가 
        
        if(other.CompareTag("Player"))
        {
            Debug.Log("Coin Collected");
            coinCount++;
            coinText.text = "0" + coinCount;
            
        }
    }
}
