using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoremanager : MonoBehaviour
{
    [Header("player death")]
    public player player;
    public gamemanager gamemanager;
    public TMP_Text scoreText;

    public float score;

  public  bool firstscore;
    GameObject background;
    public bool changescore;


    public TMP_Text currentscoreTextpause;  
    public TMP_Text currentscoreTextgameover;

    
    bool scorebool;
    private void Start()
    {
        //background = FindObjectOfType<loopingbackground>().gameObject;
        scorebool = true;
        StartCoroutine(scoremange());
    }

    IEnumerator scoremange()
    {
        while (scorebool)
        {



            yield return new WaitForSeconds(0);
            //if (GameObject.FindGameObjectWithTag("Player") != null)
            if (!player.PlayerDeath)
            {

              
                if (gamemanager.speedpoweron)
                {
                    score += 5 * Time.deltaTime;

                }
                else
                {
                    score += 1 * Time.deltaTime;
                }

                //score += 1 * Time.deltaTime;
                scoreText.text = ((int)score).ToString();
                currentscorepannel();

                PlayerPrefs.SetInt("currentscore", (int)score);



                if (PlayerPrefs.GetInt("currentscore") > PlayerPrefs.GetInt("highscore"))
                {
                    changescore = true;
                    PlayerPrefs.SetInt("highscore", PlayerPrefs.GetInt("currentscore"));
                }
               
            }
          
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }


    void currentscorepannel()
    {
        currentscoreTextgameover.text = ((int)score).ToString();
        currentscoreTextpause.text = ((int)score).ToString();

    }
}
