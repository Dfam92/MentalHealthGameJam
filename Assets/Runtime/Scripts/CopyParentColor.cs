using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyParentColor : MonoBehaviour
{
    private SpriteRenderer sprite;
    private Image parentImage;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        parentImage = GetComponentInParent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShareParentColor()
    {
        sprite.color = parentImage.color;
    }
}
