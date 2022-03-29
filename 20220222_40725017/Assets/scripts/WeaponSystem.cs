using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KIDO
{ 
    
    public class WeaponSystem : MonoBehaviour
    {
      
        [SerializeField, Header("�Z�����")]
        private Dataweapon dataWeapon;

        private float timer;
        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            for (int i = 0; i < dataWeapon.v3SpawnPoint.Length; i++)
            {
                Gizmos.DrawSphere(transform.position + dataWeapon.v3SpawnPoint[i], 0.1f);
            }
        }
        private void Update()
        {
            SpawnWeapon();
        }

        public void SpawnWeapon ()
        {
            timer += Time.deltaTime;
            //print("�g�L���ɶ��G" + timer);
            if (timer >= dataWeapon.interval)
            {
                print("�ͦ��Z��");
                timer = 0;
            }
        }
            

    }
}
