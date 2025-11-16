using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraAutoSize : MonoBehaviour
{
    private Camera cam;

    [Header("Base")]
    private float baseOrthographicSize;
    private int baseScreenHeight;

    [Header("Resize Settings")]
    [Range(0f, 1f)]
    public float resizeStrength = 0.6f;
    // 1 = Resize fully to new size, 0 = Keep original size

    private int lastScreenHeight;

    // Initialize base values
    void Awake()
    {
        cam = GetComponent<Camera>();
        // Store base values
        baseOrthographicSize = cam.orthographicSize;
        baseScreenHeight = Screen.height;
        lastScreenHeight = Screen.height;

        UpdateCameraSize();
    }

    // Check for screen height changes
    void Update()
    {
        if (Screen.height != lastScreenHeight)
        {
            lastScreenHeight = Screen.height;
            UpdateCameraSize();
        }
    }

    // Update camera size based on screen height
    void UpdateCameraSize()
    {
        float scale = (float)Screen.height / baseScreenHeight;
        float targetSize = baseOrthographicSize * scale;

        //Mix between base size and target size
        cam.orthographicSize = Mathf.Lerp(
            baseOrthographicSize,
            targetSize,
            resizeStrength
        );
    }
}
