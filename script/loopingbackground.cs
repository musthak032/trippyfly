using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopingbackground : MonoBehaviour
{
    public gamemanager gamemanager;
    public float backgroundspeed;
    public Sprite[] backgroundsprite;
    public Material back;
    public int changespriteno;
    public SpriteRenderer bgsprite;
    public float durationofpower;

    //public bool poweron;
    bool changemapfull;
    float maintanduration;

    // change sprite
    public float maptimechange;
    float mapchange;

  public backgroundmanager bgmain;

    public GameObject firepart;

  public  CameraMovement cammove;
    float fixcamspeed;

   public player player;
   public mangetimespeed mangetimespeed;
    public spawnobtacle obtacles;

    //optimise

    int runchangemap;
    // Update is called once per frame

    //bool isruncorotine;

    private void Awake()
    {
        //cammove=FindObjectOfType<CameraMovement>().gameObject.GetComponent<CameraMovement>();
        fixcamspeed = cammove.cameraSpeed;
        //bgmain = FindObjectOfType<backgroundmanager>().gameObject;

        if (bgsprite.sprite == null)
        {
            bgsprite.sprite = backgroundsprite[changespriteno];
        }

        maintanduration = durationofpower;

        //
        mapchange = maptimechange;
        if (FindObjectOfType<player>().gameObject != null)
        {
            player = FindObjectOfType<player>();
        }
        if (FindObjectOfType<mangetimespeed>().gameObject != null)
        {
            mangetimespeed = FindObjectOfType<mangetimespeed>();
        }

    }
    private void Start()
    {
        

        //isruncorotine = true;
        //StartCoroutine(loopback());
    }




    //IEnumerator loopback()
    //{
    //        while (isruncorotine)
    //        {

    //        yield return new WaitForSeconds(0);
    //            if (gamemanager.speedpoweron)
    //            {
    //                firepart.SetActive(true);

    //                cammove.cameraSpeed = fixcamspeed * 2f;
    //                back.mainTextureOffset += new Vector2(backgroundspeed * 2f * Time.deltaTime, 0f);

    //                maintainpowerduration();


    //            }
    //            else
    //            {
    //                back.mainTextureOffset += new Vector2(backgroundspeed * Time.deltaTime, 0f);

    //            }

    //            //changemapruntime
    //            runtimechangemap();
              
    //        }

        
       
    //}

    private void Update()
    {
        if (gamemanager.speedpoweron)
        {
            firepart.SetActive(true);

            //cammove.cameraSpeed = fixcamspeed * 2f;
            back.mainTextureOffset += new Vector2(backgroundspeed * 2f * Time.deltaTime, 0f);

            maintainpowerduration();


        }
        else
        {
            back.mainTextureOffset += new Vector2(backgroundspeed * Time.deltaTime, 0f);

        }

        //changemapruntime
        runtimechangemap();

    }



    // chgange sprite on runtime
    void runtimechangemap()
    {
        mapchange -=1* Time.deltaTime;
        if (mapchange < 0)
        {

            mapchange = maptimechange;
             runchangemap = Random.Range(0, backgroundsprite.Length);

            bgsprite.sprite = backgroundsprite[runchangemap];
           
        }

    }
   
    public void maintainpowerduration()
    {
        //if (gamemanager.speedpoweron)
        {
            durationofpower -= Time.deltaTime;
            if (durationofpower <= 0)
            {
                durationofpower = maintanduration;
                gamemanager.speedpoweron = false;
                cammove.cameraSpeed = mangetimespeed.currentspeed; //maintaincurrentspeed
                backgroundspeed = mangetimespeed.currentbgspeed;//
                obtacles.timeBetweenSpawn = mangetimespeed.currentenmemy;//
 

                firepart.SetActive(false);  //firpart
                
                player.destroyenemy();
              

                bgmain.switchstage();
            }
        }
    }

}
