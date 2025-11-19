using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger instance;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private GameObject gameClearText;
    
    public int coinCount = 10;


    

    private void Awake()
    {
        Time.timeScale = 1f;
        instance = this;
        
        gameClearText.gameObject.SetActive(false);

        coinText.text = "REMAIN : " + coinCount;
        //coinText.text = coinCount.ToString();

    }
    private void Update()
    {
        if(coinCount == 0)
        {
            GameClear();
        }
    }

    public void AddCoin()
    {
        coinCount--;
        coinText.text = "REMAIN : " + coinCount;
        //coinText.text = coinCount.ToString();
    }
    private void GameClear()
    {
        gameClearText.gameObject.SetActive(true);
        Time.timeScale = 0f;
        
    }
   
}
