using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI_Manager : MonoBehaviour
{
    //Variables
    //Communication - Voice Output
    public VoiceOutput VoiceOut;

    //Communication - Voice Input

    //AIML
    private ChatbotPC _chatBot;
    public InputField inputField;


    //Methods
    public enum Voices { Female0, Female1, Female2 };


    void Start()
    {
        _chatBot = new ChatbotPC();
        _chatBot.LoadBrain();
    }


    /*public void TEMP_VoiceOutputTesting(string output)
    {
        VoiceOut.PlayVoiceOutput(output);
    }
    public void TEMP_VoiceOutputTesting(Text output)
    {
        VoiceOut.PlayVoiceOutput(output.text);
    }*/


    void OnDisable()
    {
        _chatBot.SaveBrain();
    }

    public void SendQuestionToRobot()
    {
        if (string.IsNullOrEmpty(inputField.text) == false)
        {
            // Response Bot AIML
            string response = _chatBot.getOutput(inputField.text);

            //Output the response
            VoiceOut.PlayVoiceOutput(response);
            //VoiceOut.NormalOutputTesting(response);
        }
    }
}
