using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private int count;

    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();

            if (hasWon())
            {
                SetWinningStuff();
            }
            else
            {
                audioManager.PlayRandomPickupSound();
            }
        }
    }

    void SetWinningStuff() {
        SetWinText();
        audioManager.PlayWinSound();
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
    
    void SetWinText()
    {
        winTextObject.SetActive(true);
    }

    private bool hasWon() {
        return count >= 10;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }
}
