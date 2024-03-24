using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private GameObject group;

    public void Show()
    {
        group.SetActive(true);
    }

    public void Hide()
    {
        group.SetActive(false);
    }    
}
