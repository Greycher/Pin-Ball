using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PinBall {
    public class BallMissDetector : MonoBehaviour {
        [SerializeField] private GameManager _gameManager;
        
        private void OnTriggerEnter(Collider other) {
            _gameManager.OnBallMissed();
        }
    }
}
