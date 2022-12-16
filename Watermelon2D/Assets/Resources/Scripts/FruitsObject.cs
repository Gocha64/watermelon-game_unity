using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsObject : MonoBehaviour
{

    public int _level = 0;
    Renderer circleColor;
    int goalLevel = 2;

    /*
    public enum CircleColor
    {
        white,
        yellow,
        orange,
        red,
        cyan,
        blue,
        purple,
        violet,
    }
    */

    Dictionary<int, Color> CircleColorDic = new Dictionary<int, Color>()
        {
            { 0, Color.white },
            { 1, Color.yellow },
            { 2, Color.red },
            { 3, Color.cyan },
            { 4, Color.blue },
            { 5, new Color(128, 0, 128) },
            { 6, new Color(143,0,255) },
        };


    // Start is called before the first frame update
    void Awake()
    {
        circleColor = gameObject.GetComponent<Renderer>();
        //_level = 0;
        //StartCoroutine("Scale");
    }

    private void OnDisable()
    {
        _level = 0;
        gameObject.GetComponent<Rigidbody2D>().mass = 1;
        transform.position = Vector3.zero;
        transform.localScale = Vector3.one;

        if (circleColor.material.color != null)
            circleColor.material.color = Color.white;
    }



    private void OnCollisionStay2D(Collision2D collision)
    {

        GameObject go = collision.collider.gameObject;

        if (go.CompareTag("Fruit") && _level == go.GetComponent<FruitsObject>()._level)
        {
            ObjectPool.ReturnObject(go.GetComponent<FruitsObject>());
            Upgrade();
        }
    }

    //다음 단계로 레벨업
    private void Upgrade()
    {
        _level += 1;
        gameObject.GetComponent<Rigidbody2D>().mass = _level*_level+1;
        StartCoroutine("Scale");
        if (_level < 7 && _level >= 0)
            circleColor.material.color = CircleColorDic[_level];
        else
            circleColor.material.color = Color.black;
        CheckIsEnd();
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

    void CheckIsEnd()
    {
        if (_level == goalLevel)
        {
            GameObject successSensor = GameObject.Find("Success Sensor");

            successSensor.GetComponent<SuccessSensor>().gameWin = true;
        } 
    }


}
