using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeEffect : MonoBehaviour
{
    public Coroutine Run(string textToType, TMP_Text textLabel, float textSpeed, float textSize)
    {
        return StartCoroutine(TypeText(textToType, textLabel, textSpeed, textSize));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel, float textSpeed, float textSize)
    {
        textLabel.text = string.Empty;

        float time_elapsed = 0;
        int char_index = 0;

        textLabel.fontSize = textSize;

        while (char_index < textToType.Length)
        {
            // Holds the amount of time passed.
            time_elapsed += Time.deltaTime * textSpeed;
            // Holds a rounded down number of the current time passed. e.g. time_elasped = 3.43, char_index = 3.
            char_index = Mathf.FloorToInt(time_elapsed);
            char_index = Mathf.Clamp(char_index, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, char_index);

            yield return null;
        }

        textLabel.text = textToType;
    }
}
