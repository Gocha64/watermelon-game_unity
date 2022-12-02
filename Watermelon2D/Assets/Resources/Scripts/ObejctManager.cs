using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObejctManager : MonoBehaviour
{

    GameObject nextFruit;
    string path = "Prefabs/Circle";


    // Start is called before the first frame update
    void Start()
    {
        PlaceFruit(new Vector2(-2,0));
        PlaceFruit(new Vector2(-1, 0));
    }

    void PlaceFruit(Vector2 FruitPos)
    {
        LoadNextFruit();
        Instantiate(nextFruit, FruitPos, Quaternion.identity);
        
    }

    void LoadNextFruit()
    {
        nextFruit = Resources.Load<GameObject>(path);
        if (nextFruit == null)
        {
            Debug.Log($"Failed to load prefab : {path}");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
