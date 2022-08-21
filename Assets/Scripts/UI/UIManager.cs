using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Game manager
    [SerializeField]
    GameManager gameManager;

    //fields for resources at the top
    [SerializeField]
    Text GoldText;
    [SerializeField]
    Text GemText;

    //Which menu to pop up
    private GameObject popUpBox;

    //fields for Upgrade Room Menu
    [SerializeField]
    public GameObject UpgradeRoomMenuObj;
    [SerializeField]
    public Text mainText;

    [SerializeField]
    public GameObject button1;
    [SerializeField]
    public Text button_1Text;
    [SerializeField]
    public Text button_1Label;

    [SerializeField]
    public GameObject button2;
    [SerializeField]
    public Text button_2Text;
    [SerializeField]
    public Text button_2Label;


    // Update is called once per frame
    void Update()
    {
        GoldText.text = "Gold: " + gameManager.Gold;
        GemText.text = "Gems: " + gameManager.Gems;
    }

    public void UpgradeRoomMenu(string MainText, string ButtonText_1, string ButtonLabelText, UnityEngine.Events.UnityAction action1, string ButtonText_2, UnityEngine.Events.UnityAction action2)
    {
        popUpBox = UpgradeRoomMenuObj;
        OpenPopup(MainText, ButtonText_1, ButtonLabelText, action1, ButtonText_2, action2);
    }

    public void OpenPopup(string MainText, string ButtonText_1, string ButtonLabelText, UnityEngine.Events.UnityAction action1, string ButtonText_2, UnityEngine.Events.UnityAction action2)
    {
        Debug.Log("Opening Upgrade menu");
        mainText.text = MainText;

        button_1Text.text = ButtonText_1;
        button_1Label.text = ButtonLabelText;
        button1.GetComponent<Button>().onClick.AddListener(action1);

        button_2Text.text = ButtonText_2;
        button_2Label.text = ButtonLabelText;
        button2.GetComponent<Button>().onClick.AddListener(action2);

        popUpBox.SetActive(true);
    }

    public void CloseUpgradeRoomMenu()
    {
        UpgradeRoomMenuObj.SetActive(false);
    }
}
