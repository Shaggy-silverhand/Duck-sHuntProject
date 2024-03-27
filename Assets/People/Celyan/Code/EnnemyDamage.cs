using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyDamage : MonoBehaviour
{

    [SerializeField] public Spawner spawner;
    [SerializeField] public int damage;
    [SerializeField] public PlayerVie playerVie;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("toucher");
            spawner.Desincrementation();
            playerVie.TakeDamage(damage);
            gameObject.SetActive(false);
        }
     
    }
}