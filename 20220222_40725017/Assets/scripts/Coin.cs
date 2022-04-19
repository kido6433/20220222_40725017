using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Vector2 speed = new Vector2(0.05f, 0.05f);
    public GameObject targetObject;
    private float rad;
    private Vector2 Position;
    private Animator ani;
    public float time;

    public GameObject coin_g;

    public Vector2 ASUS;
    public bool gogo = false;

    public GM gm;

    // Start is called before the first frame update
    void Start()
    {
        targetObject = GameObject.Find("tg");

        gm = FindObjectOfType<GM>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gogo)
        {
            rad = Mathf.Atan2(
            targetObject.transform.position.y - transform.position.y,
            targetObject.transform.position.x - transform.position.x);
            Position = transform.position;
            Position.x += speed.x * Mathf.Cos(rad);
            Position.y += speed.y * Mathf.Sin(rad);
            transform.position = Position;
        }
        

        ASUS =  new Vector2((Position.x - targetObject.transform.position.x), 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "tg")
        {
            Instantiate(coin_g, (transform.position + new Vector3(0, 0.2f, 0)), Quaternion.identity);
            gm.Coin += 1;
            Destroy(this.gameObject);
        }
        if(collision.name == "ª÷¹ô§l¤Þ½d³ò")
        {
            gogo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "ª÷¹ô§l¤Þ½d³ò")
        {
            gogo = false;
        }
    }
}
