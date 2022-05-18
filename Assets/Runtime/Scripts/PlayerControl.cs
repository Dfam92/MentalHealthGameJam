using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private SpriteRenderer interactionBoxesGarden;
    [SerializeField] private SpriteRenderer interactionBoxesDoor;
    [SerializeField] private SpriteRenderer interactionBoxesWell;
    [SerializeField] private SpriteRenderer interactionBoxesFriendDoor;
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
    [SerializeField] GameObject playerFriend;

    [SerializeField] GameObject roseToCatch;
    [SerializeField] GameObject daisyToCatch;

    [SerializeField] Animator playerAnim;

    private int rotationWellCount;
    private float defaultSpeed;
    //[SerializeField] CopyParentColor parentColor;
    private bool inInteraction;
    private Color defaultColor;
    private Quaternion defaultPos;

    //Todo
    //parentColor.ShareParentColor() call when the color mode is disabled;

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = interactionBoxesGarden.color;
        defaultPos = transform.rotation;
        defaultSpeed = playerSpeed;

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
            playerAnim.SetBool("PlayerWalk", true);
            if(horizontalInput < 0 )
            {
                var invertPos = new Quaternion(transform.rotation.x, -180, transform.rotation.z,transform.rotation.w);
                transform.rotation = invertPos;
            }
            else if(horizontalInput > 0)
            {
                transform.rotation = defaultPos;
            }
            else
            {
                playerAnim.SetBool("PlayerWalk", false);
            }
          
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerSpeed = runSpeed;
                playerAnim.SetBool("PlayerRun", true);
            }
            else
            {
                playerAnim.SetBool("PlayerRun", false);
                playerSpeed = defaultSpeed;
            }
            
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
            }

            if (inInteraction && gameManager.flowersAreDisponible && gameManager.inFInalDay)
            {
                roseToCatch.SetActive(true);
                daisyToCatch.SetActive(true);
                Rose3.SetActive(false);
                Daisy3.SetActive(false);
            }
        }
        if (collision.CompareTag("WateringCan"))
        {
            PlayerInteraction();
            if (inInteraction == true && gameManager.bucketIsDisponible && !gameManager.flowersWereWatered && !gameManager.inFInalDay)
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
            if (inInteraction == true && gameManager.wateringCanWasCaught && gameManager.wateringCanWasFilled && gameManager.bucketWasFilled && !gameManager.flowersWereWatered)
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
            if (inInteraction == true && !gameManager.inDayOne && !gameManager.bucketIsDisponible && !gameManager.flowersAreDisponible && !gameManager.inFInalDay)
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
            if (inInteraction == true && gameManager.flowersWereWatered )
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
        if (collision.CompareTag("FriendDoor"))
        {
            float alphaBoxFadeIn = interactionBoxesFriendDoor.color.a + Mathf.Clamp(1, 0, fadeSpeed);
            interactionBoxesFriendDoor.color = new Color(interactionBoxesFriendDoor.color.r, interactionBoxesFriendDoor.color.g, interactionBoxesFriendDoor.color.b, alphaBoxFadeIn);
            PlayerInteraction();

            if(inInteraction && gameManager.inFInalDay && !gameManager.flowersAreDisponible)
            {
                playerFriend.SetActive(true);
                Debug.Log("Fim de Jogo");
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
        if (collision.CompareTag("FriendDoor"))
        {
            interactionBoxesFriendDoor.color = defaultColor;
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
        gameManager.countDays++;
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
  