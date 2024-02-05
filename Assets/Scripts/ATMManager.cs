using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATMManager : MonoBehaviour
{
    [SerializeField] private Text userCashText;
    [SerializeField] private Text userBalanceText;

    [SerializeField] private GameObject warningPopup;

    public static ATMManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        DepositManager.instance.OnDeposit += DepositCashToBalance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DepositCashToBalance(int cash)
    {
        int leftoverCash = int.Parse(userCashText.text.ToString());
        int userBalance = int.Parse(userBalanceText.text.ToString());

        if(leftoverCash < cash)
        {
            warningPopup.SetActive(true);
        }
        else
        {
            // 현금 차감
            leftoverCash -= cash;
            userCashText.text = leftoverCash.ToString();
            // 잔액 입금
            userBalance += cash;
            userBalanceText.text = userBalance.ToString();
        }
    }

    public void OnClickWarningPopupOkButton()
    {
        warningPopup.SetActive(false);
    }
}
