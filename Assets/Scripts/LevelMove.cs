using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class LevelMove : MonoBehaviour
{
    public int sceneBuildIndex;
    public LevelChanger levelChanger; // Reference to the LevelChanger script

    private void Start()
    {
        // Find the LevelChanger script in the scene
        levelChanger = FindObjectOfType<LevelChanger>();
        if (levelChanger == null)
        {
            Debug.LogError("LevelChanger script not found in the scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Triggered");

        if (other.CompareTag("Player"))
        {
            // Access the Lua variable "Allowed" from the dialogue system
            bool isAllowed = DialogueLua.GetVariable("Allowed").asBool;

            if (isAllowed)
            {
                // Trigger fade-out animation and load the specified scene
                levelChanger.FadeToLevel(sceneBuildIndex);
            }
            else
            {
                // Handle the case where the player is not allowed to move to another scene
                // You might want to display a message or take other actions here
                Debug.Log("Player is not allowed to move to the next scene.");
            }
        }
    }
}