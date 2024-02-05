using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void OnClickMainMenuButton(int index)
    {
        gameObject.SetActive(false);
        switch (index)
        {
            case 0:
                ATMManager.instance.depositMenu.SetActive(true);
                break;
            case 1:
                ATMManager.instance.withdrawMenu.SetActive(true);
                break;
        }
    }
}
