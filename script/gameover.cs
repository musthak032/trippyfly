using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public GameObject gameOverPannel;
    public GameObject pausepannel;
    public GameObject pausebutton;
    public GameObject energyshow;
    
    float handlepause;
    // Update is called once per frame
    void Update()
    {
        
       
    }

    public void showgameover()
    {
        gameOverPannel.SetActive(true);
        energyshow.SetActive(true);
    }
    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void pause()
    {
        handlepause = Time.timeScale;
        Time.timeScale = 0;
        pausepannel.SetActive(true);
        pausebutton.SetActive(false);
        energyshow.SetActive(true);

        backgroundmusic.backgroundMusic.pause = true;

    } 
    public void unpause()
    {

        Time.timeScale =handlepause;
        pausepannel.SetActive(false);
        pausebutton.SetActive(true);
        energyshow.SetActive(false);
        backgroundmusic.backgroundMusic.pause = false;


    }
    public void loadhomescreen()
    {
        Time.timeScale = handlepause;
        SceneManager.LoadScene(0);
    }

    public void unlocktime()
    {
        Time.timeScale = handlepause;
    }

    
   
  

}
