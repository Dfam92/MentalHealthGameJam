using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] private float playerSpeed;
    [SerializeField] private SpriteRenderer interactionBoxes;
    [SerializeField] private float fadeSpeed;
    private Color defaultColor;
    

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = interactionBoxes.color;
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
        var horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector2.right * horizontalInput * playerSpeed);

    }


    private void PlayerInteraction()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("GardenTerrain"))
        {
            float alphaBoxFadeIn = interactionBoxes.color.a + Mathf.Clamp(1, 0, fadeSpeed);
            interactionBoxes.color = new Color(interactionBoxes.color.r, interactionBoxes.color.g, interactionBoxes.color.b, alphaBoxFadeIn);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("GardenTerrain"))
        {
            interactionBoxes.color = defaultColor;
        }
    }
}
  