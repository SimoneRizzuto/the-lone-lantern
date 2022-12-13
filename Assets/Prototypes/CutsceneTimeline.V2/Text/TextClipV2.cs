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

        private int count = 0;
        
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<TextBehaviourV2>.Create(graph);

            Debug.Log($"Initialised \"{count}\" times...\n");
            
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
