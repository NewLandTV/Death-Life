using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private Animator menuListAnimator;
    [SerializeField]
    private Button menuButton;

    private RectTransform[] menuItemInListObjects;

    // Animation hash
    private int showTrigger;
    private int hideTrigger;

    // Flags
    private bool isShowMenuList;

    private WaitForSeconds waitTime0_5f;

    private void Awake()
    {
        menuItemInListObjects = menuListAnimator.GetComponentsInChildren<RectTransform>();

        showTrigger = Animator.StringToHash("Show");
        hideTrigger = Animator.StringToHash("Hide");

        waitTime0_5f = new WaitForSeconds(0.5f);
    }

    public void OnMenuButtonClick()
    {
        StartCoroutine(MenuButtonWaitTime());

        if (isShowMenuList)
        {
            ObjectManager.instance.SetObjectActiveTimer(menuItemInListObjects[0].gameObject, true, 0.5f);

            for (int i = 1; i < menuItemInListObjects.Length; i++)
            {
                ObjectManager.instance.SetObjectActiveTimer(menuItemInListObjects[i].gameObject, true, 0.2f);
            }
        }
        else
        {
            for (int i = 0; i < menuItemInListObjects.Length; i++)
            {
                menuItemInListObjects[i].gameObject.SetActive(true);
            }
        }

        menuListAnimator.SetTrigger(isShowMenuList ? hideTrigger : showTrigger);

        isShowMenuList = !isShowMenuList;
    }

    private IEnumerator MenuButtonWaitTime()
    {
        menuButton.interactable = false;

        yield return waitTime0_5f;

        menuButton.interactable = true;
    }

    public void OnMeunItemInListButtonClick(int index)
    {
        switch (index)
        {
            case 0:
                GameManager.instance.Settings.Show();

                break;
            case 1:
                GameManager.instance.Inventory.Show();

                break;
            case 2:
                // TODO Call function to shop.Show();

                break;
        }
    }
}
