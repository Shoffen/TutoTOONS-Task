using UnityEngine;

public class CameraSetup : MonoBehaviour
{
    public Camera mainCamera; 

    void Start()
    {
        
        float aspectRatio = (float)Screen.width / (float)Screen.height;

        
        mainCamera.orthographicSize = 1000f / (2f * aspectRatio);
    }
}
