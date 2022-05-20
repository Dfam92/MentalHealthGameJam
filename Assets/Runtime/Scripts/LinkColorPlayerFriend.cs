using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class LinkColorPlayerFriend : MonoBehaviour
{
    [SerializeField] List<Image> rootImagesToShare;
    [SerializeField] List<SpriteRenderer> bodyParts;
    // Start is called before the first frame update
    public void ColorPlayFriend()
    {
        for (int i = 0; i < bodyParts.Count; i++)
        {
            
                bodyParts[i].color = rootImagesToShare[i].color;
        }
    }
   
}
