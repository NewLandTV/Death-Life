using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolName
{
    TouchEffect,
    Arrow
}

[System.Serializable]
public class ObjectPool
{
    public GameObject prefab;

    public int makeCount;

    [HideInInspector]
    public List<GameObject> list = new List<GameObject>();
}

public class ObjectManager : Singleton<ObjectManager>
{
    [SerializeField]
    private ObjectPool[] objectPools;

    private void Awake()
    {
        InitializeSingleton(this);

        for (int i = 0; i < objectPools.Length; i++)
        {
            MakeObject((PoolName)i, objectPools[i].makeCount, false);
        }
    }

    private void MakeObject(PoolName poolName, int count, bool active)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject instance = Instantiate(objectPools[(int)poolName].prefab, Vector3.zero, Quaternion.identity, transform);

            instance.SetActive(active);

            objectPools[(int)poolName].list.Add(instance);
        }
    }

    public GameObject GetObject(PoolName poolName, bool activeCondition)
    {
        for (int i = 0; i < objectPools[(int)poolName].list.Count; i++)
        {
            if (objectPools[(int)poolName].list[i].activeSelf == activeCondition)
            {
                return objectPools[(int)poolName].list[i];
            }
        }

        return null;
    }

    public void SetObjectActiveTimer(GameObject gameObject, bool active, float lifetime)
    {
        StartCoroutine(SetObjectActiveTimerCoroutine(gameObject, active, lifetime));
    }

    private IEnumerator SetObjectActiveTimerCoroutine(GameObject gameObject, bool active, float lifetime)
    {
        gameObject.SetActive(active);

        yield return new WaitForSeconds(lifetime);

        gameObject.SetActive(!active);
    }
}
