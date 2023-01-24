using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        [SerializeField] private GameObject m_gameOverMenu;
        [SerializeField] private TextMeshProUGUI m_scoreValue;
        [SerializeField] private TextMeshProUGUI m_timeValue;
        [SerializeField] private TextMeshProUGUI m_collectedValue;
        [SerializeField] private TextMeshProUGUI m_levelValue;
        [SerializeField] private TextMeshProUGUI m_timeLeftValue;
        [SerializeField] private TextMeshProUGUI m_gameOverTitle;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ShowGameOverMenu() => m_gameOverMenu.SetActive(true);
        public void ShowMainMenu() => m_mainMenu.SetActive(true);
 

        public void HideGameOverMenu() => m_gameOverMenu.SetActive(false);
        public void HideGMainMenu() => m_mainMenu.SetActive(false);


        public void SetGameOverTitle(string msg)
        {
            m_gameOverTitle.text = msg;
        }

        public void OnStartClicked() 
        {
            GameManager.Instance.StartGame();
            m_mainMenu.SetActive(false);
        }

        public void UpdateUiField(string field, string value)
        {
            switch (field)
            {
                case "score":
                    m_scoreValue.text = value;
                    break;

                case "time":
                    m_timeValue.text = value;
                    break;

                case "collected":
                    m_collectedValue.text = value;
                    break;

                case "level":
                    m_levelValue.text = value;
                    break;

                case "timeLeft":
                    m_timeLeftValue.text = value;
                    break;
            }
        }
    }
}
