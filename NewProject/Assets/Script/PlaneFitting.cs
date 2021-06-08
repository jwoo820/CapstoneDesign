using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using namespace PlaneFitting
{
    public class PlaneFitting : MonoBehaviour
    {
        GroundDetection groundDetection;
        float _y = 0;
        // test1 : 임의의 평면의 y축을 변경
        // plane Center의 값 조절
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

}
