using UnityEngine;
using UnityEngine.EventSystems;

public class Character : WorldObject
{
    private Camera mainCamera;

    private void Awake()
    {
        Setup();

        mainCamera = Camera.main;
    }

    private void Update()
    {
        ClickMovement();
    }

    private void ClickMovement()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            GameObject arrow = ObjectManager.instance.GetObject(PoolName.Arrow, false);

            if (arrow == null)
            {
                return;
            }

            Vector3 arrowPosition = transform.position;

            transform.position = transform.forward + mainCamera.ScreenToWorldPoint(Input.mousePosition);

            Vector3 direction = (transform.position - arrowPosition).normalized;

            arrow.transform.position = arrowPosition;
            arrow.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f, Vector3.forward);

            ObjectManager.instance.SetObjectActiveTimer(arrow, true, 0.5f);
        }
    }
}
