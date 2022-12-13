using CSharpScripts.Constants;
using UnityEngine;

namespace CSharpScripts
{
    public class OBJ_GameState : MonoBehaviour
    {
        [SerializeField] public GameState CurrentGameState = GameState.Normal;
    
        /// Could add methods to this OBJ for changing the state of the game.

        public void SetToNormal()
        {
            CurrentGameState = GameState.Normal;
        }
        public void SetToMenu()
        {
            CurrentGameState = GameState.Menu;
        }
        public void SetToInteraction()
        {
            CurrentGameState = GameState.Interaction;
        
            var dialogueUI = GameObject.Find("PFB_CanvasUI").transform.GetChild(0).GetComponent<DIA_UI>();
            dialogueUI.gameObject.SetActive(true);
        
        }
        public void SetToCutscene()
        {
            CurrentGameState = GameState.Interaction;
        }
        public void SetToCombat()
        {
            CurrentGameState = GameState.Combat;
        }

        public void SetDirectly(GameState gameState)
        {
            CurrentGameState = gameState;
        }
    }
}
