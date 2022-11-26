using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : MonoBehaviour
{
    public float Amplitude = 1.0f;
    public float Frequency = 1.0f;

    private Vector3 origin;
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        //  rigidbody2d = GetComponent<Rigidbody2D>();
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // horizontal = Input.GetAxis("Horizontal");
        // vertical = Input.GetAxis("Vertical");
        offset = Mathf.Sin(Time.time * Frequency * 4.0f) * Amplitude;
        transform.position = origin + Vector3.right * offset;
    }

    void FixedUpdate()
    {
      //  Vector2 position = rigidbody2d.position;
      //  position.x = position.x + 3.0f * horizontal ;
      //  position.y = position.y + 3.0f * vertical ;

      //  rigidbody2d.MovePosition(position);
    }

}
