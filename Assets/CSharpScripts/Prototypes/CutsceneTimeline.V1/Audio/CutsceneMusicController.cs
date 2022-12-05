using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneMusicController : MonoBehaviour
{
    [SerializeField] PlayableDirector cutscene; 
    [SerializeField] AudioSource audio;
    [SerializeField] CutsceneMusicObject music; 

    float count = 0;
    double rounded_time;

    bool fading_in = false, fading_out = false;

    // MAKE A CUTSCENEMUSICDIRECTOR OBJECT THAT WILL HAVE THE SCRIPT FOR A CUTSCENE (like for normal text)

    // THIS CLASS WILL DO 3 THINGS:
    // Check if the music has started playing. If so, start at a low volume and fade in for however long the developer wants.
    // Allow the song to play on loop without any fade out or in.
    // Once it is the end of the cutscene, make it fade out.

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("MUSIC CONTROLLER Cutscene Length: " + (float)cutscene.duration);
    }

    // Update is called once per frame
    void Update()
    {
        // if (cutscene.playableGraph.)
        // {
            rounded_time = System.Math.Round(cutscene.playableGraph.GetRootPlayable(0).GetTime(), 2);

            if (rounded_time >= music.scenePlaylist.sceneSongs[0].start && rounded_time <= music.scenePlaylist.sceneSongs[0].start + 0.5)
            {
                //if song isn't playing yet, play song
                if (!audio.isPlaying)
                {
                    if (music.scenePlaylist.sceneSongs[0].loop)
                    {
                        audio.loop = true;
                    }
                    else if (!music.scenePlaylist.sceneSongs[0].loop)
                    {
                        audio.loop = false;
                    }

                    if (music.scenePlaylist.sceneSongs[0].startFade)// fade in code
                    {
                        audio.volume = 0;
                        fading_in = true;
                    }

                    // audio.PlayOneShot(music.scenePlaylist.sceneSongs[0].song);
                    //Debug.Log("Song begins playing...");
                    audio.PlayOneShot(music.scenePlaylist.sceneSongs[0].song);
                    Debug.Log("Song begins playing...");
                }
            }

            if (audio.isPlaying)  
            {
                if (!music.scenePlaylist.sceneSongs[0].endFade) // If the song won't fade out.
                {
                    if (rounded_time >= music.scenePlaylist.sceneSongs[0].stop && rounded_time <= music.scenePlaylist.sceneSongs[0].stop + 0.5) // If its at the end of the song.
                    {
                        audio.Stop();
                        Debug.Log("Song ends...");
                    }
                }
                else if (music.scenePlaylist.sceneSongs[0].endFade && !fading_out
                && rounded_time >= music.scenePlaylist.sceneSongs[0].stop && rounded_time <= music.scenePlaylist.sceneSongs[0].stop + 0.5) // If the song will fade out, fading out isn't happening, and it is at allocated time of fading.
                {
                    fading_in = false;
                    fading_out = true;
                }
            }
        // }
        
        
        if (fading_in)
        {
            FadeInSong(audio);
        }
        if (fading_out)
        {
            FadeOutSong(audio);
        }
        
        

        //Debug.Log($"CURRENT TIME: {rounded_time} \nSONG BEGINNING: {music.scenePlaylist.sceneSongs[0].start}");

        //Debug.Log("MUSIC CONTROLLER Cutscene Length:" + (float)cutscene.playableGraph.GetRootPlayable(0).GetTime());
    }

    void FadeInSong(AudioSource audioSource)
    {
        
        if (audioSource.volume != 1 && audioSource.isPlaying)
        {
            audioSource.volume += 0.001f;
            //count += 0.001f;
            //Debug.Log(audioSource.volume);
            //Debug.Log("How long did it take to reach max volume? " + count + " seconds.");
        }
        else
        {
            fading_in = false;
        }
    }

    void FadeOutSong(AudioSource audioSource)
    {
        // Check if song is close to the end
        if (audioSource.isPlaying && audioSource.volume != 0)
        {
            audioSource.volume -= 0.001f;
            Debug.Log(audioSource.volume);
        }
        else
        {
            fading_out = false;
        }
    }
}
