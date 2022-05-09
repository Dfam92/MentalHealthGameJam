using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;


public class ButtonChangeColor : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] Image colorPickedByPalete;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void ChangeColor()
    {
        button.image.DOColor(colorPickedByPalete.color,3);
        button.image.DOFillAmount(3, 2);
        
        
    }
}
