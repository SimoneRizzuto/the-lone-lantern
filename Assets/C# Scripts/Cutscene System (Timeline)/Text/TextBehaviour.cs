using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TextBehaviour : PlayableBehaviour
{
    // From Clip.
    public string text_input;
    public float speed_input;
    public bool not_skippable;
    public string font_size;

    public string onscreen_text;
    public float clip_length;

    public float speed_multiplier, current_position;

    public string console_text="";
    public int char_index;
    public PlayableGraph parsed_graph;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI Text = playerData as TextMeshProUGUI;

        if (font_size == "whisper") // Check for input of font size and returns it in that size.
        {
            Text.fontSize = 3f;
        }
        else if (font_size == "normal")
        {
            Text.fontSize = 4.4f;
        }
        else if (font_size == "yell")
        {
            Text.fontSize = 6f;
        }
        

        clip_length = (float)playable.GetDuration(); // Length of the clip
        
        if (char_index < text_input.Length)
        {
            if (speed_input == 0) // Multiplier of typing speed: relying on the length of the text and the length of the clip.
            {
                speed_multiplier = (float)text_input.Length / clip_length;
            }
            else
            {
                speed_multiplier = speed_input;
            }
            current_position = 1 + ((float)playable.GetTime() * speed_multiplier); 

            if (char_index < 1)
            {
                Debug.Log("Current Type Speed: " + speed_multiplier);
            }
            
            // Rounds numbers down so typing can happen.
            char_index = Mathf.FloorToInt(current_position);
            char_index = Mathf.Clamp(char_index, 0, text_input.Length);

            onscreen_text = text_input.Substring(0, char_index);

            Text.text = onscreen_text;
        }        
        else if (char_index == text_input.Length) // If at the end of the clip.
        {
            // Set the time of the timeline to the end of the track.
            parsed_graph.GetRootPlayable(0).SetTime(
                ((double)parsed_graph.GetRootPlayable(0).GetTime() - (float)playable.GetTime()) +
                 (float) playable.GetDuration() - 0.001f);
            //parsed_graph.GetRootPlayable(0).SetSpeed(0); // Pause the timeline.

            if (Input.GetKeyDown("space")) // Await for input. If input is done.
            {               
                char_index++; 
                //parsed_graph.GetRootPlayable(0).SetSpeed(1);
                //Debug.Log("Space is pressed.");
            }
        }
        // If an input is received & the dialogue has not finished typing & it is skippable.
        if (Input.GetKeyDown("space") && char_index < text_input.Length && !not_skippable) 
        {
            char_index = text_input.Length; // Make the typing effect reach the end instantly.
            onscreen_text = text_input; 
            Text.text = onscreen_text; 
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
