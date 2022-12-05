using CSharpScripts.Constants;
using UnityEngine;
using UnityEngine.Playables;

namespace CSharpScripts.Prototypes.CutsceneTimeline.V2.Text
{
    public class TextClipV2 : PlayableAsset
    {
        [TextArea]
        public string text;
        public bool notSkippable;
        public float typeSpeed;
        public FontSizes fontSizes;
    
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<TextBehaviourV2>.Create(graph);

            TextBehaviourV2 textBehaviour = playable.GetBehaviour();
            textBehaviour.TextInput = text;
            textBehaviour.SpeedInput = typeSpeed;
            textBehaviour.NotSkippable = notSkippable;
            textBehaviour.CharIndex = 0;
            textBehaviour.ParsedGraph = graph;
            textBehaviour.FontSize = fontSizes;
        
            return playable;
        }
    }
}
