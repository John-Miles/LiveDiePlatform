using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverUI;
    public Vector3 platformSpawnPos;
    public GameObject platformPrefab;
    public Transform cameraFollow;
    public int lives = 3;
    public Transform respawnPoint;
    public GameObject playerPrefab;

    public Text livesText;
    
    // Start is called before the first frame update
    private void Start()
    {
        gameOverUI.SetActive(false);
    }

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //restart the game
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(0);
            MusicScript.StopMusic();
        }
        
        
        //check if the player presses the spawn button
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(platformPrefab, platformSpawnPos, Quaternion.identity);
            Debug.Log("Spawning Platform!");
        }
    }

    public void SpawnPlatform()
    {
        Instantiate(platformPrefab, platformSpawnPos, Quaternion.identity);
        Debug.Log("Spawning Platform!");
    }
    
    public void RespawnPlayer()
    {
       lives = lives - 1;
        if (lives >= 0)
        {
            Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity); 
        }
        else
        {
            GameOver();
        }

        livesText.text = ("Lives x " + lives);

    }

    void GameOver()
    {
        Time.timeScale = 0;
        livesText.text = "";
        gameOverUI.SetActive(true);
        Debug.Log("Game Over!");
    }

    public void BackToMenu()
    {
    
        
        MusicScript.StopMusic();
        SceneManager.LoadScene(0);


    }

    
    
    
}
