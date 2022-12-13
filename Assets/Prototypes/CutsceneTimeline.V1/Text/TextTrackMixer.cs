using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class TextTrackMixer : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI Text = playerData as TextMeshProUGUI;
        
        string current_text = "";

        if (!Text) { return; }

        int input_count = playable.GetInputCount();
        for (int i = 0; i < input_count; i++)
        {
            float input_weight = playable.GetInputWeight(i);
            if (input_weight > 0f)
            {
                ScriptPlayable<TextBehaviour> input_playable = (ScriptPlayable<TextBehaviour>)playable.GetInput(i);

                TextBehaviour input = input_playable.GetBehaviour();
                current_text = input.onscreen_text;
                
            }
        }
        Text.text = current_text;
        
    }

}
