using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    [SerializeField]
    private Vector2Int resolution = new Vector2Int(9, 19);

    private void Awake()
    {
        Camera camera = GetComponent<Camera>();

        Rect rect = camera.rect;

        float heightScale = (float)Screen.width / Screen.height / ((float)resolution.x / resolution.y);
        float widthScale = 1f / heightScale;

        if (heightScale < 1)
        {
            rect.height = heightScale;
            rect.y = (1f - heightScale) * 0.5f;
        }
        else
        {
            rect.width = widthScale;
            rect.x = (1f - widthScale) * 0.5f;
        }

        camera.rect = rect;
    }
}
