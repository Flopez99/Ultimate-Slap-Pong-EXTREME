using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    [SerializeField] public float ballSpeed = 1.2f;
    Rigidbody2D ballrb2d;
    Animator ballAnim;
    public bool ballInPlay;
    public bool bothReady;
    public bool speedReached;
    float range1Min = -4f;
    float range1Max = -2f;
    float range2Min = 2f;
    float range2Max = 4f;

    void Awake()
    {
        ballrb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ballAnim = GetComponent<Animator>();
    }

    public void Shoot()
    {
        if (!ballInPlay)
        {
            ballInPlay = true;
            float randomRange1 = Random.Range(range1Min, range1Max);
            float randomRange2 = Random.Range(range2Min, range2Max);
            Vector2 ballVelocity = new Vector2(randomRange1, randomRange2);
            transform.parent = null;
            ballrb2d.AddForce(ballVelocity * ballSpeed, ForceMode2D.Impulse);
            Debug.Log("SHOOT");
        }
    }

    void FixedUpdate()
    {
        if (!ballInPlay && Manager.Instance.PlayersReady() && Manager.Instance.playerLives>5)
        {
            //goUI.Instance.Countdown();
            Invoke("Shoot", 3f);
            Manager.Instance.gameStart();
            //Debug.Log("321");
            
        } else if (!ballInPlay && Manager.Instance.PlayersReady())
        {
            //goUI.Instance.FastCountdown();
            Invoke("Shoot", 3f);
            Manager.Instance.roundStart();
            ballAnim.SetBool("speedreach", false);
            //Debug.Log("ready?go!");
        }   

            Vector2 currentVelocity = ballrb2d.linearVelocity;
        float speed = currentVelocity.magnitude;
        if (speed < 20f) { return; }
        else
        {
            if (!speedReached && speed > 12f)
            {
                Debug.Log("Crazy Hamburger");
                //change ball sprite to crazy version
                speedReached = true;
                ballAnim.SetBool("speedreach", true);
            }
        }

        // Shoot();
    //add animations
    //vfx for touching certain surfaces
    //ball exploding on entering a goal
    }
}