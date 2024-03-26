using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int randNum;
    [SerializeField] public GameObject Obj1, Obj2, Obj3;
    // Start is called before the first frame update
    void Start()
    {
        randNum = Random.Range(0, 3);
        if (randNum == 0 )
        {
            Obj1.SetActive(true);
        }


        randNum = Random.Range(0, 3);
        if (randNum == 1)
        {
            Obj2.SetActive(true);
        }


        randNum = Random.Range(0, 3);
        if (randNum == 2)
        {
            Obj3.SetActive(true);
        }
    }
}
