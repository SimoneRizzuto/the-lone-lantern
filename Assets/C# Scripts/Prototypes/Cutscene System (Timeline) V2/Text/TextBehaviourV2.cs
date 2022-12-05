using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class TextBehaviourV2 : PlayableBehaviour
{
    // From Clip.
    public string TextInput;
    public float SpeedInput;
    public bool NotSkippable;
    public string FontSize;

    public string OnscreenText;
    public float ClipLength;

    public float SpeedMultiplier, CurrentPosition;

    public string ConsoleText = "";
    public int CharIndex;
    public PlayableGraph ParsedGraph;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI text = playerData as TextMeshProUGUI;

        if (FontSize == "whisper") // Check for input of font size and returns it in that size.
        {
            text.fontSize = 3f;
        }
        else if (FontSize == "normal")
        {
            text.fontSize = 4.4f;
        }
        else if (FontSize == "yell")
        {
            text.fontSize = 6f;
        }
        

        ClipLength = (float)playable.GetDuration(); // Length of the clip
        
        if (CharIndex < TextInput.Length)
        {
            if (SpeedInput == 0) // Multiplier of typing speed: relying on the length of the text and the length of the clip.
            {
                SpeedMultiplier = (float)TextInput.Length / ClipLength;
            }
            else
            {
                SpeedMultiplier = SpeedInput;
            }
            CurrentPosition = 1 + ((float)playable.GetTime() * SpeedMultiplier); 

            if (CharIndex < 1)
            {
                Debug.Log("Current Type Speed: " + SpeedMultiplier);
            }
            
            // Rounds numbers down so typing can happen.
            CharIndex = Mathf.FloorToInt(CurrentPosition);
            CharIndex = Mathf.Clamp(CharIndex, 0, TextInput.Length);

            OnscreenText = TextInput.Substring(0, CharIndex);

            text.text = OnscreenText;
        }        
        else if (CharIndex == TextInput.Length) // If at the end of the clip.
        {
            // Set the time of the timeline to the end of the track.
            ParsedGraph.GetRootPlayable(0).SetTime(
                ((double)ParsedGraph.GetRootPlayable(0).GetTime() - (float)playable.GetTime()) +
                 (float) playable.GetDuration() - 0.001f);
            //parsed_graph.GetRootPlayable(0).SetSpeed(0); // Pause the timeline.

            if (Input.GetKeyDown("space")) // Await for input. If input is done.
            {               
                CharIndex++; 
                //parsed_graph.GetRootPlayable(0).SetSpeed(1);
                //Debug.Log("Space is pressed.");
            }
        }
        // If an input is received & the dialogue has not finished typing & it is skippable.
        if (Input.GetKeyDown("space") && CharIndex < TextInput.Length && !NotSkippable) 
        {
            CharIndex = TextInput.Length; // Make the typing effect reach the end instantly.
            OnscreenText = TextInput; 
            text.text = OnscreenText; 
        }
    }
}

// NEEDS TO GO INSIDE ProcessFrame FOR DISPLAYING THE DURATION THE CLIP NEEDS TO BE IF MANUAL TEXT SPEED IS INPUT BY DEVELOPER
// if (console_text == string.Empty) // For displaying the duration the clip needs to be for maximum
// {
//     var console_title_length = 30;
//     if (text_input.Length < 30)
//     {
//         console_title_length = text_input.Length;
//     }

//     console_text = $"'{text_input.Substring(0, console_title_length)}'\nType speed multiplier: " + speed_multiplier + " Recommended length: " + ((float)text_input.Length / speed_multiplier);
//     Debug.Log(console_text);
// }
