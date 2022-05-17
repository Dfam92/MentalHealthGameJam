using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] private float playerSpeed;
    [SerializeField] private SpriteRenderer interactionBoxesGarden;
    [SerializeField] private SpriteRenderer interactionBoxesDoor;
    [SerializeField] private SpriteRenderer interactionBoxesWell;
    [SerializeField] private float fadeSpeed;
    [SerializeField] private GameObject backGround;
    [SerializeField] private float parallaxEffect;
    [SerializeField] GameManager gameManager;
    [SerializeField] float dayFadeTime;
    [SerializeField] GameObject wateringCanSelected;
    [SerializeField] GameObject wateringCanDesactived;
    [SerializeField] GameObject bucketFilled;
    [SerializeField] GameObject bucketLiquid;
    [SerializeField] GameObject Daisy1;
    [SerializeField] GameObject Daisy2;
    [SerializeField] GameObject Daisy3;
    [SerializeField] GameObject Rose1;
    [SerializeField] GameObject Rose2;
    [SerializeField] GameObject Rose3;
    [SerializeField] GameObject Daisy1Button;
    [SerializeField] GameObject Daisy2Button;
    [SerializeField] GameObject Daisy3Button;
    [SerializeField] GameObject Rose1Button;
    [SerializeField] GameObject Rose2Button;
    [SerializeField] GameObject Rose3Button;

    private int rotationWellCount;
    //[SerializeField] CopyParentColor parentColor;
    private bool inInteraction;
    private Color defaultColor;

    //Todo
    //parentColor.ShareParentColor() call when the color mode is disabled;

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = interactionBoxesGarden.color;
    }
    private void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (gameManager.InPlayMode)
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            playerRb.AddForce(Vector2.right * horizontalInput * playerSpeed);
            backGround.transform.position = new Vector3(parallaxEffect, backGround.transform.position.y, backGround.transform.position.z);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("ColorFlowers"))
        {
            PlayerInteraction();
            if(inInteraction && gameManager.flowersAreDisponible && !gameManager.inDayOne)
            {
                gameManager.ColorFlowers();
                gameManager.flowersAreDisponible = false;
                
            }
        }
        if (collision.CompareTag("WateringCan"))
        {
            PlayerInteraction();
            if (inInteraction == true && gameManager.bucketIsDisponible)
            {
                Debug.Log("Watering pressed");
                gameManager.wateringCanWasCaught = true;
                gameManager.objectiveWasFinished = true;
                wateringCanSelected.SetActive(true);
                wateringCanDesactived.SetActive(false);


            }
        }
        if (collision.CompareTag("GardenTerrain"))
        {
            float alphaBoxFadeIn = interactionBoxesGarden.color.a + Mathf.Clamp(1, 0, fadeSpeed);
            interactionBoxesGarden.color = new Color(interactionBoxesGarden.color.r, interactionBoxesGarden.color.g, interactionBoxesGarden.color.b, alphaBoxFadeIn);
            PlayerInteraction();
            if (inInteraction == true && gameManager.wateringCanWasCaught && gameManager.wateringCanWasFilled && gameManager.bucketWasFilled)
            {
                wateringCanSelected.SetActive(false);
                wateringCanDesactived.SetActive(true);
                gameManager.flowersWereWatered = true;
                gameManager.objectiveWasFinished = true;
                Debug.Log("Garden was Watered");
            }
            else if (inInteraction == true && gameManager.wateringCanWasCaught && !gameManager.wateringCanWasFilled)
            {
                Debug.Log("You need some water");
            }

        }
        if (collision.CompareTag("WellBox"))
        {
            float alphaBoxFadeIn = interactionBoxesWell.color.a + Mathf.Clamp(1, 0, fadeSpeed);
            interactionBoxesWell.color = new Color(interactionBoxesWell.color.r, interactionBoxesWell.color.g, interactionBoxesWell.color.b, alphaBoxFadeIn);
            PlayerInteraction();
            if (inInteraction == true && !gameManager.inDayOne && !gameManager.bucketIsDisponible)
            {
                Debug.Log("Need To fill the bucket");
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rotationWellCount++;
                    Debug.Log(rotationWellCount);
                    if (rotationWellCount == 10)
                    {
                        bucketLiquid.SetActive(true);
                        bucketFilled.SetActive(true);
                        gameManager.bucketIsDisponible = true;
                        gameManager.objectiveWasFinished = true;
                        Debug.Log("BucketDisponible");
                        rotationWellCount = 0;

                    }
                }
            }

            if (inInteraction == true && gameManager.wateringCanWasCaught && !gameManager.wateringCanWasFilled && !gameManager.bucketWasFilled && gameManager.bucketIsDisponible)
            {
                Debug.Log("Watering Can was filled");
                gameManager.wateringCanWasFilled = true;
                gameManager.bucketWasFilled = true;
                gameManager.objectiveWasFinished = true;
            }
            else if (inInteraction == true && gameManager.wateringCanWasCaught && gameManager.wateringCanWasFilled)
            {
                Debug.Log("Watering can already filled");
            }

        }
        if (collision.CompareTag("DoorBox"))
        {
            float alphaBoxFadeIn = interactionBoxesDoor.color.a + Mathf.Clamp(1, 0, fadeSpeed);
            interactionBoxesDoor.color = new Color(interactionBoxesDoor.color.r, interactionBoxesDoor.color.g, interactionBoxesDoor.color.b, alphaBoxFadeIn);
            PlayerInteraction();
            if (inInteraction == true && gameManager.flowersWereWatered)
            {
                if (gameManager.inDayOne)
                {
                    gameManager.inDayTwo = true;
                    gameManager.inDayOne = false;
                    Daisy1.SetActive(true);
                    Rose1.SetActive(true);
                    ResetDay();
                    StartCoroutine(gameManager.FadeTransition(dayFadeTime));
                }
                else if (gameManager.inDayTwo && gameManager.flowersWereWatered)
                {
                    gameManager.inDayTwo = false;
                    gameManager.inDayThree = true;
                    Daisy2.SetActive(true);
                    Daisy1.SetActive(false);
                    Rose1.SetActive(false);
                    Rose2.SetActive(true);
                    Daisy2Button.SetActive(true);
                    Daisy1Button.SetActive(false);
                    Rose1Button.SetActive(false);
                    Rose2Button.SetActive(true);
                    ResetDay();
                    StartCoroutine(gameManager.FadeTransition(dayFadeTime));
                }
                else if (gameManager.inDayThree && gameManager.flowersWereWatered)
                {
                    gameManager.inDayThree = false;
                    gameManager.inFInalDay = true;
                    Daisy2.SetActive(false);
                    Daisy3.SetActive(true);
                    Rose2.SetActive(false);
                    Rose3.SetActive(true);
                    Daisy2Button.SetActive(false);
                    Daisy3Button.SetActive(true);
                    Rose2Button.SetActive(false);
                    Rose3Button.SetActive(true);
                    ResetDay();
                    StartCoroutine(gameManager.FadeTransition(dayFadeTime));
                }
            }
            else if (inInteraction == true && !gameManager.flowersWereWatered)
            {
                Debug.Log("FlowersNeedWater");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("GardenTerrain"))
        {
            interactionBoxesGarden.color = defaultColor;

        }

        if (collision.CompareTag("WellBox"))
        {
            interactionBoxesWell.color = defaultColor;

        }

        if (collision.CompareTag("DoorBox"))
        {
            interactionBoxesDoor.color = defaultColor;

        }
    }

    private void PlayerInteraction()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            inInteraction = true;

        }
        else
        {
            inInteraction = false;
        }

    }

    private void ResetDay()
    {
        gameManager.flowersAreDisponible = true;
        gameManager.dayOver = true;
        bucketFilled.SetActive(false);
        bucketLiquid.SetActive(false);
        gameManager.bucketIsDisponible = false;
        gameManager.bucketWasFilled = false;
        gameManager.flowersWereWatered = false;
        gameManager.wateringCanWasCaught = false;
        gameManager.wateringCanWasFilled = false;
        
    }



   
}
  