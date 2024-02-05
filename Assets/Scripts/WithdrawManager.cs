using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WithdrawManager : MonoBehaviour
{
    [SerializeField] private GameObject withdrawMenu;
    [SerializeField] private Text withdrawInputText;

    public event Action<int> OnWithdraw;

    public static WithdrawManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        withdrawMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickWithdrawButtons(int index)
    {
        if (index == 4)
        {
            withdrawMenu.SetActive(false);
            ATMManager.instance.MainMenu.SetActive(true);
            return;
        }
        else
        {
            switch (index)
            {
                case 0: index = 10000; break;
                case 1: index = 30000; break;
                case 2: index = 50000; break;
                case 3:
                    if (!int.TryParse(withdrawInputText.text, out index))
                    {
                        return;
                    }
                    break;
            }
            OnWithdraw?.Invoke(index);
        }
    }
}
