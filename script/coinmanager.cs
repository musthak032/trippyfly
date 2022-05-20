using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinmanager : MonoBehaviour
{
    public Text cointext;

   public int coinamount;

    public player player;
    void Start()
    {

        if (PlayerPrefs.HasKey("currentcoin"))
        {

            coinamount = PlayerPrefs.GetInt("currentcoin");
        }
        else
        {

            coinamount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.PlayerDeath)
        {
            cointext.text = coinamount.ToString();
            PlayerPrefs.SetInt("currentcoin", coinamount);
        }
        if (player.PlayerDeath)
        {
            PlayerPrefs.SetInt("currentcoin",coinamount);
        }
    }
}
