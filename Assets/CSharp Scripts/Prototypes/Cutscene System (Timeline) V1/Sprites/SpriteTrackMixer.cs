using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SpriteTrackMixer : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        Image Sprite = playerData as Image;
        
        Sprite current_sprite = null;//Resources.Load<Sprite>("transparent 1");
        Sprite.gameObject.SetActive(true);

        if (!Sprite) { return; }

        int input_count = playable.GetInputCount();
        for (int i = 0; i < input_count; i++)
        {
            float input_weight = playable.GetInputWeight(i);
            if (input_weight > 0f)
            {
                ScriptPlayable<SpriteBehaviour> input_playable = (ScriptPlayable<SpriteBehaviour>)playable.GetInput(i);

                SpriteBehaviour input = input_playable.GetBehaviour();
                current_sprite = input.sprite;
            }
        }
        
        if (current_sprite == null)
        {
            Sprite.gameObject.SetActive(false);
        }
    }
}
