using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KIDO
{ 
    
    public class WeaponSystem : MonoBehaviour
    {
      
        [SerializeField, Header("�Z�����")]
        private Dataweapon dataWeapon;
        public Dataweapon dataWeapon2;

        private float timer;
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            for (int i = 0; i < dataWeapon.v3SpawnPoint.Length; i++)
            {
                Gizmos.DrawSphere(transform.position + dataWeapon.v3SpawnPoint[i], 0.1f);
            }
        }

        public void Start()
        {
            Physics2D.IgnoreLayerCollision(3, 6);
            Physics2D.IgnoreLayerCollision(6, 6);
            Physics2D.IgnoreLayerCollision(6, 7);
        }
        private void Update()
        {
            SpawnWeapon();

            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    GameObject tamp = Instantiate(dataWeapon2.goWeapon, (this.transform.position - new Vector3(1.5f, 2, 0)), this.transform.rotation);
                } else
                {
                    GameObject tamp = Instantiate(dataWeapon2.goWeapon, (this.transform.position - new Vector3(-1.5f, 2, 0)), this.transform.rotation);
                }
            }
        }

        public void SpawnWeapon ()
        {
            timer += Time.deltaTime;
            //print("�g�L���ɶ��G" + timer);
            if (timer >= dataWeapon.interval)
            {
               int random =  Random.Range(0, dataWeapon.v3SpawnPoint.Length);
                Vector3 pos = transform.position + dataWeapon.v3SpawnPoint[random];
               // print("�ͦ��Z��");
                GameObject tamp =  Instantiate(dataWeapon.goWeapon, pos, Quaternion.identity);

                tamp.GetComponent<Rigidbody2D>().AddForce(dataWeapon.v3Directing * dataWeapon.speed);
                timer = 0;
            }
        }
            

    }
}
