using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeechLib;
using UnityEngine.UI;

public class VoiceOutput : MonoBehaviour
{
    public enum Voices { Female0, Female1, Female2 };


    //Public Variables
    [Header("Voice Variables")]
    public Voices VoiceIndex=Voices.Female1;
    [Range(0, 100)]
    public int Volume = 100;
    [Range(0, 100)]
    public int Rate = 0;

    [Header("Output Variables")]
    public string TextToOutput;
    public Text OutputTextField;
    public float UIWriteDelay = 0.05f;
    public InputField inputField;


    //Private Variables
    private SpVoice voice;
    private bool PlayVoiceOutputBool = false;



    //Methods
    void Start()
    {
        //Make new voice object
        voice = new SpVoice();
    }

    void Update()
    {
        if (PlayVoiceOutputBool)
        {
            //voice.Voice = voice.GetVoices().Item((int)VoiceIndex);
            //Set and play the voice output
            voice.Volume = Volume;
            voice.Rate = Rate;
            voice.Speak(TextToOutput, SpeechVoiceSpeakFlags.SVSFlagsAsync);


            //reset the bool
            PlayVoiceOutputBool = false;
        }
    }

    //Method to set the UI and play the text audio
    public void PlayVoiceOutput(string outputText)
    {
        //Set what needs to be said
        TextToOutput = outputText;

        //Set the UI text
        //SetOutputText(outputText);
        StopAllCoroutines();
        StartCoroutine(PlayUITextOutput(outputText));

        //Empty the input field
        inputField.text = string.Empty;

        //Set the boolean to true so the bot will speak
        PlayVoiceOutputBool = true;
    }

    public void NormalOutputTesting(string text)
    {
        //Set what needs to be said
        TextToOutput = text;

        //Set the UI text
        //SetOutputText(outputText);
        StopAllCoroutines();
        StartCoroutine(PlayUITextOutput(text));

        //Empty the input field
        inputField.text = string.Empty;
    }

    //set the UI
    public void SetOutputText(string text)
    {
        OutputTextField.text = text;
    }

    //Play the textoutput letter by letter
    IEnumerator PlayUITextOutput(string text)
    {
        OutputTextField.text = "";
        foreach (char letter in text.ToCharArray())
        {
            OutputTextField.text += letter;
            yield return new WaitForSeconds(UIWriteDelay);
        }
    }

    //volume and rate changes
    public void SetVolume(int volume)
    {
        Volume = volume;
    }
    public void SetRate(int rate)
    {
        Rate = rate;
    }
    public void LowerVolume()
    {
        Volume -= 10;
        if (Volume<0)
        {
            Volume = 0;
        }
    }
    public void HigherVolume()
    {
        Volume += 10;
        if (Volume > 100)
        {
            Volume = 100;
        }
    }
}
