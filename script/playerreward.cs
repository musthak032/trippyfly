using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerreward : MonoBehaviour
{

    public gamemanager gamemanager;
    public player player;
    public GameObject gameover;
    public GameObject energyshow;
    public spawnobtacle spawnenemy;
    public bool revive;
   

    public GameObject energyobject;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //spawnplayer();

        StartCoroutine(playergetrevive());
    }

    IEnumerator playergetrevive()
    {
        while (revive)
        {
            yield return new WaitForSeconds(1);
            spawnplayer();
        }

    }
    public void spawnplayer()
    {
        if (revive)
        {
            revive = false;
            player.PlayerDeath = false;
            player.gameObject.SetActive(true);
            //spawnenemy.SetActive(true);
            spawnenemy.spawnbool = true;
            StartCoroutine(spawnenemy.spawnenemy());
            
            gameover.SetActive(false);
            energyshow.SetActive(false);

            //FindObjectOfType<loopingbackground>().poweron = true;
            gamemanager.speedpoweron = true;

        }
    }

    
    public void watchadstorevive()
    {

       
        //adscript.admanager.showrewardedads();
    }

  


}
