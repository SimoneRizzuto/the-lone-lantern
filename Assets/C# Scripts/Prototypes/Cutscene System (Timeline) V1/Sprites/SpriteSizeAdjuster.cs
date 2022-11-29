using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSizeAdjuster : MonoBehaviour
{
    //GameObject gameobject_image;
    Image image; 

    [SerializeField] public float XScale = 1f;
    [SerializeField] public float YScale = 1f;

    private Sprite sprite;
    private float sprite_width;
    private float sprite_height;

    // Start is called before the first frame update
    void Start()
    {
        //gameobject_image = GetComponent<GameObject>();
        image = GetComponent<Image>();
        // sprite = image.sprite;

        // sprite_width = sprite.rect.width;
        // sprite_height = sprite.rect.height;

        //width = image.preferredWidth;
        //height = image.preferredHeight;
        //Debug.Log(sprite_width + " " + sprite_height); 
    }

    // Update is called once per frame
    void Update()
    {   
        sprite = image.sprite;
        
        sprite_width = sprite.rect.width;
        sprite_height = sprite.rect.height;

        image.rectTransform.sizeDelta = new Vector2(sprite_width, sprite_height);
        image.rectTransform.localPosition = new Vector2(0, 0);
        image.rectTransform.localScale = new Vector2(XScale, YScale);


        //Debug.Log(sprite_width + " " + sprite_height); 
    }

}
