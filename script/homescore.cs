using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class homescore : MonoBehaviour
{
    public TMP_Text highscore;
   scoremanager scormange;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            highscore.text = PlayerPrefs.GetInt("highscore").ToString();
        }
        else
        {
            PlayerPrefs.SetInt("highscore", 0);
           
        }
        if (FindObjectOfType<scoremanager>()!= null)
        {
            scormange = FindObjectOfType<scoremanager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scormange != null)
        {
            if (scormange.changescore)
            {
                if (PlayerPrefs.HasKey("highscore"))
                {
                    highscore.text = PlayerPrefs.GetInt("highscore").ToString();
                }
                else
                {
                    PlayerPrefs.SetInt("highscore", 0);

                }
                scormange.changescore = false;
            }
        }
    }
}
