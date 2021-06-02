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
    // vertex 좌표먼 잡아주면 됨
    List<Vector3> _vertices = new List<Vector3>();
    List<Vector3> _cachedVertices = new List<Vector3>();


    private void init(List<Vector3> vertices)
    {
        for (int i = 0; i < vertices.Count; i++)
        {
            _cachedVertices[i] = vertices[i];
        }
    }
    // Start is called before the first frame update

    public void Start()
    {
        init(_vertices);
    }

    // Update is called once per frame
    public void Update()
    {
        fitting(_cachedVertices);
    }

    private float fitting(List<Vector3> vertices)
    {
        float threshold = 0f;
        
        for (int i=0; i< vertices.Count; i++)
        {
            threshold += vertices[i].y;
        }
        threshold /= vertices.Count;
        return threshold;
    }
}
