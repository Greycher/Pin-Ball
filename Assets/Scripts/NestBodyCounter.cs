using System;
using UnityEngine;

namespace PinBall {
    public class NestBodyCounter  : MonoBehaviour {
        private int _bodyCount;

        public int BodyCount => _bodyCount;

        private void OnTriggerEnter(Collider other) {
            _bodyCount++;
        }

        private void OnTriggerExit(Collider other) {
            _bodyCount--;
        }
    }
}