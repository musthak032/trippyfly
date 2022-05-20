using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class backgroundmusic : MonoBehaviour
{
    public static backgroundmusic backgroundMusic;

    public AudioSource bgmusic;
   public bool musicon;
   

    public Sprite offsound;
    public Sprite onsound;

    public bool pause;
    private void Awake()
    {
        if (backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
          
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
       
        musicon = true;
        //soundbutton.sprite = onsound;
    }

    // Update is called once per frame
    void Update()
    {

       

    }

  


    public  void musicoffon(Image sound)
    {
        if (musicon)
        {
            musicon = false;
            bgmusic.Stop();
     
            sound.sprite = offsound;


        }
         else if(!musicon)
        {
            musicon = true;
            bgmusic.Play();
         
            sound.sprite = onsound;
           
        }
    }

}
