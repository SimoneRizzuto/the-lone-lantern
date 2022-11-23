using UnityEngine;

public class OBJ_GameState : MonoBehaviour
{
    [SerializeField] public Constants.GameState CurrentGameState = Constants.GameState.Normal;
    
    /// Could add methods to this OBJ for changing the state of the game.

    public void SetToNormal()
    {
        CurrentGameState = Constants.GameState.Normal;
    }
    public void SetToMenu()
    {
        CurrentGameState = Constants.GameState.Menu;
    }
    public void SetToInteraction()
    {
        CurrentGameState = Constants.GameState.Interaction;
        
        var dialogueUI = GameObject.Find("PFB_CanvasUI").transform.GetChild(0).GetComponent<DIA_UI>();
        dialogueUI.gameObject.SetActive(true);
        
    }
    public void SetToCutscene()
    {
        CurrentGameState = Constants.GameState.Interaction;
    }
    public void SetToCombat()
    {
        CurrentGameState = Constants.GameState.Combat;
    }

    public void SetDirectly(Constants.GameState gameState)
    {
        CurrentGameState = gameState;
    }
}
