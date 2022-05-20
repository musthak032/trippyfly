using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mangetimespeed : MonoBehaviour
{
    public gamemanager gamemanager;
    public CameraMovement camspeed;
    public spawnobtacle enemy;
   public loopingbackground[] background;

    [Header("player death")]
    public player player;

    public float speedcalculation;

    public float mincamspeed;
    public float maxenemy;
    public float maxbackground;

    float speed;

    public float currentspeed; //cameraspeedtopassvalue
    public float currentbgspeed;
    public float currentenmemy;


    float speedcalbg;
    float speedstorebg;  
    float speedcalenemy;
    float speedstoreenemy;

    bool iscoro;
    void Start()
    {
        //background = GameObject.FindObjectOfType<loopingbackground>();

        currentspeed = camspeed.cameraSpeed;
        currentbgspeed = background[0].backgroundspeed;
        currentenmemy = enemy.timeBetweenSpawn;
        //iscoro = true;
        //StartCoroutine(update());
    }

    IEnumerator update()
    {

        while (iscoro)
        {
            yield return new WaitForSeconds(1f);
            timetochange();
        }
    }

    void Update()
    {
        timetochange();
    }

    public void timetochange()
    {
        //if (!gamemanager.speedpoweron && (GameObject.FindObjectOfType<player>() != null) && !backgroundmusic.backgroundMusic.pause)
        if (!gamemanager.speedpoweron && (!player.PlayerDeath) && !backgroundmusic.backgroundMusic.pause)
        {
            //cameramovewithtime();
        
            bgmovewithtime();
            enmyspawnwithtime();


        }

    }

  

    private void cameramovewithtime()
    {

        if (camspeed.cameraSpeed != mincamspeed)
        {
            speedcalculation += 1 * Time.deltaTime;
            //speedcalculation = speedcalculation / 2;
            if (speedcalculation > speed)
            {
                speed = speedcalculation;
                camspeed.cameraSpeed -= .0001f;

                if (camspeed.cameraSpeed <= mincamspeed)
                {
                    camspeed.cameraSpeed = mincamspeed;
                }
                currentspeed = camspeed.cameraSpeed;

            }
        }
    }
    private void bgmovewithtime()
    {
        for (int i = 0; i < background.Length; i++)
        {
            if (background[i].backgroundspeed != maxbackground)
            {

                speedcalbg += 1 * Time.deltaTime;
                //speedcalbg = speedcalbg / 10f;  //waste

                //speedcalculation = speedcalculation / 2;
                if (speedcalbg >= speedstorebg)
                {
                    speedstorebg = speedcalbg;

                    background[i].backgroundspeed += .0001f / 1000;

                    if (background[i].backgroundspeed >= maxbackground)
                    {
                        background[i].backgroundspeed = maxbackground;
                    }
                    currentbgspeed = background[i].backgroundspeed;

                }
            }
        }
    }
    private void enmyspawnwithtime()
    {
        if (enemy.timeBetweenSpawn != maxbackground)
        {

            speedcalenemy += 1 * Time.deltaTime;
            //speedcalenemy = speedcalenemy / 10f;           
            //speedcalenemy = speedcalenemy / 2f; //waste

            //speedcalculation = speedcalculation / 2;
            if (speedcalenemy >= speedstoreenemy)
            {
                speedstoreenemy = speedcalenemy;

                enemy.timeBetweenSpawn -= .0001f / 1000;

                if (enemy.timeBetweenSpawn <= maxenemy)
                {
                    enemy.timeBetweenSpawn = maxenemy;
                }
                currentenmemy = enemy.timeBetweenSpawn;

            }
        }
    }



}
