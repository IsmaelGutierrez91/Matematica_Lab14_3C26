using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float Force;
    [SerializeField] private float ForceJump;
    [SerializeField] private Rigidbody RB;
    [SerializeField] private int Lifes = 10;
   
    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Lifes<= 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
    public void MovementHorizontal(InputAction.CallbackContext context)
    {
        float read = context.ReadValue<float>();
        RB.linearVelocity = new Vector3(Force * read, RB.linearVelocity.y, RB.linearVelocity.z);
        //RB.AddForce();
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Physics.gravity = Physics.gravity * -1;


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Lifes -= 1;
        }
        if (other.CompareTag("Die"))
        {
            Lifes -= Lifes;
        }
        if (other.CompareTag("win"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}

