using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public System.Action<Food> OnNom;
    public float Speed = 1;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        transform.position += new Vector3(xAxis, yAxis, 0) * Speed * Time.deltaTime;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Nom nom " + collision.gameObject);
        Food food = collision.GetComponent<Food>();
        if (food)
        {
            OnNom?.Invoke(food);
        }
    }
}
