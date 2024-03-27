using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerVie : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {
        UIHealth();
    }



    
    [SerializeField] public GameObject[] Heart;
    [SerializeField] public static int health = 3;


    //UI hearth and health system 
    public void UIHealth()
    {
        if (health < 1)
        {
            Heart[0].gameObject.SetActive(false);


            if (health <= 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("Celyan'Scene");

            }

        }
        else if (health < 2)
        {
            Heart[1].gameObject.SetActive(false);
        }
        else if (health < 3)
        {
            Heart[2].gameObject.SetActive(false);
        }
    }






    //TakeDamages in fonction of the monster with the code MonsterDamage
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}

