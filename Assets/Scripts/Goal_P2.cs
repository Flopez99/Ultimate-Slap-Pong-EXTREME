using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Goal_P2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        Manager.Instance.player2LoseLife();
        Guys.Instance.Player1Hit();
        P1ScoreFX.Instance.Player1Score();
        Debug.Log("p2goal");
    }
}



