using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BLTtest
{

    enum ObjType { Capsule, Sphere }

    public struct SaveData
    {
        public int sd_timeElapsedSecs;
        public int sd_score;
        public int sd_collectedItemsNumber;
    }

    /**
     * @obj     === GameManager ===
     * @scene   BLTtest
     * @desc    managing logic and communicating to other managers
     */
    public class GameManager : MonoBehaviour
    {

        #region singleton
            private static GameManager _instance;
            public static GameManager Instance { get { return _instance; } }

            [SerializeField] private UiManager m_uiManager;

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
        #endregion

        #region properties
            private int m_score;
            private float m_timeElapsedSecs;
            private int m_collectedItemsNumber;
            public int m_currentLevel;
            private float m_timeLeft;

            private bool m_isTimerOn = false;
            private bool m_isTimeTrackerOn = false;
            public bool m_gameOver = true;

            public string m_lastCollected = "nothing";
        #endregion

        /// <summary>
        /// starts game play
        /// </summary>
        public void StartGame()
        {
            m_gameOver = false;
            m_isTimerOn = true;
            m_isTimeTrackerOn = true;
            SetUpStartingUiData();
            m_uiManager.HideGameOverMenu();
        }

        /// <summary>
        /// display game over / win menu 
        /// </summary>
        /// <param name="msg">message to display in game over/win menu</param>
        public void GameOver(string msg)
        {
            m_gameOver = true;
            m_isTimerOn = false;
            m_isTimeTrackerOn = false;

            m_uiManager.SetGameOverTitle(msg);
            m_uiManager.ShowGameOverMenu();
        }

        /// <summary>
        /// restarts game after win / loss
        /// </summary>
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        /// <summary>
        /// injects starting data into ui
        /// </summary>
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

        
        void FixedUpdate()
        {
            UpdateTimeLeftTimer();
            UpdateTimeTracker();
        }

        /// <summary>
        /// updates elapsed time 
        /// </summary>
        private void UpdateTimeTracker()
        {
            if (!m_isTimeTrackerOn) return;
            m_timeElapsedSecs += Time.fixedDeltaTime;

            float minutes = Mathf.FloorToInt(m_timeElapsedSecs / 60);
            float seconds = Mathf.FloorToInt(m_timeElapsedSecs % 60);

            // m_uiManager.UpdateUiField("time", m_timeElapsedSecs.ToString());
            m_uiManager.UpdateUiField("time", string.Format("{0:00}:{1:00}", minutes, seconds));
        }

        /// <summary>
        /// updates countdown timer
        /// </summary>
        private void UpdateTimeLeftTimer()
        {
            if (!m_isTimerOn) return;
            if (m_timeLeft <= 0) GameOver("GAME OVER");

            m_timeLeft -= Time.fixedDeltaTime;
            
            m_uiManager.UpdateUiField("timeLeft", ((int)m_timeLeft).ToString());

        }


        /// <summary>
        /// receives, stores and displays score
        /// </summary>
        /// <param name="scoreToAdd">score to be added</param>
        public void SetScore( int scoreToAdd)
        {
            SetCollectedItemsNumber();
            m_timeLeft = 20;
            m_score += scoreToAdd;
            if (m_score >= 400)
            {
                GameOver("YOU WON!");
                StoreRecords();
            }
            

            m_uiManager.UpdateUiField("score", m_score.ToString());

            SetLevel();
        }

        /// <summary>
        /// stores game data in local machine as JSON
        /// </summary>
        private void StoreRecords()
        {
            // creating a SaveData obj
            SaveData saveData = new SaveData();

            // populating SaveData obj
            saveData.sd_timeElapsedSecs = (int)m_timeElapsedSecs;
            saveData.sd_score = m_score;
            saveData.sd_collectedItemsNumber = m_collectedItemsNumber;

            // serialising SaveData with JSON
            string savedJSON = JsonUtility.ToJson(saveData);

            // saving JSON to PlayerPref
            PlayerPrefs.SetString("gameData", savedJSON);

        }

        /// <summary>
        /// stores and displays collected items
        /// </summary>
        private void SetCollectedItemsNumber()
        {
            m_collectedItemsNumber++;
            m_uiManager.UpdateUiField("collected", m_collectedItemsNumber.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetLevel()
        {
            if (m_score < 100) m_currentLevel = 1;
            if (m_score >= 100 && m_score <200) m_currentLevel = 2;
            if (m_score >= 200 && m_score < 300) m_currentLevel = 3;
            if (m_score >= 300 && m_score < 400) m_currentLevel = 4;

            m_uiManager.UpdateUiField("level", m_currentLevel.ToString());
        }
    }
}
