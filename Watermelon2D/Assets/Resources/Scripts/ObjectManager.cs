using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{

    FruitsObject curFruit;
    private static readonly float GRAVITY_SCALE = 1.5f;
    private float rightSpawnPos = -0.4f;
    private float leftSpawnPos = -7.2f;
    private float ySpawnPos = 4.3f;

    private float spawnCooldownTime = 1.5f;
    private bool spawnable = true;


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
        if (spawnable)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.y = ySpawnPos;
                mousePos.z = 0;

                if (mousePos.x > rightSpawnPos)
                    mousePos.x = rightSpawnPos;

                if (mousePos.x < leftSpawnPos)
                    mousePos.x = leftSpawnPos;
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
                StartCoroutine("SpawnTime");
                // Mouse Up - ������Ʈ ������
            }
        }
        

    }

    IEnumerator SpawnTime()
    {
        spawnable = false;
        Debug.Log($"spawnalbe: {spawnable}");
        yield return new WaitForSeconds(spawnCooldownTime);
        spawnable = true;
        Debug.Log($"spawnalbe: {spawnable}");
    }

    private void ObjectMove()
    {
        // Screen ��ǥ���� mousePosition�� World ��ǥ��� �ٲ۴�
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ������Ʈ�� x�θ� �������� �ϱ� ������ y�� ����
        mousePos.y = ySpawnPos;
        mousePos.z = 0;

        if (mousePos.x > rightSpawnPos)
            mousePos.x = rightSpawnPos;

        if (mousePos.x < leftSpawnPos)
            mousePos.x = leftSpawnPos;
        //Debug.Log(mousePos);

        curFruit.transform.position = mousePos;
    }






}
