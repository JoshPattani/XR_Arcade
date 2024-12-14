using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetGame()
    {
        // Option 1: Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // Option 2: Reset specific game elements (if not reloading the scene)
        // ResetTowers();
        // ResetSpawners();
        // ResetPlayer();
    }

    // Optional: Methods to reset specific game elements
    /*
    void ResetTowers()
    {
        // Find all towers and reset their health
        Tower[] towers = FindObjectsOfType<Tower>();
        foreach (Tower tower in towers)
        {
            tower.ResetTower();
        }
    }

    void ResetSpawners()
    {
        // Reset spawners if necessary
    }
    */
    // void ResetPlayer()
    // {
    //     // Reset player's position, score, etc.

    //     Player player = FindObjectOfType<Player>();
        
    // }
}
