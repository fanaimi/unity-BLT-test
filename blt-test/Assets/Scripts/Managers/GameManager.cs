using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BLTtest
{
    /**
     * @obj     === GameManager ===
     * @scene   BLTtest
     * @desc    managing logic and communicating to other managers
     */
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance { get { return _instance; } }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }

            // if we want this to survive throughout different levels and scenes
            DontDestroyOnLoad(gameObject);

        } // Awake


        public bool m_gameOver = true;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
