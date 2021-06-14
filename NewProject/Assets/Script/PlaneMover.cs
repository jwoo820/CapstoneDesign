using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
public class PlaneMover : MonoBehaviour
{

    // Start is called before the first frame update
    Vector3 convert = new Vector3(0, 0, 0);
    Vector3 real;

    // Update is called once per frame
    void Update()
    {
        Quaternion quaternion = Frame.Pose.rotation;
        convert = quaternion.eulerAngles;
        real = new Vector3(0, convert.y, 0);
        transform.rotation = Quaternion.Euler(real);
        transform.position = new Vector3(Frame.Pose.position.x, GroundDetection.real_y,
            Frame.Pose.position.z); 
    }
}
