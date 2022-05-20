using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering;

public class gamemanager : MonoBehaviour
{
   
    public bool speedpoweron;
    public GameObject volume1;
    public GameObject volume2;

    [Header("off time mange")]
    public float time;
    public float timeon;
    float fixedtime;
    bool onvolume;
    // Start is called before the first frame update
    void Start()
    {
        fixedtime = time;
        onvolume = true;
        offvolume();

        volume1.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {

        if (onvolume)
        {

            time -= Time.deltaTime;


            if (time <= 0)
            {

                onvolume = false;
                time = fixedtime;
                 offvolume();
                volume2.SetActive(true);

            }
        }
        if (!onvolume)
        {
            Invoke("offpani", timeon);
        }

        
    }

    void offvolume()
    {

        volume1.SetActive(false);
        volume2.SetActive(false);
    }

    void offpani()
    {
        offvolume();
        volume1.SetActive(true);
        onvolume = true;
    }

}
