using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace BLTtest
{
    /**
     * @obj     SpawnManager
     * @scene   BLTtest
     * @desc    manages random collectibles using Object Pooling
     */

    public class SpawnManager : MonoBehaviour
    {

        [SerializeField] private List<GameObject> m_collectibles;
        [SerializeField] private float m_poolingAmount = 10;
        [SerializeField] private Transform m_pool;
        private float m_maxRange = 19f;

        // Start is called before the first frame update
        void Start()
        {
            SpawnCollectible();
        }

        private void SpawnCollectible()
        {
            float randomX = UnityEngine.Random.Range(-m_maxRange, m_maxRange);
            float randomZ = UnityEngine.Random.Range(-m_maxRange, m_maxRange);
            Vector3 randomPos = new Vector3(randomX, 1, randomZ);

            int randomIndex = UnityEngine.Random.Range(0, m_collectibles.Count);
            Instantiate(m_collectibles[randomIndex], randomPos, Quaternion.identity);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}