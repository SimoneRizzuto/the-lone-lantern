using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Dialogue Object")]
public class DIA_Object : ScriptableObject
{
    [SerializeField] private SceneScript script;

    // Getter, only allows this to be read, not to override it.
    public SceneScript SceneScript => script;
}
[System.Serializable]
public class SceneLine
{
    public Sprite Emote;
    public AudioSource Voice;
    public Sprite TextBox;
    [SerializeField] [TextArea] public string Dialogue;
    public float TypeSpeed;
    public float FontSize;
    public Color Colour;
}
[System.Serializable]
public class SceneScript
{
    public SceneLine[] sceneScript;

    public List<string> ReturnAllLines()
    {
        List<string> allLines = new List<string>();

        for (int i = 0; i < sceneScript.Length; i++)
        {
            allLines.Add(sceneScript[i].Dialogue);
        }

        return allLines;
    }
}
