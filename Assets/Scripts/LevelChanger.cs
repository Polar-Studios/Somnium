using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    public void PlayGame()
    {
        FadeToLevel(1);
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        FadeToLevel(0);
    }

    public void QUITGAME()
    {
        Application.Quit();
    }

    public void FadeToLevel(int levelIndex)
    {
        // Set the animator parameter for the "FadeOut" animation
        animator.SetTrigger("FadeOut");

        // Load the specified scene after the "FadeOut" animation completes
        StartCoroutine(LoadSceneAfterFade(levelIndex));
    }

    private IEnumerator LoadSceneAfterFade(int levelIndex)
    {
        // Wait for the duration of "FadeOut" animation
        yield return new WaitForSeconds(1f);

        // Load the specified scene
        SceneManager.LoadSceneAsync(levelIndex);
    }
}
