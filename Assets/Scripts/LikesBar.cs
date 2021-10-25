using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LikesBar : MonoBehaviour
{

    [SerializeField] private Slider _bar;
    
    public void DecreaseLikeBar(float count)
    {
        _bar.value -= count;
    }
    public void IncreaseLikeBar(float count)
    {
        _bar.value += count;
    }
}