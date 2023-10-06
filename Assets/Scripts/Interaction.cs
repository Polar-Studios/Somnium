using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction: MonoBehaviour
{
    [Header("Detection Parameters")]
    public Transform detectionPoint;
    private const float detectionRadius = 0.2f;
    public LayerMask detectionLayer;
    public GameObject detectObject;
    public SpriteRenderer spriterenderer;

    /*[Header("Dialogue")]
    public GameObject dialogueWindow;
    public Image npcIcon;
    public Text dialogueText;
    public bool isDoingSomething;
    */

    void Update()
    {
        if (DetectObject())
        {
            if (InteractInput())
            {
                detectObject.GetComponent<Interactables>().Interact();
            }
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.G);
    }

    bool DetectObject()
    {

        Collider2D obj =  Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer)
            ;
        if(obj == null)
        {
            return false;
        }
        else
        {
            detectObject = obj.gameObject;
            return true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }

    /*public void talktoNPC(Interactables interactables)
    {
        if (isDoingSomething)
        {
            Debug.Log("NPC WINDOW CLOSED");
            dialogueWindow.SetActive(false);
            isDoingSomething = false;
        }
        else
        {
            Debug.Log("NPC WINDOW OPENED");
            npcIcon.sprite = interactables.GetComponent<SpriteRenderer>().sprite;
            dialogueText.text = interactables.dialogueText;
            dialogueWindow.SetActive(true);
            isDoingSomething = true;
        }
        
    }*/
}