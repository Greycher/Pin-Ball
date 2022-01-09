using System;
using System.Collections;
using System.Collections.Generic;
using PinBall;
using UnityEngine;

namespace PinBall {
    public class Launcher : MonoBehaviour {
        [SerializeField] private Rigidbody _body;
        [SerializeField] private float _minForce;
        [SerializeField] private float _maxForce;
        [SerializeField] private float _maxReleaseDuration = 2f;

        private bool _pressed;
        private float _pressedDuration;

        private void Update() {
            if (!_pressed) {
                if (Input.GetKeyDown(KeyCode.DownArrow)) {
                    _pressed = true;
                }
            }
            else {
                if (Input.GetKeyUp(KeyCode.DownArrow)) {
                    _pressed = false;
                    _pressedDuration = 0;
                }
            }
        }

        private void FixedUpdate() {
            if (_pressed) {
                _pressedDuration += Time.deltaTime;
                var force = Mathf.Lerp(_minForce, _maxForce, _pressedDuration / _maxReleaseDuration);
                _body.AddForce(Vector3.down * force);
            }
        }
    }
}
