using UnityEngine;

public class P2ScoreFX : MonoBehaviour
{
    Animator p2scoreAnim;
    public P2ScoreFX score;
    public static P2ScoreFX Instance = null;
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
        p2scoreAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Player2Score()
    {
        p2scoreAnim.SetTrigger("p2score");
    }

}