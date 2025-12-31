using UnityEngine;
using UnityEngine.InputSystem;

public class P2READY : MonoBehaviour
{
    Animator p2ReadyAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p2ReadyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.rightShiftKey.isPressed)
        {
            p2ReadyAnim.SetBool("p2Ready", true);
        }
    }
}
