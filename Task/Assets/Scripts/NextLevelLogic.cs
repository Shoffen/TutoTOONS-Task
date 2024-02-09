using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextLevelLogic : MonoBehaviour
{
    public TMP_Text buttonText;
    public Button button;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    public void SetupFinish()
    {
        buttonText.text = "FINISH";
    }
    public void ButtonWasPressed()
    {
        if(buttonText.text == "FINISH")
        {
            Application.Quit();
        }
    }
}
