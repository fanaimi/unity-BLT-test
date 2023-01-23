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

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Collectibles"))
            {
                Destroy(other.gameObject);
                if(OnCollected != null) OnCollected();
            }
        }

    }
}
