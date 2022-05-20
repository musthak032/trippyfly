using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoundbutton : MonoBehaviour
{
    public  backgroundmusic bgmusic;
    public Image soundimage;
    public Button buttononclick;
  
    // Start is called before the first frame update
    void Start()
    {
        buttononclick.onClick.AddListener(handlmusic);
       

       bgmusic= FindObjectOfType<backgroundmusic>();
      
    }

    // Update is called once per frame
    void Update()
    {

        if (bgmusic.musicon)
        {
            soundimage.sprite =bgmusic.onsound;
        }
        else
        {
            soundimage.sprite = bgmusic.offsound;

        }
    }
    public void handlmusic()
    {
        
        backgroundmusic.backgroundMusic.musicoffon(soundimage);
       
    }

  
    
   
    
}
