using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BLTtest
{
    /**
     * @obj     Canvas
     * @scene   BLTtest
     * @desc    managing UI
     */
    public class UiManager : MonoBehaviour
    {

        [SerializeField] private GameObject m_mainMenu;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        public void OnStartClicked() 
        {
            GameManager.Instance.m_gameOver = false;
            m_mainMenu.SetActive(false);
        }
    }
}
