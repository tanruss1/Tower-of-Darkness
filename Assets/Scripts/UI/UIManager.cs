using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    Text GoldText;
    [SerializeField]
    Text GemText;

    [SerializeField]
    public GameObject popUpBox;
    [SerializeField]
    public Animator animator;
    [SerializeField]
    public Text mainText;

    [SerializeField]
    public GameObject button1;
    [SerializeField]
    public Text button_1Text;
    [SerializeField]
    public Text button_1Label;
    [SerializeField]
    public Action button_1Action;

    [SerializeField]
    public GameObject button2;
    [SerializeField]
    public Text button_2Text;
    [SerializeField]
    public Text button_2Label;
    [SerializeField]
    public Action button_2Action;



    // Update is called once per frame
    void Update()
    {
        GoldText.text = "Gold: " + gameManager.Gold;
        GemText.text = "Gems: " + gameManager.Gems;
    }

    public void UpgradeRoomMenu(string MainText, string ButtonText_1, string ButtonLabel_1, Action action1, string ButtonText_2, string ButtonLabel_2, Action action2)
    {
        popUpBox.SetActive(true);
        mainText.text = MainText;
        animator.SetTrigger("pop");


    }
}
