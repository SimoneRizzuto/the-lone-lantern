using CSharpScripts;
using UnityEngine;

public class P_Interaction : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var interactableObject = GameObject.FindObjectOfType<IB_IsColliding_Interactable>().IsCollidingWithInteractable();
            if (interactableObject == null) return;

            var scriptHolder = interactableObject.GetComponent<DIA_ScriptHolder>();
            if (scriptHolder == null) return;

            DIA_Object textDialogue = scriptHolder.TextDialogue;
            var dialogueUI = GameObject.Find("PFB_CanvasUI").transform.GetChild(0).GetComponent<DIA_UI>();

            dialogueUI.TextDialogue = textDialogue;
            if (!dialogueUI.isActiveAndEnabled)
            {
                GameObject.Find("PFB_StateManager").GetComponent<OBJ_GameState>().SetToInteraction();
            }
        }
    }
}
