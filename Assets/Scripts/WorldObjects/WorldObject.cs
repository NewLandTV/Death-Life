using UnityEngine;

public class WorldObject : MonoBehaviour
{
    [HideInInspector]
    public new Transform transform;

    protected void Setup()
    {
        transform = GetComponent<Transform>();
    }
}
