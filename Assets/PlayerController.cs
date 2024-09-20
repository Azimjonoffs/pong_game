using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float boundary = 4.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector2.up * verticalInput * speed * Time.deltaTime);

        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -boundary, boundary);
        transform.position = pos;
    }
}
