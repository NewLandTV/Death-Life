using UnityEngine;

public class Reposition : WorldObject
{
    private void Awake()
    {
        Setup();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.position = transform.forward + GameManager.instance.Character.transform.position;
    }
}
