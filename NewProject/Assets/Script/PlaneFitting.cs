using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
public class PlaneFitting : MonoBehaviour
{
    // 1. 탐색된 평면의 좌표의 평균을 구함
    // 2. outliner 기준을 결정
    // 3. 기준치 이상의 평면들은 모두 삭제 시킴
    // Ransac 알고리즘 구현
    // Start is called before the first frame update
    private List<DetectedPlane> _planeList = new List<DetectedPlane>();
    private List<Vector3> _outliner = new List<Vector3>();
    private List<Vector3> _inliner = new List<Vector3>();
    public void Initialize(DetectedPlane plane)
    {

    }

    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {

    }
    // 1. boundary Polygon 가져옴
    // 2. Mesh Vertices에 RANSAC을 적용
    // 3. RANSAC을 거쳐서 Indices return..
    private Vector3 RANSAC(List<Vector3> Vertices)
    {
        Vertices = _outliner;
        // y좌표만 출력 -> data
        List<float> ysave = new List<float>();
        List<float> save = new List<float>();
        List<float> result = new List<float>();
        for (int i = 0; i < Vertices.Count; i++)
        {
            ysave[i] = Vertices[i].y;
        }

        return Vertices[0];
    }
}
