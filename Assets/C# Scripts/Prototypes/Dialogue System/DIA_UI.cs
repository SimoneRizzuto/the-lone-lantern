using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// How to use:
// Add this to a "PFB_CanvasUI" object. It should automatically work, depending on everything else being setup.
// Should be on the highest layer.
// Refer to DevRoom for reference.

public class DIA_UI : MonoBehaviour
{
    [SerializeField] public DIA_Object TextDialogue;

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private Image emoteSprite;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private Image textBoxSprite;

    private DIA_TypeEffect typeEffect;
    public bool IsShowingDialogue = false;
    
    void Start()
    {
        typeEffect = GetComponent<DIA_TypeEffect>();
        ShowDialogue(TextDialogue);
    }
    void Update()
    {
        if (!IsShowingDialogue)
        {
            typeEffect = GetComponent<DIA_TypeEffect>();
            ShowDialogue(TextDialogue);
        }

        if (this.gameObject.activeInHierarchy)
        {
            IsShowingDialogue = true;
        }
        else 
        {
            IsShowingDialogue = false;
        }        
    }

    public void ShowDialogue(DIA_Object dialogueObject)
    {
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
        dialogueObjectCount = 0;

        CloseDialogueBox(dialogueObject);        
    }

    private void CloseDialogueBox(DIA_Object dialogueObject)
    {
        IsShowingDialogue = false;

        var finalLine = dialogueObject.SceneScript.sceneScript[dialogueObject.SceneScript.sceneScript.Length - 1];
        
        GameObject.Find("PFB_StateManager").GetComponent<OBJ_GameState>().SetDirectly(finalLine.GameStateSetForFinalLine);
        
        textLabel.text = string.Empty;
        dialogueBox.SetActive(false);
    }
}