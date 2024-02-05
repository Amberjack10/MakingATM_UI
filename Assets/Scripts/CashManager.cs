using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CashManager : MonoBehaviour
{
    [SerializeField] private Text userCashText;
    [SerializeField] private Text userBanlanceText;

    public static CashManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        DepositManager.instance.OnDeposit += DepositCashToBanlance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DepositCashToBanlance(int cash)
    {
        int leftoverCash = int.Parse(userCashText.text.ToString());
        int userBanlance = int.Parse(userBanlanceText.text.ToString());

        if(leftoverCash < cash)
        {
            Debug.Log("�ܾ� ����!");
            return;
        }
        // ���� ����
        leftoverCash -= cash;
        userCashText.text = leftoverCash.ToString();
        // �ܾ� �Ա�
        userBanlance += cash;
        userBanlanceText.text = userBanlance.ToString();
    }
}
