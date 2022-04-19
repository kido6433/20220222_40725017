using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class baba : MonoBehaviour
{
    public GameObject yo;
    public bool time = false;
    public float tt;
    public bool cc = false;
    public VideoPlayer VP;

    public float fadeSpeed = 1;
    public RawImage rawImage;

    public GameObject cam1, cam2;

    // Start is called before the first frame update
    void Start()
    {
        rawImage.color = Color.clear;
        VP.targetCameraAlpha = 0;
        VP.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if(time == true)
        {
            tt += Time.deltaTime;
        }
        else if(time == false)
        {
            tt = 0;
            cc = false;
            cam1.SetActive(true);
            cam2.SetActive(false);
            VP.Pause();
        }

        if(tt >= 3)
        {
            cc = true;
        }

        if(tt >= 6)
        {
            cc = false;
            cam1.SetActive(false);
            cam2.SetActive(true);
            //VP.targetCameraAlpha = Mathf.Lerp(VP.targetCameraAlpha, 100, Time.deltaTime * fadeSpeed * 0.5f);
            VP.Play();
        }

        if (cc == false)
        {
            rawImage.color = Color.Lerp(rawImage.color, Color.clear, Time.deltaTime * fadeSpeed * 0.5f);//���G
            VP.targetCameraAlpha = Mathf.Lerp(VP.targetCameraAlpha, 100, Time.deltaTime * fadeSpeed * 0.5f);
            //if (rawImage.color.a < 0.1f)
            //{
            //    rawImage.color = Color.clear;
            //}
        }
        else if (cc)
        {
            rawImage.color = Color.Lerp(rawImage.color, Color.black, Time.deltaTime * fadeSpeed * 0.5f);//���t
            VP.targetCameraAlpha = Mathf.Lerp(VP.targetCameraAlpha, 0, Time.deltaTime * fadeSpeed * 0.5f);
            //if (rawImage.color.a > 0.9f)
            //{
            //    rawImage.color = Color.black;
            //}
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            yo.SetActive(true);
            time = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            yo.SetActive(false);
            time = false;
        }
    }
}
