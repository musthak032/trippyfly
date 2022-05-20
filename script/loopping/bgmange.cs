using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmange : MonoBehaviour
{
    public Material mat;
    public gamemanager gamemanager;
    public GameObject firepart;
    public float backgroundspeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if (gamemanager.speedpoweron)
        //{
        //    firepart.SetActive(true);

            
        //    mat.mainTextureOffset += new Vector2(backgroundspeed * 2f * Time.deltaTime, 0f);

       


        //}
        //else
        {
            mat.mainTextureOffset += new Vector2(backgroundspeed * Time.deltaTime, 0f);

        }
    }
}
