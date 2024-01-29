using UnityEngine;

public class NarratorController : MonoBehaviour
{
    public AudioManager audioManager;  // Reference to the AudioManager script

    void Start()
    {
        // Example: Play a specific narration when the game starts
        audioManager.PlayNarration(audioManager.narrationClips[0]);
    }

    void Update()
    {
        // Example: Play another narration based on certain conditions
        //if (yourConditionMet)
        {
            //audioManager.PlayNarration(yourConditionClip);
        }
    }
    public void FindFinish()
    {
        // Example: Play a narration when the player finds the finish point
        audioManager.PlayNarration(audioManager.narrationClips[1]);
    }
    public void FindBlue()
    {
        // Example: Play a narration when the player finds the blue collectible
        audioManager.PlayNarration(audioManager.narrationClips[2]);
    }
    public void TryAgain()
    {
        // Example: Play a narration when the player dies
        audioManager.PlayNarration(audioManager.narrationClips[3]);
    }
    public void Congratz()
    {
        // Example: Play a narration when the player dies
        audioManager.PlayNarration(audioManager.narrationClips[4]);
    }
    public void JustKidding()
    {
        // Example: Play a narration when the player dies
        audioManager.PlayNarration(audioManager.narrationClips[5]);
    }
}
