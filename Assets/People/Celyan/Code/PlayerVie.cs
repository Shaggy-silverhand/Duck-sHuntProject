using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVie : MonoBehaviour
{
    void Start()
    {
        health = maxHealth;
    }
    void Update()
    {
        UIHealth();
    }




    [SerializeField] public GameObject[] Heart;
    [SerializeField] public int maxHealth;
    [SerializeField] public int health;


    //UI hearth and health system 
    public void UIHealth()
    {
        if (health < 1)
        {
            Destroy(Heart[0].gameObject);


            if (health <= 0)
            {
                Destroy(gameObject);


            }

        }
        else if (health < 2)
        {
            Destroy(Heart[1].gameObject);
        }
        else if (health < 3)
        {
            Destroy(Heart[2].gameObject);
        }
    }






    //TakeDamages in fonction of the monster with the code MonsterDamage
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}

