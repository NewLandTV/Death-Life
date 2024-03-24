using UnityEngine;

[ExecuteInEditMode]
public class SpriteOutline : MonoBehaviour
{
    [SerializeField]
    private Color color = Color.white;

    [SerializeField, Range(0, 16)]
    private int outlineSize = 1;

    private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        UpdateOutline(true);
    }

    private void OnDisable()
    {
        UpdateOutline(false);
    }

    private void Update()
    {
        UpdateOutline(true);
    }

    private void UpdateOutline(bool outline)
    {
        MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();

        spriteRenderer.GetPropertyBlock(materialPropertyBlock);

        materialPropertyBlock.SetFloat("_Outline", outline ? 1f : 0f);
        materialPropertyBlock.SetColor("_OutlineColor", color);
        materialPropertyBlock.SetFloat("_OutlineSize", outlineSize);

        spriteRenderer.SetPropertyBlock(materialPropertyBlock);
    }
}
