using UnityEngine;

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
        private Animator ani;
        private Rigidbody2D rig;
        private float h;
        private float v;

        #region 事件
        private void Awake()
        {
            //print("我是喚醒事件");

            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();

        }

        private void Update()
        {
            GetInput();
            Move();
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
        }
    }
}

