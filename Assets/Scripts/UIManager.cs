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

    // Update is called once per frame
    void Update()
    {
        GoldText.text = "Gold: " + gameManager.Gold;
        GemText.text = "Gems: " + gameManager.Gems;
    }
}
