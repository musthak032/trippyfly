using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float playerspeed;
    private Rigidbody2D rb;
    private Vector2 playerdirection;
    bool moveup;
    public bool PlayerDeath;

    //power
    public float coliderradius;
    public LayerMask obtaclesenmey;
    Collider2D[] protectcircle;

    public GameObject[] playerskin;


    bool mobup;
    bool mobdown;

    private void Awake()
    {
        selectplayerskin();
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
       


      
        PlayerDeath = false;
    }
    void selectplayerskin()
    {
        for(int i = 0; i < playerskin.Length; i++)
        {
            playerskin[i].SetActive(false);
        }
        playerskin[PlayerPrefs.GetInt("whichplayer")].SetActive(true);
    }

    // Update is called once per frame

    private void Update()
    {
        //if (mobup&&mobdown)
        //{
        //    mobup = false;
        //    mobdown = false;

        //}

       
    }


    private void FixedUpdate()
    {
 

        phycollider();

        if (mobup&&!mobdown)
        {
            rb.velocity = new Vector2(0, 1 * playerspeed);
        }
        if (mobdown&&!mobup)
        {

            rb.velocity = new Vector2(0, 1 * -playerspeed);
        }
        if (!mobdown && !mobup)
        {
            rb.velocity = Vector2.zero;
           
        }
     

    }

    public void phycollider()
    {
        protectcircle =Physics2D.OverlapCircleAll((new Vector3(transform.position.x+6,transform.position.y,transform.position.z)), coliderradius, obtaclesenmey);
    }

    public void destroyenemy()
    {
        if (protectcircle != null)
        {
            foreach (Collider2D enemy in protectcircle)
            {

                
                    Destroy(enemy.gameObject);
                
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere((new Vector3(transform.position.x + 6, transform.position.y, transform.position.z)), coliderradius);
    }

    public void playeruptrue()
    {
        mobup = true;
       
    }
    public void playerupfalse()
    {
        mobup = false;
      
    }

    public void playerdowntrue()
    {
        mobdown = true;
    }
    public void playerdownfalse()
    {
        mobdown = false;
    }


}
