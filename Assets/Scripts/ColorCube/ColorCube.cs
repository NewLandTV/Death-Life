using UnityEngine;
using UnityEngine.UI;

public class ColorCube : UIRigidbody
{
    private Image image;

    private Color color;

    private void Awake()
    {
        Setup();

        image = GetComponent<Image>();

        color = image.color;
    }
}
