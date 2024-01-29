using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private static int deathCount;
    public LevelManager levelManager;
    public GameObject finishPoint;
    public GameObject bombPrefab;
    public Transform bombSpawnPoint;
    public float bombForce = 10f;
    public NarratorController narratorController;
    public GameObject buttons;
    public TMP_Text chicksLeft;

    [SerializeField] private bool isCollected = false;

    private bool bombKeyIsPressed = false;
    private float lastBombDropTime;
    private float bombDelay = 1.0f;
    private void Start() {
        finishPoint = GameObject.FindGameObjectWithTag("Finish");
        narratorController = GetComponent<NarratorController>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        buttons = GameObject.Find("Buttons");
        buttons.SetActive(false);
        CheckRemainingCollectibles();
    }
    private void Update() {
        HandleInput();
        
    }
    
    private void HandleInput()
    {
        // Check for 'E' key press
        if (Input.GetKeyDown(KeyCode.E) && CanDropBomb())
        {
            DropBomb();
            lastBombDropTime = Time.time;
        }

        // Your existing input handling code...
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }
    private bool CanDropBomb()
    {
        return (Time.time - lastBombDropTime) >= bombDelay;
    }

    void DropBomb()
    {
        // Instantiate a bomb at the spawn point
        GameObject bomb = Instantiate(bombPrefab, bombSpawnPoint.position, Quaternion.identity);

        // Apply force to the bomb
        Rigidbody bombRb = bomb.GetComponent<Rigidbody>();
        if (bombRb != null)
        {
            bombRb.AddForce(transform.forward * bombForce, ForceMode.Impulse);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            narratorController.TryAgain();
            Invoke(nameof(RemoveRB), 0.1f);
            Invoke(nameof(RestartLevel), 1.5f);
            Invoke(nameof(Die), 0.5f);
        }
        else if (other.CompareTag("Collectable"))
        {
            Collect(other.gameObject);
        }
        else if (other.CompareTag("Finish"))
        {
            if (isCollected)
            {
                // Implement level completion logic here
                Debug.Log("Level Completed!");
                buttons.SetActive(true);
                narratorController.FindBlue();
                other.GetComponent<BoxCollider>().enabled = false;
            }
            else
            {
                Debug.Log("Collect all the collectibles first!");
            }
        }
        else if (other.CompareTag("NextLevel"))
        {
            narratorController.Congratz();
            Invoke(nameof(RemoveRB), 0.1f);
            Invoke(nameof(NextLevel), 1.5f);
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
        deathCount = 0;
        // Implement level completion logic here
        Debug.Log("Next Level Loaded!");
        levelManager.LoadNextLevel();
    }
    void RestartLevel()
    {
        deathCount++;
        Debug.Log("Death Count: " + deathCount);
        Debug.Log("Level Index: " + levelManager.GetLevelIndex());
        if ((deathCount == 5) && (levelManager.GetLevelIndex() == 3))
        {
            NextLevel();
            return;
        }
        // Implement level restart logic here
        Debug.Log("Level Restarted!");
        levelManager.RestartLevel();
    }
    void Collect(GameObject collectible)
    {
        // Implement collectible collection logic here
        Destroy(collectible);

        // Replace "YourTag" with the actual tag you want to search for
        Invoke("CheckRemainingCollectibles", 0.1f);
    }
    void CheckRemainingCollectibles()
    {
    GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Collectable");
    Debug.Log("Number of objects with tag: " + objectsWithTag.Length);
    if (chicksLeft != null)
    {
        chicksLeft.text = "Chicks Left: " + objectsWithTag.Length;
    }
    

    // Check if the array is empty
    if (objectsWithTag.Length == 0)
    {
        // Activate the finish point
        finishPoint.GetComponent<FinishPoint>().ActivateFinishPoint();
        isCollected = true;
        narratorController.FindFinish();
    }
    }
    void RemoveRB()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Destroy(rb);
        }   
    }
    void Die()
    {
        // Implement player death logic here
        Debug.Log("Player Died!");
        gameObject.SetActive(false);
    }

    public bool IsCollected()
    {
        return isCollected;
    }
}
