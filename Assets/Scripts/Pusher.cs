using System;
using UnityEngine;

namespace PinBall {
    public class Pusher : MonoBehaviour{
        [SerializeField] private float _force = 1000f;
        [SerializeField] private float _coolDown = 0.6f;

        private float _timer;
        
        private void Update() {
            _timer -= Time.deltaTime;
        }

        private void OnCollisionEnter(Collision other) {
            if (_timer <= 0) {
                var body = other.rigidbody;
                var bodyPos = body.transform.position;
                var collPos = other.contacts[0].point;
                body.AddForce((bodyPos - collPos).normalized * _force, ForceMode.Impulse);
                _timer = _coolDown;
            }
        }
    }
}