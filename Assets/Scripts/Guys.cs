using UnityEditor;
using UnityEngine;

public class Guys : MonoBehaviour
{
    Animator guyAnim;
    public Guys guys;
    public static Guys Instance = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

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
        guyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Player2Hit()
    {
            guyAnim.SetTrigger("robhit");
    }
    public void Player1Hit()
    {
        guyAnim.SetTrigger("monhit");
    }
}
