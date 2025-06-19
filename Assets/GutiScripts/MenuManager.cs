using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    Transform _cameraTransform;
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    private void Awake()
    {
        _cameraTransform = GetComponent<Transform>();
        RotateRigth(startButton.transform);
        RotateRigth(exitButton.transform);
    }
    private void RotateRigth(Transform position)
    {
        position.DORotate(new Vector3(0, 0, -2), 1).OnComplete(() =>
        {
            RotateLeft(position);
        }
        );
    }
    private void RotateLeft(Transform position)
    {
        position.DORotate(new Vector3(0, 0, 2), 1).OnComplete(() =>
        {
            RotateRigth(position);
        }
        );
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitGame()
    {
        _cameraTransform.DOScale(Vector3.zero, 1).OnComplete(()=>   
        {
            Application.Quit();
        }
        );
    }
}
