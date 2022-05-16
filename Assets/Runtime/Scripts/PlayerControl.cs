using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
    private Color defaultColor;

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
        if(gameManager.InPlayMode)
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            playerRb.AddForce(Vector2.right * horizontalInput * playerSpeed);
            backGround.transform.position = new Vector3(parallaxEffect, backGround.transform.position.y, backGround.transform.position.z);
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("GardenTerrain"))
        {
            float alphaBoxFadeIn = interactionBoxesGarden.color.a + Mathf.Clamp(1, 0, fadeSpeed);
            interactionBoxesGarden.color = new Color(interactionBoxesGarden.color.r, interactionBoxesGarden.color.g, interactionBoxesGarden.color.b, alphaBoxFadeIn);
            
        }
        if (collision.CompareTag("WellBox"))
        {
            float alphaBoxFadeIn = interactionBoxesWell.color.a + Mathf.Clamp(1, 0, fadeSpeed);
            interactionBoxesWell.color = new Color(interactionBoxesWell.color.r, interactionBoxesWell.color.g, interactionBoxesWell.color.b, alphaBoxFadeIn);

        }
        if (collision.CompareTag("DoorBox"))
        {
            float alphaBoxFadeIn = interactionBoxesDoor.color.a + Mathf.Clamp(1, 0, fadeSpeed);
            interactionBoxesDoor.color = new Color(interactionBoxesDoor.color.r, interactionBoxesDoor.color.g, interactionBoxesDoor.color.b, alphaBoxFadeIn);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("GardenTerrain"))
        {
            interactionBoxesGarden.color = defaultColor;
        }

        if(collision.CompareTag("WellBox"))
        {
            interactionBoxesWell.color = defaultColor;
        }

        if(collision.CompareTag("DoorBox"))
        {
            interactionBoxesDoor.color = defaultColor;
        }
    }
}
  