using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PinBall {
    public class GameOver : MonoBehaviour {
        [SerializeField] private Button _playAgainButton;
        [SerializeField] private int _gameSceneIndex;
        [SerializeField] private Text _scoreText;
        [SerializeField] private string _scoreFormat;

        private void Awake() {
            _scoreText.text = String.Format(_scoreFormat, PlayerPrefs.GetInt(GameManager.ScorePrefKey));
        }

        private void OnEnable() {
            _playAgainButton.onClick.AddListener(LoadGameScene);
        }

        private void LoadGameScene() {
            SceneManager.LoadScene(_gameSceneIndex);
        }

        private void OnDisable() {
            _playAgainButton.onClick.RemoveListener(LoadGameScene);
        }
    }
}
