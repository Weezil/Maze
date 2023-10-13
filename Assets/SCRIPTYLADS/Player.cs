using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public int Lives;
    public float Boost;
    public BoxCollider2D BoxTrigger;
    public int Points;
    // Start is called before the first frame update
    void Start()
    {
        Boost = 1;
        Speed = 5;
        Lives = 3;
        Points = 0;

        BoxTrigger = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        BoxTrigger.isTrigger = true;
        BoxTrigger.autoTiling = true;
        
    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        Points += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Boost > 0)
        {
            Speed = Boost + 2;
        }
        else 
        {
            Speed = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + Speed * Time.deltaTime * -1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + Speed * Time.deltaTime, transform.position.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x + Speed * Time.deltaTime * -1, transform.position.y);
        }
        
        if (Lives == 0)
        {
            Debug.Log("haha stinky loser");
            Application.Quit();
            //Quit wont work in the editor, but its still a nice touch :p
        }


    }
}
