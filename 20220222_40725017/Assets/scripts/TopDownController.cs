using UnityEngine;

namespace kido
{
    public class TopDownController : MonoBehaviour
    {
        #region 資料
        #endregion
        private float speed = 10.5f;
        private string parameterRun = "開關跑步";
        private string parameterDead = "開關死亡";
        private Animator ani;
        private Rigidbody2D rig;

        #region 事件
        private void Awake()
        {
            //print("我是喚醒事件");

            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();

        }

        private void Update()
        {
            print("我在 Update 事件內");
        }
        #endregion

        #region 方法
        #endregion
    }
}

