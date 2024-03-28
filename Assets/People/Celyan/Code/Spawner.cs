using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public int randNum;
    [SerializeField]public static int Reloader = 0;
    [SerializeField] public GameObject Obj1, Obj2, Obj3;


    // Start is called before the first frame update
    void Start()
    {
        RandomNum();
        //Debug.Log(Reloader);
        
        
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) || Reloader <= 0)
        {
            SceneManager.LoadScene("Celyan'Scene");
        }

    }


    public void RandomNum()
    {
        randNum = Random.Range(0, 3);
        if (randNum == 0)
        {
            Obj1.SetActive(true);
            Reloader += 1;

        }


        randNum = Random.Range(0, 3);
        if (randNum == 1)
        {
            Obj2.SetActive(true);
            Reloader += 1;

        }


        randNum = Random.Range(0, 3);
        if (randNum == 2)
        {
            Obj3.SetActive(true);
            Reloader += 1;

        }
    }
    public void Desincrementation()
    {
        Reloader -= 1;
        Debug.Log(Reloader);
    }
}
