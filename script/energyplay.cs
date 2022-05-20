using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class energyplay : MonoBehaviour
{
    // play system
    public energy energyuse;
    public Button playbutton;
    // Start is called before the first frame update
    void Start()
    {
        playbutton.onClick.AddListener(playgamewithenergy);
        energyuse = FindObjectOfType<energy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playgamewithenergy()
    {
        energyuse.usenergy();

    }
}
