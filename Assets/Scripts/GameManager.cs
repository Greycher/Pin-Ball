using System;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private Transform _ballSpawnPosKeeper;
    [SerializeField] private Rigidbody _ballPrefab;
    [SerializeField] private Vector3 _launchForce;
    
    private bool _once = true;
    private Rigidbody _ball;

    private void Awake() {
        _ball = Instantiate(_ballPrefab, _ballSpawnPosKeeper.position, Quaternion.identity);
    }

    void Update(){
        if (_once && Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Launch!");
            _ball.AddForce(_launchForce);
            _once = false;
        }
    }
}
