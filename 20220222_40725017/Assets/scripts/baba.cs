using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baba : MonoBehaviour
{
    public GameObject yo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
            yo.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            yo.SetActive(false);
        }
    }
}
