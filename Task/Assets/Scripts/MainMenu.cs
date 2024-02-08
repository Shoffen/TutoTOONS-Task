using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Slider slider;
    public GameObject menuCanva;
    public GameObject optionsCanva;
    public GameObject selectionCanva;
    public void Update()
    {
        PlayerPrefs.SetFloat("SoundVolume", slider.value);

        if (PlayerPrefs.GetFloat("Selection") == 1)
        {
            selectionCanva.SetActive(true);
            menuCanva.SetActive(false);
            PlayerPrefs.SetFloat("Selection", 0);
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
        
    }
    public void Button1Clicked()
    {
        PlayerPrefs.SetFloat("Level", 0);
        PlayGame();
    }

    public void Button2Clicked()
    {
        PlayerPrefs.SetFloat("Level", 1f);
        PlayGame();
    }

    public void Button3Clicked()
    {
        PlayerPrefs.SetFloat("Level", 2f);
        PlayGame();
    }

    public void Button4Clicked()
    {
        PlayerPrefs.SetFloat("Level", 3f);
        PlayGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
