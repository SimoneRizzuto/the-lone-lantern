using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SpriteBehaviour : PlayableBehaviour
{
    // From Clip.
    public Sprite sprite;
    public bool animated;

    public PlayableGraph parsed_graph;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        Image Sprite = playerData as Image;

        Sprite.sprite = sprite;
        
        
    }
}
