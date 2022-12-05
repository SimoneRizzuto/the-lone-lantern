using UnityEngine;
using UnityEngine.Playables;

public class TextClipV2 : PlayableAsset
{
    public enum FontSizes
    {
        Whisper,
        Normal,
        Yell
    };

    [TextArea]
    public string text;
    public bool notSkippable;
    public float typeSpeed;
    public FontSizes fontSizes;
    

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<TextBehaviour>.Create(graph);

        TextBehaviour textBehaviour = playable.GetBehaviour();
        textBehaviour.text_input = text;
        textBehaviour.speed_input = typeSpeed;
        textBehaviour.not_skippable = notSkippable;
        textBehaviour.char_index = 0;
        textBehaviour.parsed_graph = graph;
        if (fontSizes == FontSizes.Whisper)
        {
            textBehaviour.font_size = "whisper";
        }
        else if (fontSizes == FontSizes.Normal)
        {
            textBehaviour.font_size = "normal";
        }
        else if (fontSizes == FontSizes.Yell)
        {
            textBehaviour.font_size = "yell";
        }
        
        return playable;
    }
}
