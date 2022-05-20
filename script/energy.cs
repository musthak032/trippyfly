using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class energy : MonoBehaviour
{
    public static energy energymanager;

    [SerializeField] Text energyText;
    [SerializeField] Text timerText;
    [SerializeField] Slider energyBar;

    private int maxEnergy=25;
    private int currentEnergy;
    private int restartDuration=5;

    private DateTime nextEnergyTime;
    private DateTime lastEnergyTime;
    private bool isRestoring = false;


    public bool isrewardenergy;

    private void Awake()
    {
       
    }

   
    // Start is called before the first frame update
    void Start()
    {

   

        if (!PlayerPrefs.HasKey("currentenergy"))
        {
            PlayerPrefs.SetInt("currentenergy", maxEnergy);
            load();
            StartCoroutine(restoreenergy());

        }
        else
        {
            load();
            StartCoroutine(restoreenergy());
        }
    }

    public void usenergy()
    {
        if (currentEnergy >= 1)
        {
            currentEnergy--;
            updateenergy();
            if (isRestoring == false)
            {
                if (currentEnergy + 1 == maxEnergy)
                {
                    nextEnergyTime = addduration(DateTime.Now, restartDuration);
                }
                StartCoroutine(restoreenergy());
            }

            SceneManager.LoadScene("level1");
        }
        else
        {
            Debug.Log("insufficient energy");
        }
    }

    private IEnumerator restoreenergy()
    {
        updateenergytimer();
        isRestoring = true;
        while (currentEnergy < maxEnergy)
        {
            DateTime currentdatetime = DateTime.Now;
            DateTime nextdatetime = nextEnergyTime;
            bool isenergyadding = false;
            while (currentdatetime > nextdatetime)
            {
                if (currentEnergy < maxEnergy)
                {
                    isenergyadding = true;
                    currentEnergy++;
                   
                    updateenergy();

                    DateTime timetoadd = lastEnergyTime > nextdatetime ? lastEnergyTime : nextdatetime;
                    nextdatetime = addduration(timetoadd, restartDuration);
                }
                else
                {
                    break;
                }
            }
            adtoboostenergy(); // adsreward

            if (isenergyadding == true)
            {
                lastEnergyTime = DateTime.Now;
                nextEnergyTime = nextdatetime;
            }
            updateenergytimer();
            updateenergy();
            save();
            yield return null;
        }
        isRestoring = false;
    }

    public void adtoboostenergy()
    {

        if (isrewardenergy)
        {
            currentEnergy = currentEnergy + 5;

            isrewardenergy = false;

        }

    }

    private DateTime addduration(DateTime datetime,int duration)
    {
        return datetime.AddMinutes(duration);
        //return datetime.AddMinutes(duration);
    }

    private void updateenergytimer()
    {
        if (currentEnergy >= maxEnergy)
        {
            timerText.text = "full";
            return;
        }

        TimeSpan time = nextEnergyTime - DateTime.Now;
        string timevalue = string.Format("{0:00}:{1:00}", time.Minutes, time.Seconds);
        timerText.text = timevalue;

    }
    private void updateenergy()
    {
        energyText.text = currentEnergy.ToString() + "/" + maxEnergy.ToString();
        energyBar.maxValue = maxEnergy;
        energyBar.value = currentEnergy;
    }
    private DateTime stringtodate(string datetime)
    {
        if (String.IsNullOrEmpty(datetime))
        {
            return DateTime.Now;
        }
        else
        {
            return DateTime.Parse(datetime);
        }
    }

    private void load()
    {
        currentEnergy = PlayerPrefs.GetInt("currentenergy");
        nextEnergyTime = stringtodate(PlayerPrefs.GetString("nextenergytime"));
        lastEnergyTime = stringtodate(PlayerPrefs.GetString("lastenergytime"));
    }
    private void save()
    {
        PlayerPrefs.SetInt("currentenergy", currentEnergy);
        PlayerPrefs.SetString("nextenergytime", nextEnergyTime.ToString());    
        PlayerPrefs.SetString("lastenergytime", lastEnergyTime.ToString());
    }
}
