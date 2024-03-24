using UnityEngine;

public class Start : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 30;

        Loading.LoadScene(Scenes.Main);
    }
}
