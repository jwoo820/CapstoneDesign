using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
public class ROI : MonoBehaviour
{
    // 1. ROI 평면 부터 계산
    // Start is called before the first frame update
    private int _depthUp, _depthDown, _width, _height;
    void Start()
    {
        _depthUp = 0;
        _depthDown = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
