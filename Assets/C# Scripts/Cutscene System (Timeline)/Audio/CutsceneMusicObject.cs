using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cutscene/Music Controller")]
public class CutsceneMusicObject : ScriptableObject
{
    [SerializeField] public ScenePlaylist scenePlaylist;

    // Getter, only allows this to be read, not to override it.
    public ScenePlaylist ScenePlaylist => scenePlaylist;
}

[System.Serializable]
public class ScenePlaylist
{
    public SceneSong[] sceneSongs;

    // public float StartTime()
    // {
        
    // }
    // public List<string> ReturnAllLines()
    // {
    //     List<string> all_lines = new List<string>();

    //     for (int i = 0; i < scene_songs.Length; i++)
    //     {
    //         all_lines.Add(scene_songs[i].Dialogue);
    //     }

    //     return all_lines;
    // }
}

[System.Serializable]
public class SceneSong
{
    [SerializeField] public AudioClip song;
    [SerializeField] public float start;
    [SerializeField] public float stop;
    [SerializeField] public bool startFade;
    //[SerializeField] public enum startFadeSpeed;
    [SerializeField] public bool endFade;
    //[SerializeField] public enum endFadeSpeed;
    [SerializeField] public bool loop;
}