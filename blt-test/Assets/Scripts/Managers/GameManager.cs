using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        [SerializeField] private UiManager m_uiManager;

        private int m_score;
        private float m_timeElapsedSecs;
        private int m_collectedItemsNumber;
        private int m_currentLevel;
        private float m_timeLeft;

        private bool m_isTimerOn = false;

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
            // DontDestroyOnLoad(gameObject);

        } // Awake


        public bool m_gameOver = true;

        public void StartGame()
        {
            m_gameOver = false;
            m_isTimerOn = true;
            SetUpStartingUiData();
            m_uiManager.HideGameOverMenu();
        }

        public void GameOver()
        {
            m_gameOver = true;
            m_isTimerOn = false;
            m_uiManager.ShowGameOverMenu();
        }


        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void SetUpStartingUiData()
        {
            m_score = 0;
            m_timeElapsedSecs = 0;
            m_collectedItemsNumber = 0;
            m_currentLevel = 1;
            m_timeLeft = 20;
            m_uiManager.UpdateUiField("score", m_score.ToString());
            m_uiManager.UpdateUiField("time", m_timeElapsedSecs.ToString());
            m_uiManager.UpdateUiField("collected", m_collectedItemsNumber.ToString());
            m_uiManager.UpdateUiField("level", m_currentLevel.ToString());
            m_uiManager.UpdateUiField("timeLeft", m_timeLeft.ToString());

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            UpdateTimeLeftTimer();
        }

        private void UpdateTimeLeftTimer()
        {
            if (!m_isTimerOn) return;
            if (m_timeLeft <= 0) GameOver();

            m_timeLeft -= Time.fixedDeltaTime;
            
            m_uiManager.UpdateUiField("timeLeft", ((int)m_timeLeft).ToString());

        }
    }
}
