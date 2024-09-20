using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class player2Controller : MonoBehaviour
{
    public bool SinglePlayer = true;
    public float autoMoveSpeed = 10f;
    public float playerMoveSpeed = 10f;
    public Transform ball;
    public Toggle modeToggle;

    private Rigidbody2D rb;
    private Vector3 startPosition;
    public float boundary = 4.2f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;

        modeToggle.onValueChanged.AddListener(delegate {
            ToggleMode(modeToggle.isOn);
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (SinglePlayer)
        {
            AutoMovePaddle();
        }
        else{
            ManualMovePaddle();
        }
    }

    void ToggleMode(bool isMultiplayer)
    {
        SinglePlayer = !isMultiplayer;
    }

    void AutoMovePaddle()
    {
        if (ball.position.x > 0)
        {
            float missChance = Random.Range(0f, 1f);
            if (missChance < 0.2f)
            {
                return;
            }

        Vector2 targetPosition = new Vector2(transform.position.x, ball.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, autoMoveSpeed * Time.deltaTime);
        }
    }

    void ManualMovePaddle()
    {
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.Keypad8))
        {
            verticalInput = 1f;
        }
        else if (Input.GetKey(KeyCode.Keypad2))
        {
            verticalInput = -1f;
        }

        transform.Translate(Vector2.up * verticalInput * playerMoveSpeed * Time.deltaTime);

        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -boundary, boundary);
        transform.position = pos;
    }
}