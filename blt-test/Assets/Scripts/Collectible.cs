using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BLTtest
{


    /**
     * @obj     Sphere / Capsule prefab
     * @scene   BLTtest
     * @desc    storing internal 
     */
    public class Collectible : MonoBehaviour
    {
        private int score;

        [SerializeField] ObjType m_type;

        /// <summary>
        /// calculates score according to collectible type and current level
        /// </summary>
        /// <returns></returns>
        public int CalculateCollectibleScore()
        {
            switch (GameManager.Instance.m_currentLevel)
            {
                case 1:
                    if (m_type == ObjType.Sphere) score = 1;
                    if (m_type == ObjType.Capsule) score = 2;
                    break;

                case 2:
                    if (m_type == ObjType.Sphere) score = 10;
                    if (m_type == ObjType.Capsule) score = 12;
                    break;

                case 3:
                    if (m_type == ObjType.Sphere) score = 20;
                    if (m_type == ObjType.Capsule) score = 22;
                    break;

                case 4:
                    if (m_type == ObjType.Sphere) score = 30;
                    if (m_type == ObjType.Capsule) score = 32;
                    break;

            }


            return score;
        }

        /// <summary>
        /// return collectible type
        /// </summary>
        /// <returns>type</returns>
        public new string GetType()
        {
            return m_type.ToString();
        }

    }
}
