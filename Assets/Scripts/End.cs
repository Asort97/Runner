using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class End : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private GameObject _tapButton;
    [SerializeField] private GameObject _end;

    [Space] 
    
    [SerializeField] private GameObject _player;

    private bool _tap;
    private bool isLeft = false;

    private void Start()
    {
        _tapButton.SetActive(true);
    }
    
    private void Update()
    {
        if (!Player.isFinish)
        {
            if (isLeft)
            {
                transform.Translate(Vector3.up * Time.deltaTime * _speed); //up - left
            }
            
            if(!isLeft)
            {
                transform.Translate(Vector3.down * Time.deltaTime * _speed); //down - right
            }
        } 
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RightBarrier"))
        {
            isLeft = true;
        }
        
        if (other.gameObject.CompareTag("LeftBarrier"))
        {
            isLeft = false;
        }
    }

    private IEnumerator CD()
    {
        yield return new WaitForSeconds(0.1f);
        _end.SetActive(false);
    }
    
    public void Tap()
    {
        Player.isFinish = true;
        _tapButton.SetActive(false);
        StartCoroutine(CD());
    }
}