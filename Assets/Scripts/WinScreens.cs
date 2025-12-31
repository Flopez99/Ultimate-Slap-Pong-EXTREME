using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreens : MonoBehaviour
{

    void Start()
    {
            Invoke("RELOAD", 9f);
    }

    public void RELOAD()
    {
        SceneManager.LoadScene(0);
    }
}
