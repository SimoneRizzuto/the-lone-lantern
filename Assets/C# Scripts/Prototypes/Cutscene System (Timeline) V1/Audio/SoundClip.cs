using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SoundClip : PlayableAsset
{
    public AudioClip sound;
    public float speedInput;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<SoundBehaviour>.Create(graph);

        SoundBehaviour soundBehaviour = playable.GetBehaviour();
        soundBehaviour.sound = sound;
        soundBehaviour.speed_input = speedInput;
        soundBehaviour.parsed_graph = graph;

        return playable;
    }
}
