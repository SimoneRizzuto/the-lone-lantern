using CSharpScripts.Constants;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

namespace CSharpScripts.Prototypes.CutsceneTimeline.V2.Text
{
    public class TextBehaviourV2 : PlayableBehaviour
    {
        // From Clip.
        public string TextInput;
        public float SpeedInput;
        public bool NotSkippable;
        public FontSizes FontSize;

        private string onscreenText;
        private float clipLength, speedMultiplier, currentPosition;
    
        public int CharIndex;
        public PlayableGraph ParsedGraph;

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            TextMeshProUGUI text = playerData as TextMeshProUGUI;

            if (text == null) return;
        
            if (FontSize == FontSizes.Whisper) // Check for input of font size and returns it in that size.
            {
                text.fontSize = 3f;
            }
            else if (FontSize == FontSizes.Normal)
            {
                text.fontSize = 4.4f;
            }
            else if (FontSize == FontSizes.Yell)
            {
                text.fontSize = 6f;
            }

            clipLength = (float)playable.GetDuration(); // Length of the clip
        
            if (CharIndex < TextInput.Length)
            {
                if (SpeedInput == 0) // Multiplier of typing speed: relying on the length of the text and the length of the clip.
                {
                    speedMultiplier = (float)TextInput.Length / clipLength;
                }
                else
                {
                    speedMultiplier = SpeedInput;
                }
                currentPosition = 1 + (float)playable.GetTime() * speedMultiplier; 

                if (CharIndex < 1)
                {
                    Debug.Log("Current Type Speed: " + speedMultiplier);
                }
            
                // Rounds numbers down so typing can happen.
                CharIndex = Mathf.FloorToInt(currentPosition);
                CharIndex = Mathf.Clamp(CharIndex, 0, TextInput.Length);

                onscreenText = TextInput.Substring(0, CharIndex);

                text.text = onscreenText;
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
                onscreenText = TextInput; 
                text.text = onscreenText; 
            }
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
