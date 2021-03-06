using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
public class GroundGenerator : MonoBehaviour
{ 
    /// <summary>
    /// Manages the visualization of detected planes in the scene.
    /// </summary>
    /// <summary>
    /// A prefab for tracking and visualizing detected planes.
    /// </summary>
    public GameObject DetectedPlanePrefab;

    /// <summary>
    /// A list to hold new planes ARCore began tracking in the current frame. This object is
    /// used across the application to avoid per-frame allocations.
    /// </summary>
    private List<DetectedPlane> _newPlanes = new List<DetectedPlane>();
    /// <summary>
    /// The Unity Update method.
    /// </summary>
    public void Update()
    {
        // Check that motion tracking is tracking.
        if (Session.Status != SessionStatus.Tracking)
        {
            return;
        }

        // Iterate over planes found in this frame and instantiate corresponding GameObjects to
        // visualize them.
        Session.GetTrackables<DetectedPlane>(_newPlanes, TrackableQueryFilter.New);
        for (int i = 0; i < _newPlanes.Count; i++)
        {
            // Instantiate a plane visualization prefab and set it to track the new plane. The
            // transform is set to the origin with an identity rotation since the mesh for our
            // prefab is updated in Unity World coordinates.
            GameObject planeObject =
                Instantiate(DetectedPlanePrefab, Vector3.zero, Quaternion.identity, transform);
            planeObject.GetComponent<GroundDetection>().Initialize(_newPlanes[i]);
        }
    }
}
