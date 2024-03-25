using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float life = 2;
    void Awake()
    {
        Destroy(gameObject, life);
    }

}
