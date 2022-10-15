using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogue_box;
    [SerializeField] private Image emote_sprite;
    [SerializeField] private TMP_Text text_label;
    [SerializeField] private Image text_box_sprite;
    [SerializeField] private DialogueObject text_dialogue;

    private TypeEffect type_effect;

    private void Start()
    {
        type_effect = GetComponent<TypeEffect>();
        CloseDialogueBox();
        ShowDialogue(text_dialogue);
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogue_box.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue (DialogueObject dialogueObject)
    {
        int dialogueObjectCount = 0;

        foreach (string dialogue in dialogueObject.SceneScript.ReturnAllLines())
        {
            float text_speed = dialogueObject.SceneScript.sceneScript[dialogueObjectCount].TypeSpeed;
            float text_size = dialogueObject.SceneScript.sceneScript[dialogueObjectCount].FontSize;
            Color colour = dialogueObject.SceneScript.sceneScript[dialogueObjectCount].Colour;

            yield return emote_sprite.sprite = dialogueObject.SceneScript.sceneScript[dialogueObjectCount].Emote;
            emote_sprite.SetNativeSize();

            text_label.faceColor = new Color(colour.r, colour.g, colour.b);
            yield return text_box_sprite.sprite = dialogueObject.SceneScript.sceneScript[dialogueObjectCount].TextBox;

            yield return type_effect.Run(dialogue, text_label, text_speed, text_size);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            yield return dialogueObjectCount++;
        }
        CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        dialogue_box.SetActive(false);
        text_label.text = string.Empty;
    }
}
