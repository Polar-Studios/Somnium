using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Interactables : MonoBehaviour
{
    public enum InteractionType { NONE, PickUp }
    public InteractionType type;

    [Header("Dialogue")]
    public string item_info;

    /*
    public Sprite npcIcon;
    public string dialogueText;
    */

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 7;
    }
    public void Interact()
    {
        switch (type)
        {
            //case InteractionType.NPC:
                //FindObjectOfType<Interaction>().talktoNPC(this);;
                //break;

            case InteractionType.PickUp:
                FindObjectOfType<InventoryManager>().PickUp(gameObject);
                gameObject.SetActive(false);
                Debug.Log("PickUP");
                break;

            default:
                Debug.Log("NULL ITEM");
                break;
        }
    }
}
