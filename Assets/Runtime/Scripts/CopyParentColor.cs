using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CopyParentColor : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField] private SpriteRenderer parentImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShareParentColor()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = parentImage.color;
    }
    private void OnEnable()
    {
        ShareParentColor();
    }
}
