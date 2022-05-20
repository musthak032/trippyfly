using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class stageswitch : MonoBehaviour
{
     gamemanager gamemanager;
    public bool isnextstage=false;
    GameObject background;
    GameObject bgmain;

    private void Awake()
    {
       
        bgmain = FindObjectOfType<backgroundmanager>().gameObject;
        gamemanager = FindObjectOfType<gamemanager>();

    }
    void Start()
    {
        background = FindObjectOfType<loopingbackground>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!gamemanager.speedpoweron)
            {
                gamemanager.speedpoweron = true;
            }
            if (gamemanager.speedpoweron)
            {
                
                background.GetComponent<loopingbackground>().durationofpower = background.GetComponent<loopingbackground>().durationofpower + 10;
            }
        
            Destroy(this.gameObject);
        }
        if (collision.tag == "sideborder")
        {
            Destroy(this.gameObject);
        }
    }
   
}
