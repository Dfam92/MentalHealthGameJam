using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField] Image blackScreen;
    [SerializeField] float fadeSpeed;
    public bool inTrasition = true;
    bool inPlayMode = true;
    bool inColorMode;
    public bool inDayOne;
    public bool inDayTwo;
    public bool inDayThree;
    public bool inFInalDay;
    public bool flowersWereWatered;
    public bool wateringCanWasCaught;
    public bool wateringCanWasFilled;
    public bool bucketWasFilled;
    public bool bucketIsDisponible;
    public bool InPlayMode { get => inPlayMode; private set => inPlayMode = value; }
    public bool InColorMode { get => inColorMode; private set => inColorMode = value; }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void FadeInBlackScreen()
    {
         blackScreen.DOFade(1, fadeSpeed);
        
    }

    public void FadeOutBlackScreen()
    {
         blackScreen.DOFade(0, fadeSpeed);
        
    }

    public IEnumerator FadeTransition(float timeToWaitFadeOut)
    {
        FadeInBlackScreen();
        yield return new WaitForSeconds(timeToWaitFadeOut);
        FadeOutBlackScreen(); ;
    }
}
