using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class LinkColor : MonoBehaviour
{
    private Button buttonColor;
    [SerializeField] Image imageToColor;

    // Start is called before the first frame update
    void Start()
    {
        buttonColor = GetComponent<Button>();
        buttonColor.onClick.AddListener(ColorImage);
    }

  
    // Update is called once per frame

    public void ColorImage()
    {
        StartCoroutine(ColorImageCorroutine());
    }

    IEnumerator ColorImageCorroutine()
    {
        yield return new WaitForSeconds(3);
        imageToColor.DOColor(buttonColor.image.color, 0);
    }
}
