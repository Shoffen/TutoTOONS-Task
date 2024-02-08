using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonLogic : MonoBehaviour
{
    private TMP_Text textLabel;
    public bool pressed = false;
    public Button button;

    public SpriteRenderer blueButton;
    private SpriteRenderer purpleButton;
    private Color targetColor;
    private Color initialColor;
    private List<int> clicks;
    private ClickRegister clickRegister;
    private float fadeDuration = 2f;
    private LineLogic lineLogic;
    [SerializeField] private SoundSystem soundSystem;
    public AudioSource transitGem;

    // Start is called before the first frame update
    void Start()
    {
        lineLogic = GameObject.FindGameObjectWithTag("Camera").GetComponent<LineLogic>();
        transitGem = soundSystem.TransferGem;
        purpleButton = GetComponent<SpriteRenderer>();
        initialColor = purpleButton.color;
        targetColor = blueButton.color;
        textLabel = this.GetComponent<PointLabel>().GetLabel();
        clickRegister = GameObject.FindGameObjectWithTag("ClickRegister").GetComponent<ClickRegister>();
        clicks = clickRegister.clicks;
    }
    public void ButtonWasPressed()
    {
       Debug.Log("MYGTUKAS BUVO PASPAUSTAS");
       pressed = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        
        if (pressed)
        {
            Debug.Log(textLabel.text);
            if (clicks.Count == 0)
            {
                if (textLabel.text == "1")
                {
                    soundSystem.TransferGem.volume = PlayerPrefs.GetFloat("SoundVolume");
                    soundSystem.TransferGem.Play();
                    clicks.Add(int.Parse(textLabel.text));
                    lineLogic.UpdatePoints(button.transform.position);
                    StartCoroutine(LabelFade());
                    StartCoroutine(TransitionColor(Color.blue));
                    button.interactable = false;
                    
                }
                pressed = false;
            }
            if (clicks.Count >= 1)
            {
                clicks.Add(int.Parse(textLabel.text));
                if (clicks[clicks.Count-1] - clicks[clicks.Count-2] == 1)
                {
                    soundSystem.TransferGem.volume = PlayerPrefs.GetFloat("SoundVolume");
                    soundSystem.TransferGem.Play();
                    StartCoroutine(LabelFade());
                    lineLogic.UpdatePoints(button.transform.position);
                    StartCoroutine(TransitionColor(Color.blue));
                    button.interactable = false;
                }
                else
                {
                    clicks.Remove(int.Parse(textLabel.text));
                }
                pressed = false;
            }
            
            
        }
    }
    
    // Coroutine to smoothly transition the color of the button
    IEnumerator TransitionColor(Color targetColor)
    {
        float elapsedTime = 0f;
       
        while (elapsedTime < 2f) // Transition duration of 1 second
        {
            elapsedTime += Time.deltaTime;
            purpleButton.color = Color.Lerp(initialColor, targetColor, elapsedTime);
            yield return null;
        }

       purpleButton.sprite = blueButton.sprite; // Ensure the final color is set correctly
    }

    // Coroutine for label fading
    IEnumerator LabelFade()
    {
        // Get the initial color of the text
        Color initialColor = textLabel.color;

        // Calculate the target color (fully transparent)
        Color targetColor = new Color(initialColor.r, initialColor.g, initialColor.b, 0f);

        // Initialize elapsed time
        float elapsedTime = 0f;

        // Fade the text gradually
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;

            // Calculate the interpolation factor (t)
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);

            // Interpolate between the initial color and the target color
            textLabel.color = Color.Lerp(initialColor, targetColor, t);
            textLabel.transform.position += Vector3.up * Random.Range(1f, 4f);

            yield return null;
        }

        // Ensure the final color is set correctly (fully transparent)
        textLabel.color = targetColor;

        // Set the text to an empty string
        textLabel.text = "";
    }
}