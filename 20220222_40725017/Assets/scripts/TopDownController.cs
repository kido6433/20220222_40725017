using UnityEngine;

namespace kido
{
    public class TopDownController : MonoBehaviour
    {
        #region ���
        #endregion
        private float speed = 10.5f;
        private string parameterRun = "�}���]�B";
        private string parameterDead = "�}�����`";
        private Animator ani;
        private Rigidbody2D rig;

        #region �ƥ�
        private void Awake()
        {
            //print("�ڬO����ƥ�");

            ani = GetComponent<Animator>();
            rig = GetComponent<Rigidbody2D>();

        }

        private void Update()
        {
            print("�ڦb Update �ƥ�");
        }
        #endregion

        #region ��k
        #endregion
    }
}

