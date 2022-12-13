using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SoundBehaviour : PlayableBehaviour
{
    // From Clip.
    public AudioClip sound;
    public float speed_input;
    
    
    public float current_position;
    public int sound_index;
    public PlayableGraph parsed_graph;

    public bool new_letter;
    public int previous_number = -1;

    
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        AudioSource Sound = playerData as AudioSource;
        
        if (speed_input > 0)
        {

        }
        else
        {
            speed_input = 15;
        }

        current_position = 1 + ((float)playable.GetTime() * speed_input);

        sound_index = Mathf.FloorToInt(current_position);
        sound_index = Mathf.Clamp(sound_index, 0, 3);

        // Have code that counts how many letters in the text, and 
        // play the sound as many times as how many characters there are.

        if (previous_number < current_position)
        {
            Sound.PlayOneShot(sound, 1);
            previous_number++;
        }
        

    }
}
