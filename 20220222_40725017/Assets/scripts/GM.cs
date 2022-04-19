using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public GameObject ch;
    public float tt = 3f;
    public Vector2 V2;

    public float 怪物生成時間 = 5f;

    public Text Em_T;
    public int Em;
    public Text Coin_T;
    public int Coin;
    public float Exp;
    public float Exp_Max = 100;
    public Text Exp_T;
    public int LV = 1;
    public Text LV_S;
    public float time = 0f;
    public Text Time_T;

    public Image Exp_s;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        tt += Time.deltaTime;
        
        if (tt >= 怪物生成時間)
        {
            V2 = new Vector2(Random.Range(14f, -15f), Random.Range(-2f, -10f));
            In();
            tt = 0;
        }

        Em_T.text = Em.ToString();
        Coin_T.text = Coin.ToString();

        /*
        if(Input.GetKeyDown(KeyCode.E))
        {
            Exp += 10;
        }
        */

        Exp_s.fillAmount = Mathf.Lerp(0, 1, Exp / Exp_Max);

        if(Exp >= Exp_Max)
        {
            Exp = 0;
            Exp_Max += 20;
            LV += 1;
        }

        LV_S.text = "LV." + LV.ToString();
        Time_T.text = getCurrentTime(time);
        Exp_T.text = Exp.ToString() + "/" + Exp_Max.ToString();
    }
    private string getCurrentTime(float time)
    {
        int ime = (int)time;
        if(ime >= 60)
        {
            return string.Format("{0:D2}", ime / 60) + ":" + string.Format("{0:D2}", ime % 60);
        }
        return "00:" + string.Format("{0:D2}", ime);
    }
    void In()
    {
        Instantiate(ch, V2, Quaternion.identity);
    }

}
