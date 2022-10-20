using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DIA_UI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private Image emoteSprite;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private Image textBoxSprite;
    [SerializeField] private DIA_Object textDialogue;

    private DIA_TypeEffect typeEffect;

    private void Start()
    {
        typeEffect = GetComponent<DIA_TypeEffect>();
        CloseDialogueBox();
        ShowDialogue(textDialogue);
    }

    public void ShowDialogue(DIA_Object dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue (DIA_Object dialogueObject)
    {
        int dialogueObjectCount = 0;

        foreach (string dialogue in dialogueObject.SceneScript.ReturnAllLines())
        {
            float text_speed = dialogueObject.SceneScript.sceneScript[dialogueObjectCount].TypeSpeed;
            float text_size = dialogueObject.SceneScript.sceneScript[dialogueObjectCount].FontSize;
            Color colour = dialogueObject.SceneScript.sceneScript[dialogueObjectCount].Colour;

            yield return emoteSprite.sprite = dialogueObject.SceneScript.sceneScript[dialogueObjectCount].Emote;
            emoteSprite.SetNativeSize();

            textLabel.faceColor = new Color(colour.r, colour.g, colour.b);
            yield return textBoxSprite.sprite = dialogueObject.SceneScript.sceneScript[dialogueObjectCount].TextBox;

            yield return typeEffect.Run(dialogue, textLabel, text_speed, text_size);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return dialogueObjectCount++;
        }
        CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
