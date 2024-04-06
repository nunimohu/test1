using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public float slideDistance = 2f; // Distance the door should slide
    public float slideSpeed = 2f; // Speed of door sliding
    private Vector3 initialPosition;
    private Vector3 targetPosition;

    private bool isOpen = false;

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition + transform.right * slideDistance; // Adjust direction based on your scene setup
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            OpenDoor();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isOpen)
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        isOpen = true;
        targetPosition = initialPosition + transform.right * slideDistance; // Adjust direction based on your scene setup
    }

    void CloseDoor()
    {
        isOpen = false;
        targetPosition = initialPosition;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, slideSpeed * Time.deltaTime);
    }
}
