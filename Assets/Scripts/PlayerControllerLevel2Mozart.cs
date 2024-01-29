using UnityEngine;

public class PlayerControllerLevel2Mozart : MonoBehaviour
{
    public LevelManager levelManager;
    public GameObject finishPoint;
    public GameObject bombPrefab;
    public Transform bombSpawnPoint;
    public float bombForce = 10f;
    public NarratorController narratorController;
    public GameObject buttons;

    private void Start() {
        finishPoint = GameObject.FindGameObjectWithTag("Finish");
        narratorController = GetComponent<NarratorController>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        buttons = GameObject.Find("Buttons");
        buttons.SetActive(true);
        Invoke(nameof(DestroyWall), 18f);
    }
    
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NextLevel"))
        {
            narratorController.JustKidding();
            Invoke(nameof(RemoveRB), 0.1f);
            Invoke(nameof(NextLevel), 5f);
        }
        else if (other.CompareTag("RestartLevel"))
        {
            narratorController.TryAgain();
            Invoke(nameof(RemoveRB), 0.1f);
            Invoke(nameof(RestartLevel), 1.5f);
        }
    }
    void NextLevel()
    {
        // Implement level completion logic here
        Debug.Log("Next Level Loaded!");
        levelManager.LoadNextLevel();
    }
    void RestartLevel()
    {
        // Implement level restart logic here
        Debug.Log("Level Restarted!");
        levelManager.RestartLevel();
    }
    void DestroyWall()
    {
        GameObject wall = GameObject.FindGameObjectWithTag("FakeWall");
        Destroy(wall);
    }
    
    void RemoveRB()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Destroy(rb);
        }   
    }
    
}
