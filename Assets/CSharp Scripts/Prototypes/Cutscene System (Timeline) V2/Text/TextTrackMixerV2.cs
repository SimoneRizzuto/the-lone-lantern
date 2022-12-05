using TMPro;
using UnityEngine.Playables;

namespace CSharp_Scripts.Prototypes.Cutscene_System__Timeline__V2.Text
{
    public class TextTrackMixerV2 : PlayableBehaviour
    {
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            TextMeshProUGUI text = playerData as TextMeshProUGUI;
        
            string currentText = "";

            if (!text) { return; }

            int inputCount = playable.GetInputCount();
            for (int i = 0; i < inputCount; i++)
            {
                float inputWeight = playable.GetInputWeight(i);
                if (inputWeight > 0f)
                {
                    ScriptPlayable<TextBehaviour> inputPlayable = (ScriptPlayable<TextBehaviour>)playable.GetInput(i);

                    TextBehaviour input = inputPlayable.GetBehaviour();
                    currentText = input.onscreen_text;
                
                }
            }
            text.text = currentText;
        }
    }
}
