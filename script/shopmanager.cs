using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopmanager : MonoBehaviour
{
    public Button[] selectbutton;   
    public Button[] buybutton;

    public int playernum;
    public  string playercharacter="whichplayer";
    public string buyitem = "buyproduct";
    public string selectbuttonbuy = "selectbutton";

    public List<int> whichitembuy = new List<int>();  
    public List<int> whichitembuysaved = new List<int>();
    [Header("coin")]
    public Text currentcoin;

    [Header(" plane valu")]
    public int plane1;
    public int plane2;
  

    int savecount;
    int currentcoinamount;
    void Start()
    {
        if (!PlayerPrefs.HasKey(playercharacter))
        {
            PlayerPrefs.SetInt(playercharacter, playernum);
            selectbutton[playernum].gameObject.SetActive(false);
        }
        else
        {
            
            selectbutton[PlayerPrefs.GetInt(playercharacter)].gameObject.SetActive(false);
        }

        //if (PlayerPrefs.HasKey(buyitem))
        //{


        //    buybutton[PlayerPrefs.GetInt(buyitem)].gameObject.SetActive(false);
        //}
        //else
        //{

        //    PlayerPrefs.SetInt(buyitem, 0);
        //    for(int i=0; i < buybutton.Length; i++)
        //    {
        //        buybutton[i].gameObject.SetActive(true);
        //    }

        //}

        if (PlayerPrefs.HasKey("savecount"))
        {
            loadlist();
          
        }
        if (PlayerPrefs.HasKey("currentcoin"))
        {
            currentcoinamount = PlayerPrefs.GetInt("currentcoin");
            currentcoin.text = currentcoinamount.ToString();
        }
        else
        {
            currentcoin.text = "0";
        }
       

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void slectbuttonwork(int num)
    {

        if (num==0)
        {
          
            foreach(Button button in selectbutton)
            {
                button.gameObject.SetActive(true);
                PlayerPrefs.SetInt(playercharacter, num);
            }
     
            selectbutton[num].gameObject.SetActive(false);
        }  
        if (num==1)
        {
           
            foreach (Button button in selectbutton)
            {
                button.gameObject.SetActive(true);
                PlayerPrefs.SetInt(playercharacter, num);
            }

            selectbutton[num].gameObject.SetActive(false);
        }
        if (num == 2)
        {

            foreach (Button button in selectbutton)
            {
                button.gameObject.SetActive(true);
                PlayerPrefs.SetInt(playercharacter, num);
            }

            selectbutton[num].gameObject.SetActive(false);
        }


    }

    public void buybuttonwork(int buy)
    {

        if (buy == whichitembuy[0])
        {
            if (currentcoinamount >= plane1)
            {
                currentcoinamount -= plane1;
                currentcoin.text = currentcoinamount.ToString();
                PlayerPrefs.SetInt("currentcoin", currentcoinamount);
                buybutton[buy].gameObject.SetActive(false);

                whichitembuysaved.Add(buy);
                savelist();

                //PlayerPrefs.SetInt(buyitem,buy);
                //whichitembuy.Add(buy);
            }
            else
            {
                
            }
        }
        if (buy == whichitembuy[1])
        {
            if (currentcoinamount >= plane2)
            {
                currentcoinamount -= plane2;
                currentcoin.text = currentcoinamount.ToString();
                PlayerPrefs.SetInt("currentcoin", currentcoinamount);
                buybutton[buy].gameObject.SetActive(false);

                whichitembuysaved.Add(buy);
                savelist();
            }
            else
            {
               
            }
        }
     

    }

    void savelist()
    {


        for (int i = 0; i < whichitembuysaved.Count; i++)
        {
            PlayerPrefs.SetInt("savepoint" + i, whichitembuysaved[i]);

           
            //whichitembuysaved.Add(whichitembuy[i]);

        }

        PlayerPrefs.SetInt("savecount", whichitembuysaved.Count);
     
    }
    void loadlist()
    {

        whichitembuysaved.Clear();

        savecount = PlayerPrefs.GetInt("savecount");
        for(int i = 0; i < savecount; i++)
        {
            int itembuy = PlayerPrefs.GetInt("savepoint"+i);
            buybutton[itembuy].gameObject.SetActive(false);
            whichitembuysaved.Add(itembuy);
           
        }
    }

 


}
