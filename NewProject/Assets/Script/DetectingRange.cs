using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingRange : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    private Transform tr;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //tr.position = new Vector3(target.position.x)
    }
}
