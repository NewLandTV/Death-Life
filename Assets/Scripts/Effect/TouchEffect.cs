using UnityEngine;

public class TouchEffect : Singleton<TouchEffect>
{
    private Camera mainCamera;

    private void Awake()
    {
        InitializeSingleton(this);

        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.instance.Play(Sound.Name.SFX_TOUCH);

            GameObject effect = ObjectManager.instance.GetObject(PoolName.TouchEffect, false); 

            if (effect == null)
            {
                return;
            }

            if (mainCamera == null)
            {
                mainCamera = Camera.main;
            }

            effect.transform.position = transform.forward + mainCamera.ScreenToWorldPoint(Input.mousePosition);

            ObjectManager.instance.SetObjectActiveTimer(effect, true, 1f);
        }
    }
}
