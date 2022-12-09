using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{

    FruitsObject curFruit;
    private static readonly float GRAVITY_SCALE = 1.5f;



    // Start is called before the first frame update
    void Start()
    {
        //PlaceFruit(new Vector2(-2,0));
    }

    void PlaceFruit(Vector3 FruitPos)
    {
        var Fruit = ObjectPool.GetObejct();
        Fruit.transform.position = FruitPos;
        curFruit = Fruit;

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            PlaceFruit(mousePos);
            // Mouse Down - ������Ʈ x���� ���콺 x������
        }
        else if (Input.GetMouseButton(0))
        {
            ObjectMove();
            // Mouse Move - ������Ʈ x���� ���콺 x������
        }
        else if (Input.GetMouseButtonUp(0))
        {
            curFruit.GetComponent<Rigidbody2D>().gravityScale = GRAVITY_SCALE;
            // Mouse Up - ������Ʈ ������
        }

    }

    private void ObjectMove()
    {
        // Screen ��ǥ���� mousePosition�� World ��ǥ��� �ٲ۴�
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ������Ʈ�� x�θ� �������� �ϱ� ������ y�� ����
        mousePos.y = curFruit.transform.position.y;
        mousePos.z = 0;

        Debug.Log(mousePos);

        curFruit.transform.position = mousePos;
    }






}
