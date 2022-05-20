using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class PlayerDialogue : MonoBehaviour
{
    public NPCConversation firstConversation;
    

    public NPCConversation firstDayDialogue;
    public NPCConversation secondDayDialogue;
    public NPCConversation midSecondDayDialogue;
    public NPCConversation thirdDayDialogue;
    public NPCConversation finalDayDialogue;

    public NPCConversation finalConversation;

    public bool inFirstDayDialogue;
    public bool inSecondDayDialogue;
    public bool inMidSecondDayDialogue;
    public bool inThirdDayDialogue;
    public bool inFinalDayDialogue;

    public bool inFinalConversation;

    [SerializeField] GameObject conversationManager;
    // Start is called before the first frame update
    void Start()
    {
       ConversationManager.Instance.StartConversation(firstConversation);
       
    }

    private void Update()
    {
        ConversationStart();
    }

    public void ConversationStart()
    {
      
        if(inFirstDayDialogue)
        {
            conversationManager.SetActive(true);
            inFirstDayDialogue = false;
        }
        
        if( inSecondDayDialogue)
        {
            conversationManager.SetActive(true);
            inSecondDayDialogue = false;
        }
        
        if( inMidSecondDayDialogue)
        {
            conversationManager.SetActive(true);
            inMidSecondDayDialogue = false;
        }

        if( inThirdDayDialogue)
        {
            conversationManager.SetActive(true);
            inThirdDayDialogue = false;
        }

        if(inFinalDayDialogue)
        {
            conversationManager.SetActive(true);
            inFinalDayDialogue = false;
        }
        
        if(inFinalConversation)
        {
            conversationManager.SetActive(true);
            inFinalConversation = false;
        }
    }


}
