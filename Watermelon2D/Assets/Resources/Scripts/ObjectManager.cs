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


    //지정된 지점에 과일을 생성함
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

                //지정된 범위 내에서만 생성 가능
                if (mousePos.x > rightSpawnPos)
                    mousePos.x = rightSpawnPos;

                if (mousePos.x < leftSpawnPos)
                    mousePos.x = leftSpawnPos;
                PlaceFruit(mousePos);
                // Mouse Down - 오브젝트 x값을 마우스 x값으로
            }
            else if (Input.GetMouseButton(0) && curFruit != null)
            {
                ObjectMove();
                // Mouse Move - 오브젝트 x값을 마우스 x값으로
            }
            else if (Input.GetMouseButtonUp(0) && curFruit != null)
            {
                curFruit.GetComponent<Rigidbody2D>().gravityScale = GRAVITY_SCALE;
                curFruit = null;
                StartCoroutine("SpawnTime");
                // Mouse Up - 오브젝트 떨어짐
            }
        }
        

    }

    //과일 생성 쿨타임
    IEnumerator SpawnTime()
    {
        spawnable = false;
        Debug.Log($"spawnable: {spawnable}");
        yield return new WaitForSeconds(spawnCooldownTime);
        spawnable = true;
        Debug.Log($"spawnable: {spawnable}");
    }

    //과일을 떨어뜨리기 전에 이동 처리
    private void ObjectMove()
    {
        // Screen 좌표계인 mousePosition을 World 좌표계로 바꾼다
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 과일은 x로만 움직여야 하기 때문에 y는 고정
        mousePos.y = ySpawnPos;
        mousePos.z = 0;

        // 지정된 범위 내에서만 이동가능
        if (mousePos.x > rightSpawnPos)
            mousePos.x = rightSpawnPos;

        if (mousePos.x < leftSpawnPos)
            mousePos.x = leftSpawnPos;
        //Debug.Log(mousePos);

        curFruit.transform.position = mousePos;
    }

    //현재 진행 상황에 따라서 다음에 생성될 과일의 레벨을 지정함
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
