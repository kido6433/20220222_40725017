using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Del : MonoBehaviour
{
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(this.gameObject.name == "Coin_Get(Clone)")
        {
            if(time >= 0.4f)
            {
                Destroy(gameObject);
            }
        }
        if (this.gameObject.name == "Âû¦º±¼°Õ(Clone)")
        {
            if (time >= 1.12f)
            {
                Destroy(gameObject);
            }
        }
        if (this.gameObject.name == "LvUp(Clone)")
        {
            if (time >= 1.3f)
            {
                Destroy(gameObject);
            }
        }
    }
}
