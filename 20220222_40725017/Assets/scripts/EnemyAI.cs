using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Vector2 speed = new Vector2(0.05f, 0.05f);
    public GameObject targetObject;
    private float rad;
    private Vector2 Position;
    public GameObject coin;
    public GameObject audio;

    public GM gm; 

    void Start()
    {
        targetObject = GameObject.Find("tg");

        gm = FindObjectOfType<GM>();
    }


    void Update()
    {
        rad = Mathf.Atan2(
            targetObject.transform.position.y - transform.position.y,
            targetObject.transform.position.x - transform.position.x);
        Position = transform.position;
        Position.x += speed.x * Mathf.Cos(rad);
        Position.y += speed.y * Mathf.Sin(rad);
        transform.position = Position;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Weapon")
        {
            gm.Em += 1;

            Instantiate(coin, transform.position, Quaternion.identity);
            Instantiate(audio, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

            gm.Exp += 20;
        }
    }
}
