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


    private void Init(List<Vector3> vertices)
    {
        for (int i = 0; i < vertices.Count; i++)
        {
            _cachedVertices[i] = vertices[i];
        }
    }
    // Start is called before the first frame update

    public void Start()
    {
        Init(_vertices);
    }

    // Update is called once per frame
    public void Update()
    {
        Fitting(_cachedVertices);
    }

    private float Threshold(List<Vector3> vertices)
    {
        float result = 0;

        return result;    
    }

    private float Fitting(List<Vector3> vertices)
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



//Remove Vertex0(0.0, -0.3, 0.2)
//Remove Vertex1(0.0, -0.3, 0.3)
//Remove Vertex2(0.1, -0.3, 0.6)
//Remove Vertex3(0.3, -0.3, 0.6)
//Remove Vertex4(0.3, -0.3, 0.5)
//Remove Vertex5(0.2, -0.3, 0.2)

//Create Vertex0(0.0, -0.3, 0.2)
//Create Vertex1(0.0, -0.3, 0.5)
//Create Vertex2(0.2, -0.3, 0.6)
//Create Vertex3(0.3, -0.3, 0.6)
//Create Vertex4(0.2, -0.3, 0.3)


//Remove Vertex0(0.1, -0.3, 0.8)
//Create Vertex0(0.0, -0.3, 0.9)

//Remove Vertex1(0.0, -0.3, 1.2)
//Create Vertex1(0.0, -0.3, 1.2)

//Remove Vertex2(0.4, -0.3, 1.3)
//Create Vertex2(0.3, -0.3, 1.0)

//Remove Vertex3(0.3, -0.3, 0.7)
//Create Vertex3(0.2, -0.3, 0.7)
