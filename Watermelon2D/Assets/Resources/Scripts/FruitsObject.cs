using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsObject : MonoBehaviour
{

    public int _level = 0;
    Renderer circleColor;
    int goalLevel = 6;

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
        SetMaxLevel();
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


    //생성 될 때 설정된 레벨의 크기로 변환
    public void SetFruitLevel(int fruitLevel)
    {
        _level = fruitLevel;

        if (_level < 7 && _level >= 0)
            circleColor.material.color = CircleColorDic[fruitLevel];
        else
            circleColor.material.color = Color.black;


        gameObject.GetComponent<Rigidbody2D>().mass = _level * _level + 1;

        //크기 조정 방법 개선 필요
        switch (_level)
        {
            case 0:
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case 1:
                transform.localScale = new Vector3(1.46410012f, 1.46410012f, 1.46410012f);
                break;
            case 2:
                transform.localScale = new Vector3(2.14358902f, 2.14358902f, 2.14358902f);
                break;
            case 3:
                transform.localScale = new Vector3(2.85311723f, 2.85311723f, 2.85311723f);
                break;
            case 4:
                transform.localScale = new Vector3(4.17724895f, 4.17724895f, 4.17724895f);
                break;
            case 5:
                transform.localScale = new Vector3(5.55991888f, 5.55991888f, 5.55991888f);
                break;
            case 6:
                transform.localScale = new Vector3(8.14027786f, 8.14027786f, 8.14027786f);
                break;
            default:
                transform.localScale = Vector3.one;
                break;
        }

    }


    //최대 레벨을 가져옴
    //게임 승리 여부 판별
    void SetMaxLevel()
    {
        if (_level == goalLevel)
        {
            GameObject successSensor = GameObject.Find("Success Sensor");

            successSensor.GetComponent<SuccessSensor>().gameWin = true;
        }

        GameObject objectManager = GameObject.Find("@Object Manager");
        if (objectManager.GetComponent<ObjectManager>().maxLevel < _level)
        {
            objectManager.GetComponent<ObjectManager>().maxLevel = _level;
            Debug.Log($"maxLevel updated -> {objectManager.GetComponent<ObjectManager>().maxLevel}");
        }
            
    }


}
