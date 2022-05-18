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

    [SerializeField] GameObject backGroundColorMode;
    [SerializeField] GameObject playModeCamera;
    [SerializeField] GameObject colorModeCamera;
    [SerializeField] GameObject flowersToColor;

    [SerializeField] Button backButton;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ColorFlowers()
    {
        backGroundColorMode.SetActive(false);
        playModeCamera.SetActive(false);
        colorModeCamera.SetActive(true);
        flowersToColor.SetActive(true);
        StartCoroutine(ActiveBackButton());
    }

    public void BackColorFlower()
    {
        backGroundColorMode.SetActive(false);
        playModeCamera.SetActive(true);
        colorModeCamera.SetActive(false);
        flowersToColor.SetActive(false);
        objectiveWasFinished = true;
        flowersAreDisponible = false;
        backButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        numberDay.text = " " + countDays;
        if (dayOver)
        {
            objectivesCount = 0;
        }
        CheckObjective(listOfObjectivesDayOne,inDayOne,dayOneObjectives);
        CheckObjective(listOfObjectivesDayTwo, inDayTwo,dayTwoObjectives);
        CheckObjective(listOfObjectivesDayThree, inDayThree,dayThreeObjectives);
        CheckObjective(listOfObjectivesFinalDay, inFInalDay,finalDayObjectives);
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


}
