using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyDamage : MonoBehaviour
{


    [SerializeField] public int damage;
    [SerializeField] public PlayerVie playerVie;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("toucher");
            playerVie.TakeDamage(damage);
            gameObject.SetActive(false);
        }
     
    }
}