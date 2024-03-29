using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepositManager : MonoBehaviour
{
    [SerializeField] private GameObject depositMenu;
    [SerializeField] private Text depositInputText;

    public event Action<int> OnDeposit;

    public static DepositManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        depositMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickDepositButtons(int index)
    {
        if(index == 4)
        {
            depositMenu.SetActive(false);
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
                    if(!int.TryParse(depositInputText.text, out index))
                    {
                        return;
                    }
                    break;
            }
            OnDeposit?.Invoke(index);
        }
    }
}
