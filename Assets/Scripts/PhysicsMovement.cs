using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private SurfaceSlider _surfaceSlider;

    [SerializeField] private float _speed;

    public void Move(Vector3 direction) 
    {
        Vector3 directionAlongSurface = _surfaceSlider.Project(direction.normalized);
        Vector3 offset = directionAlongSurface * (_speed * Time.deltaTime);
        _rb.MovePosition(_rb.position + offset);
    }
}