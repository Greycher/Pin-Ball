using System;
using UnityEngine;

namespace PinBall {
    public class Pusher : MonoBehaviour {
        [SerializeField] private Rigidbody _body;
        [SerializeField] private Vector3 _initialAngles;
        [SerializeField] private Vector3 _finalAngles;
        [SerializeField] private KeyCode _keyCode;
        [SerializeField] private float _speed;

        private float _val;

        private void Update() {
            if (Input.GetKey(_keyCode)) {
                _val += _speed * Time.deltaTime;
            }
            else {
                _val -= _speed * Time.deltaTime;
            }
            _val = Mathf.Clamp(_val, 0, 1);
        }

        private void FixedUpdate() {
            var targetAngles = Vector3.Lerp(_initialAngles, _finalAngles, _val);
            var targetRot = Quaternion.Euler(targetAngles);
            _body.centerOfMass = Vector3.zero;
            // _body.MoveRotation(targetRot);
            var rot = transform.rotation;
            var rotateDiff = Quaternion.Inverse(rot) * targetRot;
            Debug.Log($"rotate diff angles: {rotateDiff.eulerAngles}");
            _body.angularVelocity = rotateDiff.eulerAngles / Time.deltaTime *  Mathf.Deg2Rad;
        }

        // private Vector3 JustifyAngle(Vector3 angles) {
        //     return new Vector3(
        //         JustifyAngle(angles.x),
        //         JustifyAngle(angles.y),
        //         JustifyAngle(angles.z));
        // }
        //
        // private float JustifyAngle(float angle) {
        //     while (angle > 360) {
        //         angle -= 360;
        //     }
        //     while (angle < 0) {
        //         angle += 360;
        //     }
        //
        //     return angle;
        // }
    }
}