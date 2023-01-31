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
        public float m_horizontalInput;
        public float m_verticalInput;
        
        // [SerializeField] 
        public float m_speed = 10f;
        [Tooltip("max distance from centre")]
        [SerializeField] 
        private float m_maxRange = 19.5f;

        public Vector3 newPos;

        // Update is called once per frame
        void Update()
        {
            MovePlayer();
        }

        /// <summary>
        /// movement controller
        /// </summary>
        private void MovePlayer()
        {
            if (GameManager.Instance.m_gameOver) return;
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

             newPos = new Vector3(
                    m_horizontalInput * Time.deltaTime * m_speed,
                    0f,
                    m_verticalInput * Time.deltaTime * m_speed
                );

            // movements
            transform.Translate(newPos);
        }
    }
}