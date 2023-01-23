using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BLTtest
{
    /**
     * @obj     Cylinder
     * @scene   BLTtest
     * @desc    movement controller using arrow keys or WASD
     */ 

    public class CylinderController : MonoBehaviour
    {
        private float m_horizontalInput;
        private float m_verticalInput;
        
        // [SerializeField] 
        private float m_speed = 10f;
        [Tooltip("max distance from centre")]
        [SerializeField] 
        private float m_maxRange = 19.5f;



        // Update is called once per frame
        void Update()
        {
            MovePlayer();
        }


        private void MovePlayer()
        {   
            // axis
            m_horizontalInput = Input.GetAxis("Horizontal");
            m_verticalInput = Input.GetAxis("Vertical");

            // horizontal constraints
            if (transform.position.x < -m_maxRange)
            {
                transform.position = new Vector3(
                    -m_maxRange,
                    transform.position.y,
                    transform.position.z);
            }

            if (transform.position.x > m_maxRange)
            {
                transform.position = new Vector3(
                    m_maxRange,
                    transform.position.y,
                    transform.position.z);
            }

            // vertical  constraints
            if (transform.position.z > m_maxRange)
            {
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y,
                    m_maxRange
                );
            }

            if (transform.position.z < -m_maxRange)
            {
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y,
                    -m_maxRange
                );
            }


            // movements
            transform.Translate(
                new Vector3(
                    m_horizontalInput * Time.deltaTime * m_speed,
                    0f,
                    m_verticalInput * Time.deltaTime * m_speed
                )
            );
        }

        // temp - to be moved and refactored
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Collectibles"))
            {
                Destroy(other.gameObject);
                print("collected");
            }
        }

    }
}