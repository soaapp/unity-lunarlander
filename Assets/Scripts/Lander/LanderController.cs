using UnityEngine;

public class LanderController : MonoBehaviour
{
    public float thrustPower = 10f;
    public float rotationSpeed = 100f;

    private Rigidbody2D rb;
    private Vector2 lastVelocity;

    // Explosion
    public GameObject explosionPrefab; // Drag in your prefab from the editor


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        lastVelocity = rb.linearVelocity;
        // Rotate left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        // Rotate right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        // Apply thrust
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Up Arrow Pressed");
            rb.AddForce(transform.up * thrustPower, ForceMode2D.Force);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LandingZone"))
        {
            float verticalSpeed = Mathf.Abs(lastVelocity.y);
            float horizontalSpeed = Mathf.Abs(lastVelocity.x);
    
            Debug.Log($"Landing check: VSpeed={verticalSpeed}, HSpeed={horizontalSpeed}");

            if (verticalSpeed < 2f && horizontalSpeed < 2f)
            {
                Debug.Log("Successful Landing!");
            }
            else
            {
                Debug.Log("CRASH! Speed too high!");
                Explode();
            }
        }
        else
        {
            Debug.Log("Crashed into terrain!");
        }
    }

    void Explode()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject); // Remove the lander
    }


}
