using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;

    public TextMeshProUGUI scoreText;       
    public TextMeshProUGUI timerText;       
    public TextMeshProUGUI finalScoreText;  
    public GameObject continueButton;       

    private float timeLimit = 30f;
    private bool isTimeUp = false;

    public GameObject laserPointer;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        UpdateScoreText();
        finalScoreText.enabled = false;
        continueButton.SetActive(false);

        // 最初はレーザーポインターを無効化
        if (laserPointer != null)
            laserPointer.SetActive(false);
    }

    private void Update()
    {
        if (isTimeUp) return;

        timeLimit -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeLimit / 60);
        int seconds = Mathf.FloorToInt(timeLimit % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";

        if (timeLimit <= 0)
        {
            isTimeUp = true;
            TimeUp();
        }
    }

    public void AddScore(int amount)
    {
        if (isTimeUp) return;

        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "" + score;
    }

    private void TimeUp()
    {
        timerText.text = "00:00";
        finalScoreText.text = "Final Score: " + score;
        finalScoreText.enabled = true;
        scoreText.enabled = false;
        continueButton.SetActive(true);

        //的のスポーンを停止
        FindObjectOfType<WoodSpawner>().StopSpawning();

        //ゲーム終了時にレーザーポインターを表示
        if (laserPointer != null)
            laserPointer.SetActive(true);
    }

    public void ReturnToStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
