using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stageelement : MonoBehaviour
{
    public GameObject obtacles;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float spawnTime=200;
    float timer;
    float randomX;
    float randomY;
    void Update()
    {


        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            spawn();
            timer = 0;

        }



    }

    void spawn()
    {
         randomX = Random.Range(minX, maxX);
         randomY = Random.Range(minY, maxY);

        Instantiate(obtacles, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);

    }
}
