using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneFitting
{
    public class Fitting
    {
        private Queue<float> list = new Queue<float>(500);

        public void Ransac()
        {
            // init data
                // y = data
                // x = index
            foreach (Vector3 i in GroundDetection._planeCenterList)
            {
                // data
                list.Enqueue(i.y);
            }

        }
    }
}

