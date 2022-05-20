using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmanager : MonoBehaviour
{
    public int startmap;
    public GameObject[] backgrounds;

    public float switchtime;
    float contime;
    void Start()
    {
        for(int i=0; i<backgrounds.Length; i++)
        {
            backgrounds[i].SetActive(false);
        }
        //int num = Random.Range(0, backgrounds.Length);
        backgrounds[startmap].SetActive(true);
        contime = switchtime;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void switchbg()
    {
        contime -= 1 * Time.deltaTime;
        if (contime < 0)
        {
            for (int i = 0; i < backgrounds.Length; i++)
            {
                backgrounds[i].SetActive(false);
            }
           int num=Random.Range(0, backgrounds.Length);
            backgrounds[num].SetActive(true);
            contime = switchtime;
        }
    }
   public void switchstage()
    {


        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].SetActive(false);
        }
        int num = Random.Range(0, backgrounds.Length);
        backgrounds[num].SetActive(true);
        contime = switchtime;
    }
}
