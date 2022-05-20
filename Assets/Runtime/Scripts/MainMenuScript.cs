using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject credits;
    [SerializeField] GameObject controls;
    [SerializeField] Image blackScreen;
    private float fadeSpeed = 2;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        StartCoroutine(FadeTransition(3));
    }

    public void ShowCredits()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void BackMainMenu()
    {
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }

    public void ControlsMenu()
    {
        mainMenu.SetActive(false);
        controls.SetActive(true);
    }
    public void ExitControlMenu()
    {
        mainMenu.SetActive(true);
        controls.SetActive(false);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    private void FadeInBlackScreen()
    {
        blackScreen.DOFade(1, fadeSpeed);

    }

    private void FadeOutBlackScreen()
    {
        blackScreen.DOFade(0, fadeSpeed);

    }

    public IEnumerator FadeTransition(float timeToFade)
    {
        FadeInBlackScreen();
        yield return new WaitForSeconds(timeToFade);
        SceneManager.LoadScene("GameJamMentalHealthGame");
    }


}
