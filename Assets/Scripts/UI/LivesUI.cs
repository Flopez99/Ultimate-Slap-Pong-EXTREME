using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    [Header("Assign in Inspector (size = 3)")]
    [SerializeField] private Image[] player1Hearts;
    [SerializeField] private Image[] player2Hearts;

    public void UpdateLives(int p1Lives, int p2Lives)
    {
        UpdateHearts(player1Hearts, p1Lives);
        UpdateHearts(player2Hearts, p2Lives);
    }

    private void UpdateHearts(Image[] hearts, int lives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < lives;
        }
    }
}