using System.Collections;
using System.ComponentModel;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager Instance = null;
    public bool bothReady;
    public Manager manager;
    public bool ballInPlay;

    public bool player1Ready;
    public bool player2Ready;

    private int player1Lives = 3;
    private int player2Lives = 3;
    public int playerLives;

    public CinemachineCamera cam;

    //public string [] hitAnimationTriggers;

    private bool countdownPlaying = false;


    [SerializeField] private LivesUI livesUI; //new
    [SerializeField] private CountdownUI countdownUI; //new

    [SerializeField] private GameObject player1ReadyText;
    [SerializeField] private GameObject player2ReadyText;
    private GameObject player1ReadyTextClone;
    private GameObject player2ReadyTextClone;
    private Vector2 player1ReadyLocation;
    private Vector2 player2ReadyLocation;
    Animator guyAnim;

    //[SerializeField] private GameObject titleText;

    [SerializeField] private GameObject tutorialText;
    [SerializeField] private GameObject ballPrefab;
    public GameObject ballClone;
    private Vector2 ballCloneLocation;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != null)
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {

        bothReady = false;
        player1Ready = false;
        player2Ready = false;


        tutorialText.SetActive(true);
        player1ReadyText.SetActive(true);
        player2ReadyText.SetActive(true);

        player1ReadyLocation = new Vector2(-6.3f, 2.4f);
        player2ReadyLocation = new Vector2(6.3f, 2.4f);
        ballCloneLocation = Vector2.zero;
        Setup();

        livesUI.UpdateLives(player1Lives, player2Lives);

        guyAnim = GetComponent<Animator>();
    }



    private void Setup()
    {
        ballClone = Instantiate(ballPrefab, ballCloneLocation, Quaternion.identity) as GameObject;
        ballInPlay = false;
        player1ReadyText.SetActive(true);
        player2ReadyText.SetActive(true);
        player1ReadyTextClone = Instantiate(player1ReadyText, player1ReadyLocation, Quaternion.identity) as GameObject;
        player2ReadyTextClone = Instantiate(player2ReadyText, player2ReadyLocation, Quaternion.identity) as GameObject;

    }

    private void SetUpBall()
    {
        ballClone = Instantiate(ballPrefab, ballCloneLocation, Quaternion.identity) as GameObject;
        //instantiate ready text
    }

    private void Update()
    {
        if (!ballInPlay && !player1Ready && Keyboard.current.leftShiftKey.isPressed)
        {
            player1Ready = true;
            Debug.Log("p1ready");
            player1ReadyText.SetActive(true);
        }

        if (!ballInPlay && !player2Ready && Keyboard.current.rightShiftKey.isPressed)
        {
            player2Ready = true;
            Debug.Log("p2ready");
            player2ReadyText.SetActive(true);
        }

        playerLives = player1Lives + player2Lives;
        gameStart();
        roundStart();
        QuitGame();
    }

    public void gameStart()
    {
        if (!countdownPlaying && player1Ready && player2Ready && playerLives > 5)
        {
            Debug.Log(countdownUI == null ? "countdownUI is NULL" : "countdownUI OK: " + countdownUI.name);

            bothReady = true;
     
            tutorialText.SetActive(false);
            countdownPlaying = true;

            countdownUI.Play(); //play 321 GO animation
            
            //Invoke("houseKeeping", 1.2f);

        }
    }

    public void roundStart()
    {
        if (!countdownPlaying && player1Ready && player2Ready && playerLives < 6)
        {
            bothReady = true;
            countdownPlaying = true;

            countdownUI.Play();
        }
    }


    public void OnCountdownFinished()
    {
        houseKeeping();
    }


    public bool PlayersReady()
    {
        if (player1Ready && player2Ready)
        {
           return true;
        }
        return false;
    }

    public void houseKeeping()
    {
        ballInPlay = true;
        player1Ready = false;
        player2Ready = false;
        player1ReadyText.SetActive(false);
        player2ReadyText.SetActive(false);
        Destroy(player1ReadyTextClone);
        //instantiate p1ReadyText destroy transition
        Destroy(player2ReadyTextClone);
        //instantiate p2ReadyText destroy transition
        bothReady = false;
        countdownPlaying = false;

    }

    public void player1LoseLife()
    {
        player1Lives--;
        livesUI.UpdateLives(player1Lives, player2Lives); //update lives
        Destroy(ballClone);
        CheckPlayer1Lose();
        Time.timeScale = 1f;
        //guyAnim.SetTrigger("robHit");//play player 1 hit animation
        Invoke("Setup", 2f); //remove this when text is set up
        //Invoke("SetupBall", 2f);
        Debug.Log("p1-1");
    }
    
    public void CheckPlayer1Lose()
    {
        if (player1Lives < 1)
        {
            Time.timeScale = 1f;
            Invoke("Player2Win", 3f);
        }
    }

    public void player2LoseLife()
    {
        player2Lives--;
        livesUI.UpdateLives(player1Lives, player2Lives); //update lives
        Destroy(ballClone);
        CheckPlayer2Lose();
        Time.timeScale = 1f;
        //characterAnim.SetTrigger ("p2Hit") play player 1 hit animation
        Invoke("Setup", 2f); //remove this when text is set up
        //Invoke("SetupBall", 2f);
        Debug.Log("p2-1");
    }

    public void CheckPlayer2Lose()
    {
        if (player2Lives < 1)
        {
            Time.timeScale = 1f;
            Invoke("Player1Win", 3f);
        }
    }

    public void Player1Win()
    {
        SceneManager.LoadScene(3);
    }

    public void Player2Win()
    {
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }


    //track lives, play animation on loss of life
    //ready up button, tutorial text disappear after ready
    //win screen cutscene play on one player empty lives
    //3,2,1 GO on ready up, initialize ball
    //Reset scene on goal score
    //reset game after win screen
    //visual tracker of lives, animation on losing life
    //transition cam to loss cutscene
}
