using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsObject : MonoBehaviour
{

    float _level = 1;


    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

    }






    IEnumerator Scale()
    {
        while(transform.localScale.x > Mathf.Pow(1.4f ,_level))
        {
            transform.localScale = transform.localScale * 1.1f;
            yield return new WaitForSeconds(.1f);
        }
    }

    private void DestroyFruit()
    {
        ObjectPool.ReturnObject(this);
    }

}
