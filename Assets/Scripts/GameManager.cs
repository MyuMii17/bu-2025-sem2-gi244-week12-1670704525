// notice ... List class requires System.Collections.Generic namespace
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    [Header("UI Elements")]
    // NOTE: TextMeshProUGUI requires "using TMPro"
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreValue;
    // NOTE: TextMeshProUGUI requires "using TMPro"
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;
    private Coroutine currentCoroutine;
    public Target target;

    private int score;
    private bool isGameActive = true;
    private float spawnRate = 1.0f;

    void Awake()
    {

    }

    void Start()
    {
        StartGame();
        score = 0;
        scoreText.text = "Score : " + score;
    }

    void StartGame()
    {
        StartCoroutine(SpawnTargets());
    }
    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            int index = Random.Range(0, targets.Count);
            var prefed = targets[index];
            Instantiate(prefed);
            // yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));
            yield return new WaitForSeconds(spawnRate);
        }
    }
    public void UpdateScore(int s)
    {
        score += s;
        scoreValue.text = s.ToString(); 
        scoreText.text = "Score : " + score;
    }
    public bool CheckDestroy()
    {
        return score != 0;
    }
}

