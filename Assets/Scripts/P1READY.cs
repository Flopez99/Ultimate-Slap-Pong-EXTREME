using UnityEngine;
using UnityEngine.InputSystem;

public class P1READY : MonoBehaviour
{
    Animator p1ReadyAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        p1ReadyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.leftShiftKey.isPressed)
        {
            p1ReadyAnim.SetBool("p1Ready", true);

        }
    }
}
