using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;


public class ButtonChangeColor : MonoBehaviour
{
    //[SerializeField] Button button;
    [SerializeField] Button roseFlowerButton;
    [SerializeField] Image colorPickedByPalete;
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ChangeColor);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void ChangeColor()
    {
        this.button.image.DOColor(colorPickedByPalete.color,3);
        this.button.image.DOFillAmount(3, 2);
        
    }

   /* public void ChangeRoseInternalColor()
    {
        roseFlowerButton.image.DOColor(colorPickedByPalete.color, 3);
        roseFlowerButton.image.DOFillAmount(3, 2);
    }*/
}
