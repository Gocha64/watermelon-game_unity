using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ArrowManager : MonoBehaviour
{

    [SerializeField]
    GameObject arrow;

    


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DropArrow");
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    IEnumerator DropArrow()
    {
        while (true)
        {
            float xPos = Random.Range(-8.48f, 8.38f);
            Vector2 pos = new Vector2(xPos, 4);
            Instantiate(arrow);

            arrow.transform.position = pos;

            arrow.GetComponent<Rigidbody2D>().gravityScale = Random.Range(1.0f, 3.0f);
            yield return new WaitForSeconds(0.5f);
        }

        
    }
}
