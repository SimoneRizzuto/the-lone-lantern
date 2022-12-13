using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace CSharpScripts.Prototypes.CutsceneTimeline.V2.Text
{
    [TrackColor(0, 255, 0)]
    [TrackBindingType(typeof(TextMeshProUGUI))]
    [TrackClipType(typeof(TextClip))]
    public class TextTrackV2 : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<TextTrackMixer>.Create(graph, inputCount);
        }
    }
}