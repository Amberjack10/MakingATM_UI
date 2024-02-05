using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashManager : MonoBehaviour
{
    [SerializeField] private Text userCashText;
    [SerializeField] private Text userBalanceText;

    public static CashManager instance;

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
            Debug.Log("�ܾ� ����!");
            return;
        }
        // ���� ����
        leftoverCash -= cash;
        userCashText.text = leftoverCash.ToString();
        // �ܾ� �Ա�
        userBalance += cash;
        userBalanceText.text = userBalance.ToString();
    }
}
