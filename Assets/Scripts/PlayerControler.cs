using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private float Force;
    [SerializeField] private float ForceJump;
    [SerializeField] private Rigidbody RB;
    [SerializeField] private bool CanJump;
    private void Start()
    {
        RB = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Physics.Raycast(transform.position,Vector3.down*2))
        {
            CanJump = true;
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
        if (!CanJump) return;
        RB.AddForce(new Vector3(0,ForceJump,0));
        CanJump = false;
    }
}

