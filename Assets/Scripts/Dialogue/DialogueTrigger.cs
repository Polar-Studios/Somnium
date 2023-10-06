using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("VisualCue")]
    [SerializeField] private GameObject visualCue;
    private bool playerinRange;

    [Header("INK JSON")]
    [SerializeField] private TextAsset inkJSON;

    private void Awake()
    {
        playerinRange = false;
        visualCue.SetActive(false);
    }
    private void Update()
    {
        if (playerinRange && !DialogueManager.GetIstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                DialogueManager.GetIstance().enterDialogueMode(inkJSON);
            }
        }
        else
        {
            visualCue.SetActive(false); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerinRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerinRange = false;
        }

    }
}
