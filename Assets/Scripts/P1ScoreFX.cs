using UnityEngine;

public class P1ScoreFX : MonoBehaviour
{
    Animator scoreAnim;
    public P1ScoreFX score;
    public static P1ScoreFX Instance = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        scoreAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Player1Score()
    {
        scoreAnim.SetTrigger("p1score");
    }
}
