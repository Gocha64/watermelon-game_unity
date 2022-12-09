using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsObject : MonoBehaviour
{

    public float _level = 0;


    // Start is called before the first frame update
    void Start()
    {
        //_level = 0;
        //StartCoroutine("Scale");
    }

    private void OnDisable()
    {
        _level = 0;
        gameObject.GetComponent<Rigidbody2D>().mass = 1;
        transform.position = Vector3.zero;
        transform.localScale = Vector3.one;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        GameObject go = collision.collider.gameObject;

        if (go.CompareTag("Fruit") && _level == go.GetComponent<FruitsObject>()._level)
        {
            ObjectPool.ReturnObject(go.GetComponent<FruitsObject>());
            Upgrage();
        }
    }

    //다음 단계로 레벨업
    private void Upgrage()
    {
        _level += 1;
        gameObject.GetComponent<Rigidbody2D>().mass = _level*_level+1; 
        StartCoroutine("Scale");
    }

    //레벨에 따른 크기 변화
    IEnumerator Scale()
    {
        Debug.Log("start levelup");
        while(transform.localScale.x < Mathf.Pow(1.4f ,_level))
        {
            transform.localScale = transform.localScale * 1.1f;
            yield return new WaitForSeconds(.1f);
        }
    }


}
