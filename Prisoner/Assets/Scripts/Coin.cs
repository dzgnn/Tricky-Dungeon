using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip coinPickup;
    [SerializeField] int pointsforCoinPickup = 10;
    bool wasCollected = false;

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToScore(pointsforCoinPickup);

            //AudioSource.PlayClipAtPoint(coinPickup, other.transform.position, 0.5f);
            SoundMnager.instance.FxPlay(3);

            gameObject.SetActive(false);
            Destroy(gameObject);
            
        }
        
    } 

    

}
