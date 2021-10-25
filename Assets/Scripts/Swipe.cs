using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    [SerializeField]private GameObject _target;
    
    [SerializeField]private float m_Speed;
    
    [SerializeField]private Slider SliderDis;
    
    private void Update()
    {
        // _target.transform.position = new Vector3(SliderDis.value, _target.transform.position.y, _target.transform.position.z);
        Vector3 _newPos = new Vector3(SliderDis.value, _target.transform.position.y, _target.transform.position.z);
        // Transform _transformPos = _newPos; 
        _target.transform.position = Vector3.Lerp(_target.transform.position, _newPos, 10f * Time.deltaTime);
    }
}