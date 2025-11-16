using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player;          // Character
    public RectTransform mapUI;       // Mini-map UI element
    public RectTransform icon;        // Icon representing the player on the mini-map

    [Header("World boundds 2D")]
    public Transform worldMinPoint;   // Object to bottom-left corner
    public Transform worldMaxPoint;   // Object to top-right corner

    void LateUpdate()
    {
        if (!player || !mapUI || !icon || !worldMinPoint || !worldMaxPoint)
            return;

        Vector3 pos = player.position;

        Vector2 worldMin = worldMinPoint.position;
        Vector2 worldMax = worldMaxPoint.position;

        // Normalize position within world bounds
        float nx = Mathf.InverseLerp(worldMin.x, worldMax.x, pos.x); 
        float ny = Mathf.InverseLerp(worldMin.y, worldMax.y, pos.y);

        // Map normalized position to mini-map UI coordinates
        float x = (nx - 0.25f) * mapUI.rect.width;
        float y = (ny - 0.32f) * mapUI.rect.height;

        icon.anchoredPosition = new Vector2(x, y);
    }
}
