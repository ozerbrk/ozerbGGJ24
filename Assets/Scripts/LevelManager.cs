using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int currentSceneIndex; // Declare here

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

    }

    public void LoadNextLevel()
    {

        // Load the next scene (assuming scenes are organized in build settings)
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void RestartLevel()
    {

        // Reload the current scene
        SceneManager.LoadScene(currentSceneIndex);
    }
    public int GetLevelIndex()
    {
        return currentSceneIndex;
    }
}
