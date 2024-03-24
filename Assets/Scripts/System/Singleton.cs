using UnityEngine;

public class Singleton<T> : MonoBehaviour
{
    public static T instance
    {
        get;
        private set;
    }

    protected void InitializeSingleton(T type)
    {
        if (instance == null)
        {
            instance = type;

            DontDestroyOnLoad(gameObject);

            return;
        }

        Destroy(gameObject);
    }
}
