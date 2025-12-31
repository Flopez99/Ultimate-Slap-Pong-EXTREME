using UnityEngine;

public class goUI : MonoBehaviour
{
    Animator uiAnim;
    public static goUI Instance = null;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        uiAnim = GetComponent<Animator>(); 
    }

    public void Countdown()
    {
        uiAnim.SetTrigger("321");
        return;
    }

    public void FastCountdown()
    {
        uiAnim.SetTrigger("GO");
        return;
    }

}
