using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using UnityEngine.UI;

[TrackColor(255, 165, 0)]
[TrackBindingType(typeof(AudioSource))]
[TrackClipType(typeof(SoundClip))]
public class SoundTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<SoundTrackMixer>.Create(graph, inputCount);
    }
}

