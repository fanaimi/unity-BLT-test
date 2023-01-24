using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace BLTtest
{
    /**
     * @obj     === SpawnManager ===
     * @scene   BLTtest
     * @desc    manages random collectibles using Object Pooling
     */

    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private CylinderCollisionController m_cylinder;
        [SerializeField] private List<GameObject> m_collectibles;
        [SerializeField] private float m_poolingAmount = 10;
        [SerializeField] private Transform m_pool;
        [SerializeField] private Transform m_cubeBlock;
        private float m_maxRange = 19f;
        private float m_cubeSpawnDelay;

        // Start is called before the first frame update
        public void StartGameSpawning()
        {
            // observing cylinder, subscription
            m_cylinder.OnCollected += SpawnCollectible;
            // starting spawning collectibles
            SpawnCollectible();
            // setting random delay to spawn cubeBlock
            m_cubeSpawnDelay = UnityEngine.Random.Range(9f, 15f);
            Invoke("SpawnCubeBlock", m_cubeSpawnDelay);
        }


        private void OnDisable()
        {
            // unsubscribing
            m_cylinder.OnCollected += SpawnCollectible;
        }

        private Vector3 GetRandomPosition()
        {
            float randomX = UnityEngine.Random.Range(-m_maxRange, m_maxRange);
            float randomZ = UnityEngine.Random.Range(-m_maxRange, m_maxRange);
            return new Vector3(randomX, 1, randomZ);
        }

        private void SpawnCollectible()
        {
            if (GameManager.Instance.m_gameOver) return;
            Vector3 randomPos = GetRandomPosition();
            int randomIndex = UnityEngine.Random.Range(0, m_collectibles.Count);
            Instantiate(m_collectibles[randomIndex], randomPos, Quaternion.identity);
        }

        private void SpawnCubeBlock()
        {
            if (GameManager.Instance.m_gameOver) return;
            Instantiate(m_cubeBlock, GetRandomPosition(), Quaternion.identity);
            m_cubeSpawnDelay = UnityEngine.Random.Range(3f, 9f);
            Invoke("SpawnCubeBlock", m_cubeSpawnDelay);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}