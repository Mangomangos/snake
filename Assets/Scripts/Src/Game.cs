using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Food FoodPrefab;
    public SnakeController SnakePrefab;
    public SnakeController Snake;
    // Start is called before the first frame update
    void Start()
    {
        SpawnFood();
        Snake = Instantiate(SnakePrefab);
        Snake.OnNom += HandleOnNom;
    }

    private void HandleOnNom(Food obj)
    {
        Destroy(obj.gameObject);
        SpawnFood();
        Snake.Speed += 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnFood()
    {
        Food food = Instantiate(FoodPrefab);
        float yAxis = Random.Range(-4.5f, 4.5f);
        float xAxis = Random.Range(-4.5f, 4.5f);
        food.transform.position = new Vector3(xAxis, yAxis, 0);

    }
}
