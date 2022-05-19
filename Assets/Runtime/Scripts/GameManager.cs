using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] Image blackScreen;
    [SerializeField] float fadeSpeed;

    [SerializeField] TextMeshProUGUI numberDay;

    public List<TextMeshProUGUI> listOfObjectivesDayOne;
    public List<TextMeshProUGUI> listOfObjectivesDayTwo;
    public List<TextMeshProUGUI> listOfObjectivesDayThree;
    public List<TextMeshProUGUI> listOfObjectivesFinalDay;

    [SerializeField] GameObject dayOneObjectives;
    [SerializeField] GameObject dayTwoObjectives;
    [SerializeField] GameObject dayThreeObjectives;
    [SerializeField] GameObject finalDayObjectives;

    [SerializeField] GameObject canvasColorMode;
    [SerializeField] GameObject canvasPlayMode;

    [SerializeField] GameObject backGroundColorMode;
    [SerializeField] GameObject playModeCamera;
    [SerializeField] GameObject colorModeCamera;
    [SerializeField] GameObject flowersToColor;
    [SerializeField] GameObject hints;
    
    [SerializeField] Button backButton;
    [SerializeField] GameObject showHints;
    [SerializeField] GameObject hideHints;
    [SerializeField] GameObject playModeButton;
    [SerializeField] GameObject backGroundFlowers;

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
    public bool flowersAreDisponible;
    public bool InPlayMode { get => inPlayMode; private set => inPlayMode = value; }
    public bool InColorMode { get => inColorMode; private set => inColorMode = value; }

    public bool objectiveWasFinished;

    public bool dayOver;

    int objectivesCount = 0;
    public int countDays = 1;

    private bool hintsOn = false;

    // Start is called before the first frame update
    void Start()
    {
        canvasColorMode.SetActive(false);
    }

    public void ColorFlowers()
    {
        
        backGroundColorMode.SetActive(false);
        playModeCamera.SetActive(false);
        colorModeCamera.SetActive(true);
        flowersToColor.SetActive(true);
        playModeButton.SetActive(false);
        StartCoroutine(ActiveBackButton());
        backGroundFlowers.SetActive(true);
        InColorMode = true;
        InPlayMode = false;
    }

    public void BackColorFlower()
    {
        backGroundColorMode.SetActive(false);
        playModeCamera.SetActive(true);
        colorModeCamera.SetActive(false);
        flowersToColor.SetActive(false);
        playModeButton.SetActive(true);
        objectiveWasFinished = true;
        flowersAreDisponible = false;
        backButton.interactable = false;
        backGroundFlowers.SetActive(false);
        InPlayMode = true;
        InColorMode = false;
    }

    // Update is called once per frame
    void Update()
    {

        CheckModeOfPlay();
        CheckHints();
    
        numberDay.text = " " + countDays;
        
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

    public void CheckObjective(List<TextMeshProUGUI> listOfObjectives, bool day,GameObject dayObject)
    {
        
        if(day)
        {
            dayOver = false;
            listOfObjectives[objectivesCount].gameObject.SetActive(true);
            dayObject.SetActive(true);
            if (objectiveWasFinished)
            {
                objectiveWasFinished = false;
                listOfObjectives[objectivesCount].gameObject.SetActive(false);

                if (listOfObjectives.Count > objectivesCount)
                {
                    objectivesCount++;
                    listOfObjectives[objectivesCount].gameObject.SetActive(true);
                }
            }
        }
        else
        {
            dayObject.SetActive(false);
        }
        
    }

    IEnumerator ActiveBackButton()
    {
        yield return new WaitForSeconds(3);
        backButton.interactable = true;
    }

    public void ShowHints()
    {
        if(!hintsOn)
        {
            hints.SetActive(true);
            hintsOn = true;
            hideHints.SetActive(true);
            showHints.SetActive(false);
        }
        else if(hintsOn)
        {
           
           hints.SetActive(false);
           hintsOn = false;
           showHints.SetActive(true);
           hideHints.SetActive(false);
        }
        
    }

    private void CheckModeOfPlay()
    {
        if (InColorMode)
        {
            canvasColorMode.SetActive(true);
            colorModeCamera.SetActive(true);
        }
        else
        {
            canvasColorMode.SetActive(false);
            colorModeCamera.SetActive(false);
        }

        if (inPlayMode)
        {
            canvasPlayMode.SetActive(true);
            playModeCamera.SetActive(true);
        }
        else
        {
            canvasPlayMode.SetActive(false);
            playModeCamera.SetActive(false);
        }
    }

    private void CheckHints()
    {
        if (dayOver)
        {
            objectivesCount = 0;
        }
        CheckObjective(listOfObjectivesDayOne, inDayOne, dayOneObjectives);
        CheckObjective(listOfObjectivesDayTwo, inDayTwo, dayTwoObjectives);
        CheckObjective(listOfObjectivesDayThree, inDayThree, dayThreeObjectives);
        CheckObjective(listOfObjectivesFinalDay, inFInalDay, finalDayObjectives);
    }
    
    public void ColorModeOn()
    {
        StartCoroutine(ChangeFadeColorMode());
    }

    public void PlayModeOn()
    {
        StartCoroutine(ChangeFadePlayMode());
    }

    IEnumerator ChangeFadeColorMode()
    {
        StartCoroutine(FadeTransition(4));
        yield return new WaitForSeconds(4);
        InColorMode = true;
        InPlayMode = false;
        backGroundColorMode.SetActive(true);
    }

    IEnumerator ChangeFadePlayMode()
    {
        StartCoroutine(FadeTransition(4));
        yield return new WaitForSeconds(4);
        InPlayMode = true;
        InColorMode = false;
        backGroundColorMode.SetActive(false);

    }
}
