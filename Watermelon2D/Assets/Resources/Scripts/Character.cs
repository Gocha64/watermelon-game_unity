using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    float _speed = 5.0f;
    int _HP = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveSide();
    }

    void MoveSide()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        if (collision.collider.gameObject.CompareTag("Arrows"))
        {
            _HP -= 1;
            Debug.Log($"player damaged, HP: {_HP}");

            if (_HP <= 0)
                Destroy(gameObject);
            //Destroy(collision.collider.gameObject);
        }

        //Destroy(this);
    }
}
