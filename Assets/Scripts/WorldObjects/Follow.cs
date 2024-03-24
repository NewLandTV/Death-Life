using System.Collections;
using UnityEngine;

public class Follow : WorldObject
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float speed;

    [SerializeField]
    private bool followMousePosition;

    [SerializeField]
    private bool xPosition;
    public bool XPosition
    {
        set => xPosition = value;
    }

    [SerializeField]
    private bool yPosition;
    public bool YPosition
    {
        set => yPosition = value;
    }

    [SerializeField]
    private bool zPosition;
    public bool ZPosition
    {
        set => zPosition = value;
    }

    private bool startFollow;

    private void Awake()
    {
        Setup();
    }

    private void Update()
    {
        if (target != null && !startFollow && transform.position != new Vector3(xPosition ? target.position.x : transform.position.x, yPosition ? target.position.y : transform.position.y, zPosition ? target.position.z : transform.position.z))
        {
            StartCoroutine(FollowCoroutine(transform.position, new Vector3(xPosition ? target.position.x : transform.position.x, yPosition ? target.position.y : transform.position.y, zPosition ? target.position.z : transform.position.z)));
        }
        else if (followMousePosition)
        {
            transform.position = Input.mousePosition;
        }
    }

    private IEnumerator FollowCoroutine(Vector3 start, Vector3 end)
    {
        startFollow = true;

        float t = 1f / speed;
        float timer = 0f;

        while (timer < 1f)
        {
            transform.position = Vector3.Lerp(start, end, timer);

            timer += t * Time.deltaTime;

            yield return null;
        }

        transform.position = end;
        startFollow = false;
    }
}
