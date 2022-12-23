using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{

    FruitsObject curFruit;
    private static readonly float GRAVITY_SCALE = 1.5f;
    private float rightSpawnPos = 4.9f;
    private float leftSpawnPos = -7.2f;
    private float ySpawnPos = 4.3f;

    private float spawnCooldownTime = 1.5f;
    private bool spawnable = true;

    public int maxLevel = 0;
    public int nextSpawnLevel = 0;


    // Start is called before the first frame update
    void Start()
    {
        //PlaceFruit(new Vector2(-2,0));
    }

    void PlaceFruit(Vector3 FruitPos)
    {
        var Fruit = ObjectPool.GetObejct();
        SetNextLevel();
        Fruit.SetFruitLevel(nextSpawnLevel);
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
            else if (Input.GetMouseButton(0) && curFruit != null)
            {
                ObjectMove();
                // Mouse Move - ������Ʈ x���� ���콺 x������
            }
            else if (Input.GetMouseButtonUp(0) && curFruit != null)
            {
                curFruit.GetComponent<Rigidbody2D>().gravityScale = GRAVITY_SCALE;
                curFruit = null;
                StartCoroutine("SpawnTime");
                // Mouse Up - ������Ʈ ������
            }
        }
        

    }

    IEnumerator SpawnTime()
    {
        spawnable = false;
        Debug.Log($"spawnable: {spawnable}");
        yield return new WaitForSeconds(spawnCooldownTime);
        spawnable = true;
        Debug.Log($"spawnable: {spawnable}");
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

    void SetNextLevel()
    {
        if (maxLevel == 0)
            nextSpawnLevel = 0;
        else if (maxLevel == 1)
            nextSpawnLevel = Random.Range(0, 2);
        else
            nextSpawnLevel = Random.Range(0, 3);

        Debug.Log($"next spawnLevel: {nextSpawnLevel}");

    }






}
