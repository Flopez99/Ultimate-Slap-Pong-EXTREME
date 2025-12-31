using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("INITIATE", 18f);
    }

    public void INITIATE()
    {
        SceneManager.LoadScene(2);
    }
}
