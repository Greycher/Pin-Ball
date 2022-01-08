using UnityEngine;

public class Pusher : MonoBehaviour {
    [SerializeField] private Rigidbody _body;
    [SerializeField] private KeyCode _keyCode;
    [SerializeField] private Vector3 _initialRotation;
    [SerializeField] private Vector3 _finalRotation;
    [SerializeField] private float _speed;
    [SerializeField] private string _ballTag = "Ball";
    [SerializeField] private float _maxPushForce;

    private Rigidbody _ballBody;
    private Vector3 _collisionPos;
    private float _currVal;
    private int _ballTouchCount;
    private float _lastCurrVal;

    private void Update() {
        if (Input.GetKey(_keyCode)) {
            _currVal += _speed * Time.deltaTime;
        }
        else {
            _currVal -= _speed * Time.deltaTime;
        }
        _currVal = Mathf.Clamp(_currVal, 0, 1);
    }


    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag(_ballTag)) {
            if (!_ballBody) {
                _ballBody = other.rigidbody;
            }
            _ballTouchCount++;
            if (_ballTouchCount > 0) {
                _collisionPos = other.contacts[0].point;
            }
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag(_ballTag)) {
            _ballTouchCount--;
            if (_ballTouchCount > 0) {
                _collisionPos = other.contacts[0].point;
            }
        }
    }

    void FixedUpdate() {
        if (_ballTouchCount > 0) {
            var diffVal = _lastCurrVal - _currVal;
            var scaledForce = _maxPushForce * diffVal;
            _ballBody.AddForce((_body.position - _collisionPos).normalized * scaledForce);
        }
        
        transform.localRotation = Quaternion.Euler(Vector3.Lerp(_initialRotation, _finalRotation, _currVal));
        _lastCurrVal = _currVal;
    }
}
