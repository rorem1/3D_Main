using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float coinRot = 30f;
    [SerializeField] private AudioClip coinSound;
    [SerializeField] private GameObject particle;
    
    private void Update()
    {
        transform.Rotate(Vector3.up * coinRot * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.instance.GetCoin(coinSound);
            GameManger.instance.AddCoin();
            Instantiate(particle,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
    

}
