using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    public Camera mainCamera; // Reference to your main camera

    void Start()
    {
        // Calculate aspect ratio
        float aspectRatio = (float)Screen.width / (float)Screen.height;

        // Set the orthographic size of the camera
        mainCamera.orthographicSize = 1000f / (2f * aspectRatio);
    }
}
