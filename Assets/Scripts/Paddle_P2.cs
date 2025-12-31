using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle_P2 : MonoBehaviour
{
    [SerializeField] private float paddle02Speed = 1.0f;
    [SerializeField] private float paddle02X = 0f;
    private Vector2 paddle02Pos;
    private Rigidbody2D p02rb;

    void Start()
    {
        paddle02Pos = new Vector2(paddle02X, 0f);
        transform.position = paddle02Pos;
        p02rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float movementP2 = Input.GetAxisRaw("Player2") * paddle02Speed;
        float pos02Y = transform.position.y + movementP2 * Time.deltaTime;
        paddle02Pos = new Vector2(paddle02X, Mathf.Clamp(pos02Y, -3.7f, 3.2f));
        transform.position = paddle02Pos;
    }

    //maybe add momentum to input but not necessary
}
