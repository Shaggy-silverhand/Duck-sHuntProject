using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class Movement_Script : MonoBehaviour
{

    [SerializeField] int Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Moving(); 
    }
    
    void Moving()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(-Speed * Time.deltaTime, 0, 0);
        }
    }
}
