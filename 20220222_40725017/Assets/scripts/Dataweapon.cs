using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KIDO
{ 



    [CreateAssetMenu(menuName ="KIDO/Data Weapon",fileName ="Data Weapon")]
    public class Dataweapon: ScriptableObject
    {
        [Header("飛行速度"), Range(0, 5000)]
        public float speed = 500;
        [Header("攻擊力"), Range(0, 100)]
        public float attack = 10;
        [Header("起始數量"), Range(1, 10)]
        public int countstart = 1;
        [Header("最大數量"), Range(1, 20)]
        public int countMax = 3;
        [Header("間隔時間"), Range(0, 5)]
        public float interval = 3.5f;

        [Header("生成位置")]
        public Vector3[] v3SpawnPoint;
        [Header("武器預製物")]
        public GameObject goWeapon;
        [Header("飛行方向")]
        public Vector3 v3Directing;
    }
}