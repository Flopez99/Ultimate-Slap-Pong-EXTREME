using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Goal_P1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        Manager.Instance.player1LoseLife();
        Guys.Instance.Player2Hit();
        P2ScoreFX.Instance.Player2Score();
        Debug.Log("p1goal");
    }
}



