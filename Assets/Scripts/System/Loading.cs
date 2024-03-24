using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Scenes
{
    Start,
    Loading,
    Main
}

public class Loading : MonoBehaviour
{
    private static Scenes scene;

    [SerializeField]
    private Image progressBarImage;
    [SerializeField]
    private GameObject[] colorCubes;

    private WaitForSeconds waitTime1f;

    private void Awake()
    {
        waitTime1f = new WaitForSeconds(1f);
    }

    private void Start()
    {
        StartCoroutine(LoadSceneCoroutine());
    }

    private IEnumerator LoadSceneCoroutine()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)scene);

        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone || progressBarImage.fillAmount < 1f)
        {
            if (asyncOperation.progress >= 0.9f)
            {
                float timer = 0f;

                while (timer <= 1f)
                {
                    colorCubes[Mathf.FloorToInt(timer * 4f)].SetActive(true);

                    progressBarImage.fillAmount = Mathf.Lerp(0f, 1f, timer);

                    timer += 0.5f * Time.deltaTime;

                    yield return null;
                }

                progressBarImage.fillAmount = 1f;

                yield return waitTime1f;

                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    public static void LoadScene(Scenes scene)
    {
        Loading.scene = scene;

        SceneManager.LoadScene((int)Scenes.Loading);
    }
}
