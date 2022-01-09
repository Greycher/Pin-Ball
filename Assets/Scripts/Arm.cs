﻿using System;
using UnityEngine;

namespace PinBall {
    public class Arm : MonoBehaviour {
        [SerializeField] private Rigidbody _body;
        [SerializeField] private HingeJoint _hingeJoint;
        // [SerializeField] private Vector3 _initialAngles;
        // [SerializeField] private Vector3 _finalAngles;
        [SerializeField] private KeyCode _keyCode;
        [SerializeField] private float _targetVelocity;

        private float _val;

        private void Update() {
            var motor = _hingeJoint.motor;
            motor.targetVelocity = _targetVelocity * (Input.GetKey(_keyCode) ? 1f : -1f);
            _hingeJoint.motor = motor;
        }
    }
}