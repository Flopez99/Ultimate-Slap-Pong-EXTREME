using UnityEngine;

public class CountdownUI : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        if (!animator) animator = GetComponent<Animator>();
        gameObject.SetActive(false); // hidden until needed
    }

    public void Play()
    {
        gameObject.SetActive(true);
        animator.Rebind();          // reset all animator state
        animator.Update(0f);        // apply the rebind immediately
        animator.Play("Countdown", 0, 0f);
    }


    // Called by an Animation Event at the last frame
    public void OnCountdownFinished()
    {
        Debug.Log("OnCountdownFinished event fired!");
        gameObject.SetActive(false);
        Manager.Instance.OnCountdownFinished();
    }
}
