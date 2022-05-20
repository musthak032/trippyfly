using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightoff : MonoBehaviour
{
    public float time;
    public float timeon;
    float fixedtime;

    public GameObject managelight;
    public GameObject playerlight;
    bool lighton;
    [Header("player death")]
    public player player;
    // Start is called before the first frame update
    void Start()
    {
        fixedtime = time;
        lighton = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (lighton)
        {
            time -= Time.deltaTime;
        }
        if (time <= 0 & lighton)
        {
            //if (GameObject.FindObjectOfType<player>() != null)
            if (!player.PlayerDeath)
            {
                managelight.SetActive(false);
                playerlight.SetActive(true);
                time = fixedtime;
                lighton = false;
            }

        }
        if (!lighton)
        {
            Invoke("offlight", timeon);
        }
    }

    void offlight()
    {
        //if (GameObject.FindObjectOfType<player>() != null)
        if (!player.PlayerDeath)
        {
            managelight.SetActive(true);
            playerlight.SetActive(false);
            time = fixedtime;
            lighton = true;
        }
    }
}
