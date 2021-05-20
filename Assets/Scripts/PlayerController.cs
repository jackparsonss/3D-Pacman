using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10;
    
    private Rigidbody _pacmanRb;
    private void Start()
    {
        _pacmanRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");

        Vector3 movement = transform.forward * verticalAxis + transform.right * horizontalAxis;
        _pacmanRb.AddForce(movementSpeed * Time.deltaTime * movement);
        //_pacmanRb.AddForce(movementSpeed * Time.deltaTime * verticalAxis * Vector3.forward);
    }
}
