using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMovement1 : MonoBehaviour
{
    private float speed = 5f;
    ScoreScript ScoreScript;
    // Start is called before the first frame update
    void Start()
    {
        speed += 0.1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            ScoreScript.scoreCount += 50;
            Destroy(other.gameObject);
        }
    }
}
