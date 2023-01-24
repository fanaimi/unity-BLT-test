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
        [SerializeField] private Transform m_pool;
        [SerializeField] private Transform m_cubeBlock;
        private float m_maxRange = 19f;
        private float m_cubeSpawnDelay;

        /// <summary>
        /// spawning random collectibles
        /// </summary>
        public void StartGameSpawning()
        {
            // observing cylinder, subscription
            m_cylinder.OnCollected += SpawnCollectible;
            // starting spawning collectibles
            SpawnCollectible();
            SpawnExtraCollectibles();
            // setting random delay to spawn cubeBlock
            m_cubeSpawnDelay = UnityEngine.Random.Range(9f, 15f);
            Invoke("SpawnCubeBlock", m_cubeSpawnDelay);
        }

        /// <summary>
        /// unsubscribing from event
        /// </summary>
        private void OnDisable()
        {
            // unsubscribing
            m_cylinder.OnCollected -= SpawnCollectible;
        }

        /// <summary>
        /// utility methiod to get random position
        /// </summary>
        /// <returns>v3 -> random position</returns>
        private Vector3 GetRandomPosition()
        {
            float randomX = UnityEngine.Random.Range(-m_maxRange, m_maxRange);
            float randomZ = UnityEngine.Random.Range(-m_maxRange, m_maxRange);
            return new Vector3(randomX, 1, randomZ);
        }

        /// <summary>
        /// spawns a random collectible 
        /// </summary>
        private void SpawnCollectible()
        {
            if (GameManager.Instance.m_gameOver) return;
            Vector3 randomPos = GetRandomPosition();
            int randomIndex = UnityEngine.Random.Range(0, m_collectibles.Count);
            Instantiate(m_collectibles[randomIndex], randomPos, Quaternion.identity);
        }

        /// <summary>
        /// keeps spawning random collectibles to give better winning chances
        /// </summary>
        private void SpawnExtraCollectibles()
        {
            float m_extraCollectiblesDelay = UnityEngine.Random.Range(3f, 7f);
            InvokeRepeating("SpawnCollectible", 2, m_extraCollectiblesDelay);
        }

        /// <summary>
        /// soawns ummovable block
        /// </summary>
        private void SpawnCubeBlock()
        {
            if (GameManager.Instance.m_gameOver) return;
            Instantiate(m_cubeBlock, GetRandomPosition(), Quaternion.identity);
            m_cubeSpawnDelay = UnityEngine.Random.Range(3f, 9f);
            Invoke("SpawnCubeBlock", m_cubeSpawnDelay);
        }

    }
}