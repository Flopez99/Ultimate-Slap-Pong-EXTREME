using UnityEngine;
using UnityEngine.InputSystem;

public class Car : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;

    void Update()
    {
        float move = 0;
        float turn = 0;

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            turn = 1;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            move = -1;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            turn = -1;
        }

        float moveAmount = move * moveSpeed * Time.deltaTime;
        float turnAmount = turn * turnSpeed * Time.deltaTime;

        transform.Translate(0,moveAmount,0);
        transform.Rotate(0, 0, turnAmount);
    }
}
