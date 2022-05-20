using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
     coinmanager coinmange;

    // Start is called before the first frame update
    void Start()
    {
        coinmange = FindObjectOfType<coinmanager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "sideborder")
        {
            Destroy(this.gameObject);
            Destroy(this.gameObject.transform.parent.gameObject);

        }
        if (collision.tag == "Player")
        {
            coinmange.coinamount++;

            Destroy(this.gameObject.transform.parent.gameObject);
            Destroy(this.gameObject);
        }
    }
}
