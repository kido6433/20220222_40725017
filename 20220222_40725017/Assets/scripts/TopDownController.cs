using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace kido
{
    public class TopDownController : MonoBehaviour
    {
        #region 資料
        #endregion
        [SerializeField,Header("移動速度"),Range(0,100)]
        private float speed = 10.5f;
        private string parameterRun = "開關跑步";
        private string parameterDead = "開關死亡";
        private string parameterAtk = "開關攻擊";
        private string parameterRoll = "開關迴避";
        private Animator ani;
        private Rigidbody2D rig;
        private float h;
        private float v;

        public GameObject bu;
        public GameObject dodo;

        public GM gm;
        public SpriteRenderer playerColor;
        public int LV_now = 1;
        public GameObject Lvup;
        public bool roll = false;
        public float time;

        public Color now;

        #region 事件
        private void Awake()
        {
            //print("我是喚醒事件");

            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();
            gm = FindObjectOfType<GM>();
            now = playerColor.color;
        }

        private void Update()
        {
            GetInput();
            Move();

            if(Input.GetKeyDown(KeyCode.Space))
            {
                ani.SetBool(parameterAtk, true);
            } else
            {
                ani.SetBool(parameterAtk, false);
            }

            if(Input.GetKeyDown(KeyCode.Z))
            {
                ani.SetBool(parameterRoll, true);
                roll = true;
            } else
            {
                ani.SetBool(parameterRoll, false);
            }

            if (gm.LV > LV_now)
            {
                float r = UnityEngine.Random.Range(0f, 1f);
                float g = UnityEngine.Random.Range(0f, 1f);
                float b = UnityEngine.Random.Range(0f, 1f);
                playerColor.color = new Color(r, g, b, 1);

                LV_now = gm.LV;
                now = playerColor.color;

                Instantiate(Lvup, (transform.position + new Vector3(0, -2f, 0)), Quaternion.identity);
            }

            if(roll)
            {
                
                time += Time.deltaTime;
                speed = 21f;
                gameObject.GetComponent<Collider2D>().enabled = false;
                playerColor.color = Color.red;
                if(time >= 0.5f)
                {
                    time = 0;
                    speed = 10.5f;
                    playerColor.color = now;
                    gameObject.GetComponent<Collider2D>().enabled = true;
                    roll = false;
                }
            }
        }
        #endregion

        #region 方法
        #endregion

        private void GetInput()
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            //print("取得水平軸像值：" + h);

        }

        private void Move()
        {
            rig.velocity = new Vector2(h, v) * speed;

            ani.SetBool(parameterRun, h != 0 || v != 0  );

            transform.eulerAngles = new Vector3(0, h >= 0 ? 0 : 180, 0) ;

            if(transform.position.x >= 12.8f)
            {
                transform.position = new Vector3(12.8f, transform.position.y, transform.position.z);
            }
            if (transform.position.x <= -14.8f)
            {
                transform.position = new Vector3(-14.8f, transform.position.y, transform.position.z);
            }
            if (transform.position.y >= 11.5f)
            {
                transform.position = new Vector3(transform.position.x, 11.5f, transform.position.z);
            }
            if (transform.position.y <= -7.2f)
            {
                transform.position = new Vector3(transform.position.x, -7.2f, transform.position.z);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Door")
            {
                dodo.SetActive(false);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Enemy")
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
                ani.SetBool(parameterDead, true);
                StartCoroutine(ExampleCoroutine());
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Door")
            {
                dodo.SetActive(true);
            }
        }

        IEnumerator ExampleCoroutine()
        {
            yield return new WaitForSeconds(1);
            bu.SetActive(true);
            Time.timeScale = 0;
            
        }

        public void Re()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }

}

