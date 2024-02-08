using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextLevelLogic : MonoBehaviour
{
    public TMP_Text buttonText;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
