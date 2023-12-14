using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isLocalPlayer = false;
    
    [SerializeField] private float speed = 10;
    private CharacterController cc;

    private void Start()
    {
        cc = GetComponentInChildren<CharacterController>();
    }

    private void Update()
    {
        if(!isLocalPlayer) return;
        
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movement *= Time.deltaTime * speed;

        cc.Move(movement);
    }
}