using UnityEngine;

namespace kido
{
    public class TopDownController : MonoBehaviour
    {
        #region ���
        #endregion
        [SerializeField,Header("���ʳt��"),Range(0,100)]
        private float speed = 10.5f;
        private string parameterRun = "�}���]�B";
        private string parameterDead = "�}�����`";
        private Animator ani;
        private Rigidbody2D rig;
        private float h;
        private float v;

        #region �ƥ�
        private void Awake()
        {
            //print("�ڬO����ƥ�");

            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();

        }

        private void Update()
        {
            GetInput();
            Move();
        }
        #endregion

        #region ��k
        #endregion

        private void GetInput()
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            //print("���o�����b���ȡG" + h);

        }

        private void Move()
        {
            rig.velocity = new Vector2(h, v) * speed;

            ani.SetBool(parameterRun, h != 0 || v != 0  );

            transform.eulerAngles = new Vector3(0, h >= 0 ? 0 : 180, 0) ;
        }
    }
}

