using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
public class PlaneFitting : MonoBehaviour
{
    GroundDetection groundDetection;
    float _y;
    // test1 : 임이의 평면의 y좌표를 변경
    
    // Start is called before the first frame update

    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    private void setPosition(float y)
    {
        y = _y;
    }
}
