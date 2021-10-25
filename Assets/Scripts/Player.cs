using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{

    public static bool isFinish;
    [SerializeField] private Transform _endPoint1;
    [SerializeField] private Transform _endPoint2;

    [SerializeField] private GameObject _cameraForward;
    [SerializeField] private GameObject _cameraLeft;
    [SerializeField] private GameObject _cameraRight;
    [SerializeField] private GameObject _end;

    [SerializeField] private Animator _anim;
    [SerializeField] private Slider _barLiker;
    [SerializeField] private LikesBar _likesManager;
    [SerializeField] private GameObject _blockLedder;
    [SerializeField] private PhysicsMovement _movement;
    [SerializeField] private float _speedUp;
    [SerializeField] private int _hp;
    
    [Space]
    

    [SerializeField] private int _damage;
    [SerializeField] private int _plus;
    
    private Rigidbody rb;
    
    private bool isDead;
    private int _levelCount;
    private bool isUp;

    private float _interval = 0.2f;

    private int _rotationBlock;
    private Vector3 _directionMove = new Vector3(0, 0, 1);

    private void Start()
    {
        _end.SetActive(false);
        rb = GetComponent<Rigidbody>();
        _levelCount = PlayerPrefs.GetInt("Level");
    }
    
    private void Update()
    {
        if(_barLiker.value > 0f && Menu.isStart)
        {
            if (Input.GetMouseButton(0))
            {
                _likesManager.DecreaseLikeBar(Time.deltaTime * 25f);
                spawnBlockLedderUp(0.2f);
                isUp = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                isUp = false;
            }       
        }
        else if(_barLiker.value <= 0f)
        {
            isDead = true;
            isUp = false;
        }
    }
    
    private void FixedUpdate()
    {
        if(Player.isFinish)
        {
            transform.rotation = Quaternion.Euler(0f, -15f, 0f);
            transform.position = Vector3.Lerp(transform.position, _endPoint1.position, 1f * Time.deltaTime);
        }
        if(!isDead && Menu.isStart)
        {
            _movement.Move(_directionMove);
        }
        if(isUp)
        {
            rb.velocity = (Vector3.up * _speedUp * Time.deltaTime);
        }
        else
        {
            rb.AddForce(Vector3.down * 1, ForceMode.Impulse);
        }
    }
    
    private void spawnBlockLedderUp(float startTime)
    {
        if(_interval <= 0f)
        {
            Vector3 _pos = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            GameObject _block = Instantiate(_blockLedder, _pos, Quaternion.identity);
            if(_rotationBlock == 0)
            {
                _block.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            if(_rotationBlock == 1)
            {
                _block.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            }

            _interval = startTime;
        }
        else
        {
            _interval -= Time.deltaTime;
        }
    }

    IEnumerator RotatePlayer(float _toRotate)
    {
        float timeElapsed = 0;
        
        while (timeElapsed < 4f)   
        {
            Quaternion rot = Quaternion.Euler(transform.rotation.x, transform.rotation.y + _toRotate, transform.rotation.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * 10f);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("RotateLeft"))
        {
            StartCoroutine(RotatePlayer(-90f));
            _rotationBlock = 1;
            _directionMove = new Vector3(-1, 0, 0);
        }
        if(other.gameObject.CompareTag("RotateRight"))
        {
            _rotationBlock = 1;
            StartCoroutine(RotatePlayer(90f));
            _directionMove = new Vector3(1, 0, 0);
        }
        if(other.gameObject.CompareTag("RotateForward"))
        {
            _rotationBlock = 0;
            StartCoroutine(RotatePlayer(-transform.rotation.y));
            _directionMove = new Vector3(0, 0, 1);
        }

        if (other.gameObject.CompareTag("Hater"))
        {
            _likesManager.DecreaseLikeBar(20f);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Subber"))
        {
            _likesManager.IncreaseLikeBar(40f);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Like"))
        {
            _likesManager.IncreaseLikeBar(40f);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Dislike"))
        {
            _likesManager.DecreaseLikeBar(20f);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("End"))
        {
            Menu.isStart = false;
            _end.SetActive(true);
        }
        
        if (other.gameObject.CompareTag("Finish"))
        {
            
            if (_hp > 0)
            {
                _levelCount += 1;
                PlayerPrefs.SetInt("Level", _levelCount);
                //win
            }

            if (_hp <= 0)
            {
                //lose
            }
        }
    }

    public void X3()
    {
        
    }
    public void X4()
    {
        
    }
}