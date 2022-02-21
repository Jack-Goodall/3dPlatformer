using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //private fields
    private Rigidbody rb;
    private bool JumpWasPressed;
    private float HorizontalInput;
    public int SuperJumpsRemaining;

    // Public fields
    public float PlayerSpeed;
    public Transform GroundCheck;
    public LayerMask PlayerMask;
    public int CoinCount;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpWasPressed = true;
        }

        HorizontalInput = Input.GetAxis("Horizontal");
    }



    // Update is called once per physics update
    void FixedUpdate()
    {
        rb.velocity = new Vector3(HorizontalInput * PlayerSpeed, rb.velocity.y, 0);

        if (Physics.OverlapSphere(GroundCheck.position, 0.1f, PlayerMask).Length == 0)
        {
            return;
        }

        if (JumpWasPressed)
        {
            float JumpForce = 7f;
            if (SuperJumpsRemaining > 0)
            {
                JumpForce *= 1.4f;
                SuperJumpsRemaining--;
            }
            rb.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
            JumpWasPressed = false;
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            CoinCount++;
        }

        if (other.gameObject.layer == 10)
        {
            Destroy(other.gameObject);
            SuperJumpsRemaining++;
        }

        if (other.gameObject.layer == 12)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }



    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score: " + Score);
    }
}

