using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace BLTtest
{
    /**
     * @obj     Cylinder
     * @scene   BLTtest
     * @desc    collision controller 
     */
    public class CylinderCollisionController : MonoBehaviour
    {
        public event Action OnCollected;
        private int m_multiplyer;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Collectibles"))
            {
                Collectible thisCollectible = other.gameObject.GetComponent<Collectible>();

                m_multiplyer =
                    GameManager.Instance.m_lastCollected == thisCollectible.GetType() ?
                    -2 : 1;

                GameManager.Instance.SetScore(
                    thisCollectible.CalculateCollectibleScore() * m_multiplyer);

                GameManager.Instance.m_lastCollected = thisCollectible.GetType();


                Destroy(other.gameObject);
                if(OnCollected != null) OnCollected();
            }
        }

    }
}
