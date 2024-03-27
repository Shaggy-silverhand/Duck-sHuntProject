using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    private int randNum;
    [SerializeField]public static int Reloader = 0;
    [SerializeField] public static int ReloaderMax = 0;
    [SerializeField] public GameObject Obj1, Obj2, Obj3;
    // Start is called before the first frame update
    void Start()
    {
        RandomNum();
        Debug.Log(Reloader);
        ReloaderMax = Reloader;
        
    }

    private void FixedUpdate()
    {
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Reloader-= 1;
            Debug.Log(Reloader);
            
        }
        ReloadVar();
    }


    private void RandomNum()
    {
        randNum = Random.Range(0, 2);
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
    public void ReloadVar()
    { 

        if (Obj1.activeInHierarchy)
        {
            Debug.Log("Toujours la");
        }
        else if (Obj2.activeInHierarchy) 
        {
            Reloader -= 1;
            Debug.Log("Toujours la 2");
        }
        else if (Obj3.activeInHierarchy)
        {
            Reloader -= 1;
            Debug.Log("Toujours la 3");
        }else
        {
            Reloader -= 1;
            if (Reloader ==0)
            {
                SceneManager.LoadScene("Celyan'Scene");
            }
            
        }



    }
}
