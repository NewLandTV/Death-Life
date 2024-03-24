using UnityEngine;

public class UIRigidbody : MonoBehaviour
{
    [HideInInspector]
    public RectTransform rectTransform;

    [SerializeField]
    private bool simulated;
    [SerializeField]
    private float gravityScale;

    private void FixedUpdate()
    {
        if (rectTransform == null || !simulated)
        {
            return;
        }

        KeepInScreenAndGravity();
    }

    private void KeepInScreenAndGravity()
    {
        rectTransform.position += Physics.gravity * gravityScale * Time.fixedDeltaTime;

        float yPosition = rectTransform.anchoredPosition.y;
        float yBorder = 1520f - rectTransform.sizeDelta.y * 0.5f;

        if (yBorder <= yPosition || yPosition <= -yBorder)
        {
            rectTransform.position -= Physics.gravity * gravityScale * Time.fixedDeltaTime;
        }
    }

    protected void Setup()
    {
        rectTransform = GetComponent<RectTransform>();
    }
}
