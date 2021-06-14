using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using System;
using System.Threading;
public class GroundDetection : MonoBehaviour
{
    public static float real_y = 0;
    private Thread thread;
    private static DetectedPlane _detectedPlane;
    // Keep previous frame's mesh polygon to avoid mesh update every frame.
    private List<Vector3> _previousFrameMeshVertices = new List<Vector3>();
    private List<Vector3> _meshVertices = new List<Vector3>();
    public Vector3 _planeCenter = new Vector3();
    private Mesh _mesh;
    private MeshRenderer _meshRenderer;
    // Max Plane Center List -> Data의 최대 갯수
    private static int _planeCenterCount = 100;
    public static LinkedList<Vector3> _planeCenterList = new LinkedList<Vector3>();
    public static float outlier = 0.2f;
    public void Start()
    {
        thread = new Thread(UpdateThread);
    }
    public void OnDestroy()
    {
        thread.Abort();
        thread = null;
    }
    private void UpdateThread()
    {
        Thread.Sleep(1000);
        //Ransac();
    }
    public void Awake()
    {
        _mesh = GetComponent<MeshFilter>().mesh;
        _meshRenderer = GetComponent<UnityEngine.MeshRenderer>();
    }

    public void Initialize(DetectedPlane plane)
    {
        _detectedPlane = plane;
        _meshRenderer.material.SetColor("_GridColor", Color.white);
        _meshRenderer.material.SetFloat("_UvRotation", UnityEngine.Random.Range(0.0f, 360.0f));

        Update();
    }

    /// <summary>
    /// The Unity Update() method.
    /// </summary>
    public void Update()
    {
        if (_detectedPlane == null)
        {
            return;
        }
        else if (_detectedPlane.SubsumedBy != null)
        {
            Destroy(gameObject);
            return;
        }
        else if (_detectedPlane.TrackingState != TrackingState.Tracking)
        {
            _meshRenderer.enabled = false;
            return;
        }

        _meshRenderer.enabled = true;
        //Debug.Log("Criteria : " + GroundDetection.ObstacleCriteria());
        
            Ransac();
        
        UpdateMeshIfNeeded();
    }

    /// <summary>
    /// Update mesh with a list of Vector3 and plane's center position.
    /// </summary>
    private void UpdateMeshIfNeeded()
    {
        _detectedPlane.GetBoundaryPolygon(_meshVertices);

        if (AreVerticesListsEqual(_previousFrameMeshVertices, _meshVertices))
        {
            return;
        }

        _previousFrameMeshVertices.Clear();
        _previousFrameMeshVertices.AddRange(_meshVertices);

        _planeCenter = _detectedPlane.CenterPose.position;
        //Debug.Log("Plane Position : " + _planeCenter);
        //Debug.Log("Plane Count : " + _planeCenterList.Count);
        MaxPlaneCenterList(_planeCenter);

    }

    public static void MaxPlaneCenterList(Vector3 Center)
    {
        // plane list 저장, criteria Num
        _planeCenterList.AddLast(Center);
        if (_planeCenterList.Count >= _planeCenterCount)
        {
            _planeCenterList.RemoveFirst();
        }
    }
    private bool AreVerticesListsEqual(List<Vector3> firstList, List<Vector3> secondList)
    {
        if (firstList.Count != secondList.Count)
        {
            return false;
        }

        for (int i = 0; i < firstList.Count; i++)
        {
            if (firstList[i] != secondList[i])
            {
                return false;
            }
        }

        return true;
    }
    
    // ransac을 통한 Plane Fitting
    public static void Ransac()
    {
        int c_max = 0;
        int c_cnt = 0;
        float T = 0.2f;

        int y_cnt = _planeCenterList.Count;
        float tmp_y = 0;
        
        foreach (Vector3 i in _planeCenterList)
        {
            tmp_y = i.y;
            foreach (Vector3 j in _planeCenterList)
            {

                if (Math.Abs(tmp_y - j.y) <= T)
                    c_cnt++;
            }
           
          
            if (c_cnt > c_max)
            {
                c_max = c_cnt;
                real_y = tmp_y;

            }
            c_cnt = 0;
            
        }
        Debug.Log("real_y : " + real_y);
        Debug.Log("y_count : " + y_cnt);

    }
}
