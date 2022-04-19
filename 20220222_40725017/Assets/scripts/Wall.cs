using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public SpriteRenderer coco;

    public bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (open)
        {
            coco.color = Color.Lerp(coco.color, new Color32(255, 255, 255, 150), Time.deltaTime * 2);
        }
        else if (open == false)
        {
            coco.color = Color.Lerp(coco.color, new Color32(255, 255, 255, 255), Time.deltaTime * 2);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "tg")
        {
            open = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "tg")
        {
            open = false;
        }
    }
}
