using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SoundTrackMixer : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        AudioSource Sound = playerData as AudioSource;
        
        AudioClip current_sound = null;
        Sound.gameObject.SetActive(true);

        if (!Sound) { return; }

        int input_count = playable.GetInputCount();
        for (int i = 0; i < input_count; i++)
        {
            float input_weight = playable.GetInputWeight(i);
            if (input_weight > 0f)
            {
                ScriptPlayable<SoundBehaviour> input_playable = (ScriptPlayable<SoundBehaviour>)playable.GetInput(i);

                SoundBehaviour input = input_playable.GetBehaviour();
                current_sound = input.sound;
            }
        }
        
        if (current_sound == null)
        {
            Sound.gameObject.SetActive(false);
        }
    }
}
