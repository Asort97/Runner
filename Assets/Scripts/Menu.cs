using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private Text _levelText;
    public static bool isStart;
    private int _levelCount;
    
    void Start()
    {
        _levelCount = PlayerPrefs.GetInt("Level");
        
        _levelCount += 1;
        _levelText.text = "Level " + _levelCount;
    }

    public void StartTap()
    {
        _anim.SetBool("isRunning", true);
        Menu.isStart = true;
        gameObject.SetActive(false);
    }
}