using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PinBall {
    public class GameManager : MonoBehaviour {
        [SerializeField] private Transform _ballSpawnPosKeeper;
        [SerializeField] private GameObject _ballPrefab;
        [SerializeField] private NestBodyCounter _nestBodyCounter;
        [SerializeField] private Text _healthText;
        [SerializeField] private string _healthFormat;
        [SerializeField] private int _totalHealth;
        [SerializeField] private Text _scoreText;
        [SerializeField] private string _scoreFormat;
        [SerializeField] private int _scoreBySeconds;
        [SerializeField] private int _gameOverSceneIndex;

        private int _currentHealth;
        private float _currentScore;

        public const String ScorePrefKey = "Score";
        
        private void Awake() {
            UpdateHealth(_totalHealth);
            UpdateScore(0);
            InstantiateNewBall();
        }
        
        private void Update() {
            if (_nestBodyCounter.BodyCount == 0) {
                UpdateScore(_currentScore + Time.deltaTime * _scoreBySeconds);
            }
        }
        
        private void UpdateHealth(int health) {
            _currentHealth = health;
            _healthText.text = String.Format(_healthFormat, _currentHealth);
        }
        
        private void UpdateScore(float score) {
            _currentScore = score;
            _scoreText.text = String.Format(_scoreFormat, Mathf.FloorToInt(_currentScore));
        }
        
        private void InstantiateNewBall() {
            Instantiate(_ballPrefab, _ballSpawnPosKeeper.position, Quaternion.identity);
        }

        public void OnBallMissed() {
            UpdateHealth(_currentHealth - 1);

            if (_currentHealth == 0) {
                SaveScoreAndLoadGameOverScene();
            }
            else {
                InstantiateNewBall();
            }
        }

        private void SaveScoreAndLoadGameOverScene() {
            PlayerPrefs.SetInt(ScorePrefKey, Mathf.FloorToInt(_currentScore));
            SceneManager.LoadScene(_gameOverSceneIndex);
        }
    }
}