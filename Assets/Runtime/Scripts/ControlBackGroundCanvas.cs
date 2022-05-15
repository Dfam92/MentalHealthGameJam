using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBackGroundCanvas : MonoBehaviour
{
    [SerializeField] float speed;
    public bool isOnFullView;
    [SerializeField] GameObject colorPicker;
    [SerializeField] GameObject colorSlideSaturation;
    [SerializeField] GameObject frame;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(330.1f, 17.6f, -482.3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOnFullView)
        {
            transform.position += new Vector3(-Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, -Input.GetAxis("Mouse ScrollWheel") * speed * 10 * Time.deltaTime);
            var backGroundPos = transform.position;
            if (backGroundPos.x >= 330.1f)
            {
                backGroundPos.x = 330.1f;
            }
            else if (backGroundPos.x <= -20.2f)
            {
                backGroundPos.x = -20.2f;
            }

            if(backGroundPos.z >= -482.3f)
            {
                backGroundPos.z = -482.3f;
            }
            else if(backGroundPos.z <= -600)
            {
                backGroundPos.z = -600;
            }

            transform.position = backGroundPos;
        }
       
       
    }

    public void FullView()
    {
        if(isOnFullView == false)
        {
            var fullViewPos = new Vector3(153.4f, 17.6f, -252.8f);
            transform.position = fullViewPos;
            isOnFullView = true;
            colorPicker.SetActive(false);
            colorSlideSaturation.SetActive(false);
            frame.SetActive(true);
        }
        else
        {
            isOnFullView = false;
            colorPicker.SetActive(true);
            colorSlideSaturation.SetActive(true);
            frame.SetActive(false);
        }
       
    }
}
