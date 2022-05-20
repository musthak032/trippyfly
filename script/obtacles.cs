using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obtacles : MonoBehaviour
{
     gamemanager gamemanager;
    player Player;
    //GameObject bg;
    public GameObject ebursteffect;
    spawnobtacle spawnobject;
    gameover Gameover; ///not necessary
    // Start is called before the first frame update

    private void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
        spawnobject = FindObjectOfType<spawnobtacle>();
        //bg = FindObjectOfType<loopingbackground>().gameObject;
        Gameover = FindObjectOfType<gameover>();
        gamemanager = FindObjectOfType<gamemanager>();
    }
    void Start()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "sideborder")
        {
            Destroy(this.gameObject);
        }
        if (collision.tag == "Player")
        {
            if (!gamemanager.speedpoweron)
            {
                //collision.GetComponent<player>().PlayerDeath=true;
                Player.PlayerDeath = true;
                Instantiate(ebursteffect, transform.position, Quaternion.Euler(-90, 0, 0));
                collision.gameObject.SetActive(false);
                //spawnobject.SetActive(false);
                spawnobject.spawnbool = false;
                StopCoroutine(spawnobject.spawnenemy());
                Gameover.showgameover();

                //show ads
                //adscript.admanager.showinterstitialad();
             
                //
                Destroy(this.gameObject);
            }
            else
            {
                Instantiate(ebursteffect, transform.position,Quaternion.Euler(-90,0,0));
                Destroy(this.gameObject);
            }
        }
    }
}
