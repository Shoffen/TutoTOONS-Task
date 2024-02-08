using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PointLabel : MonoBehaviour
{
    public TMP_Text numberLabel;

    public void SetLabel(float number)
    {
        
        numberLabel.text = number.ToString();
        //numberLabel.text = number.ToString();
        //Instantiate(numberLabel, spawnPosition, Quaternion.identity);
    }
    public TMP_Text GetLabel()
    {
        return numberLabel;
    }

}
