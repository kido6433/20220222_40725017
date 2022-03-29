using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KIDO
{ 
    
    public class WeaponSystem : MonoBehaviour
    {
      
        [SerializeField, Header("武器資料")]
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
            //print("經過的時間：" + timer);
            if (timer >= dataWeapon.interval)
            {
                print("生成武器");
                timer = 0;
            }
        }
            

    }
}
