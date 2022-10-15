// using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class SpriteClip : PlayableAsset
{
    public Sprite sprite;
    public bool animated;
    
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SpriteBehaviour>.Create(graph);

        SpriteBehaviour spriteBehaviour = playable.GetBehaviour();
        spriteBehaviour.sprite = sprite;
        spriteBehaviour.animated = animated;
        spriteBehaviour.parsed_graph = graph;

        return playable;
    }
}
