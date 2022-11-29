using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using TMPro;
using UnityEngine.Playables;
using UnityEngine.UI;

[TrackColor(255, 255, 0)]
[TrackBindingType(typeof(Image))]
[TrackClipType(typeof(SpriteClip))]
public class SpriteTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<SpriteTrackMixer>.Create(graph, inputCount);
    }
}