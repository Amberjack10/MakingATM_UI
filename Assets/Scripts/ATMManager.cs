using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATMManager : MonoBehaviour
{
    [SerializeField] private Text userCashText;
    [SerializeField] private Text userBalanceText;

    public GameObject MainMenu;
    public GameObject depositMenu;
    public GameObject withdrawMenu;
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
        WithdrawManager.instance.OnWithdraw += WithdrawBalanceToCash;
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

    private void WithdrawBalanceToCash(int balance)
    {
        int leftoverCash = int.Parse(userCashText.text.ToString());
        int userBalance = int.Parse(userBalanceText.text.ToString());

        if (userBalance < balance)
        {
            warningPopup.SetActive(true);
        }
        else
        {
            // 잔액 차감
            userBalance -= balance;
            userBalanceText.text = userBalance.ToString();
            // 현금 출금
            leftoverCash += balance;
            userCashText.text = leftoverCash.ToString();
        }
    }

    public void OnClickWarningPopupOkButton()
    {
        warningPopup.SetActive(false);
    }
}
