using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class openscreenmanager : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject openpannels;
    public GameObject shoppannels;
    [Header("planeshop")]
    public GameObject planecollection;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void closeallpannels()
    {
        openpannels.SetActive(false);
        shoppannels.SetActive(false);
        planecollection.SetActive(false);
    }

    public void startgame()
    {
        SceneManager.LoadScene("level1");

    }

    public void quiteapp()
    {
        Application.Quit();
    }

    public void openshop()
    {
        closeallpannels();
        shoppannels.SetActive(true);
        planecollection.SetActive(true);
    }
    public void closeshop()
    {
        closeallpannels();
        openpannels.SetActive(true);
       
    }
}
