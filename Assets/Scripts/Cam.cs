using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] private float _stoppingDistance;
    [SerializeField] private float _speed;
    [SerializeField] private float _retReatDistance;
    
    [SerializeField] private Transform _player;
    
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - _player.position;
    }

    private void FixedUpdate () 
    {
        Vector3 desiredPosition = new Vector3(transform.position.x, _player.position.y + offset.y, _player.position.z + offset.z);
        Vector3 SmoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _speed);
        transform.position = SmoothedPosition;
    }
}