using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    Transform _cameraTransform;
    Button startButton;
    Button exitButton;
    private void Awake()
    {
        _cameraTransform = GetComponent<Transform>();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitGame()
    {
        
        Application.Quit();
    }
}
