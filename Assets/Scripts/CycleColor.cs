using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CycleColor : MonoBehaviour
{
    [SerializeField] float transitionSpeed = 1f;

    Renderer rend;

    int currentIndex = 0;
    int nextIndex = 1;
    float t;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        Color randomColor = Random.ColorHSV();
        rend.material.color = randomColor;
    }
}
