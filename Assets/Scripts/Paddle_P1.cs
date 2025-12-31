using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle_P1 : MonoBehaviour
{
    [SerializeField] private float paddle01Speed = 1.0f;
    [SerializeField] private float paddle01X = 0f;
    private Vector2 paddle01Pos;
    private Rigidbody2D p01rb;

    void Start()
    {
        paddle01Pos = new Vector2(paddle01X, 0f);
        transform.position = paddle01Pos;
        p01rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float movementP1 = Input.GetAxisRaw("Player1") * paddle01Speed;
        float pos01Y = transform.position.y + movementP1 * Time.deltaTime;
        paddle01Pos = new Vector2(paddle01X, Mathf.Clamp(pos01Y, -3.7f, 3.2f));
        transform.position = paddle01Pos;
    }

    //maybe add momentum to input but not necessary
}
