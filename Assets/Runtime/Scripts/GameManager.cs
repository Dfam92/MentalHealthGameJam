using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool inPlayMode = true;
    bool inColorMode;
    bool inDayOne;
    bool inDayTwo;
    bool inDayThree;
    bool inFInalDay;
    public bool InPlayMode { get => inPlayMode; set => inPlayMode = value; }
    public bool InColorMode { get => inColorMode; set => inColorMode = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
