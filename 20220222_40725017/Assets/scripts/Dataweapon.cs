using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KIDO
{ 



    [CreateAssetMenu(menuName ="KIDO/Data Weapon",fileName ="Data Weapon")]
    public class Dataweapon: ScriptableObject
    {
        [Header("����t��"), Range(0, 5000)]
        public float speed = 500;
        [Header("�����O"), Range(0, 100)]
        public float attack = 10;
        [Header("�_�l�ƶq"), Range(1, 10)]
        public int countstart = 1;
        [Header("�̤j�ƶq"), Range(1, 20)]
        public int countMax = 3;
        [Header("���j�ɶ�"), Range(0, 5)]
        public float interval = 3.5f;

        [Header("�ͦ���m")]
        public Vector3[] v3SpawnPoint;
        [Header("�Z���w�s��")]
        public GameObject goWeapon;
        [Header("�����V")]
        public Vector3 v3Directing;
    }
}