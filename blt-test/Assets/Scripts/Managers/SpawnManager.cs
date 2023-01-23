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
        [SerializeField] private List<GameObject> m_pooledCollectibles;
        [SerializeField] private float m_poolingAmount = 20;
        [SerializeField] private Transform m_pool;

        // Start is called before the first frame update
        void Start()
        {
            SetUpPool();
        }

        private void SetUpPool()
        {
            m_pooledCollectibles = new List<GameObject>();
            GameObject tmpGameObject;
            foreach (var collectible in m_collectibles)
            {
                for (int i = 0; i < m_poolingAmount; i++)
                {
                    tmpGameObject = Instantiate(collectible, m_pool);
                    tmpGameObject.SetActive(false);
                    m_pooledCollectibles.Add(tmpGameObject);
                }
            }
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}