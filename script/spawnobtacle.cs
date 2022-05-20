using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnobtacle : MonoBehaviour
{

    public GameObject obtacles;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
     float spawnTime;

    float randomX;
    float randomY;

   public bool spawnbool;

    int rannum;
    private void Start()
    {
        spawnbool = true;
        StartCoroutine(spawnenemy());
    }

    void calculation()
    {
        if (Time.time > spawnTime)
        {
            spawn();
            spawnTime = Time.time + timeBetweenSpawn;

            rannum = Random.Range(0, 10);
            if (rannum <= 3)
            {
                spawn();
            }
        }


    }

  public  IEnumerator spawnenemy()
    {
        while (spawnbool)
        {
           
           
            yield return new WaitForSeconds(0.1f);
           
            calculation();
        }
    }

    void spawn()
    {
         randomX = Random.Range(minX, maxX);
         randomY = Random.Range(minY, maxY);

        Instantiate(obtacles, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);

    }

}
