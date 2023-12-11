using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Speed;
    public int Lives;
    public float Boost;
    public int Points;
    public Text scoreText;
    public Text lifeText;

    public List<GameObject> GemList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Boost = 1;
        Speed = 5;
        Lives = 3;
        Points = 0;

        scoreText.text = "Gem: " + AddPoint.totalScore;
        lifeText.text = "Lives: " + Remove.totalLives;

        //BoxTrigger = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        // BoxTrigger.isTrigger = true;
        //BoxTrigger.autoTiling = true;

    }
    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.GetComponent<BoxCollider2D>().name == "Gem")
        {
            GemList.Add(collider2D.gameObject);
            collider2D.gameObject.transform.position = new Vector2(-35, -5.5f);
           
            AddPoint.totalScore += 1;
            scoreText.text = "Gem: " + AddPoint.totalScore;
        }
        else if (collider2D.GetComponent<BoxCollider2D>().name == "Bomb")
        {
            Lives -= 1;
            Object.Destroy(collider2D.gameObject);

            Remove.totalLives -= 1;
            lifeText.text = "Lives: " + Remove.totalLives;
        }
        else if (collider2D.GetComponent<BoxCollider2D>().name == "Mud")
        {
            Boost = 0;
        }
        else if (collider2D.GetComponent<BoxCollider2D>().name == "Boost")
        {
            Boost = 2f;
        }
        else
        {
            Debug.Log("N Collide");
        }
        

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<BoxCollider2D>().name == "Mud")
        {
            Boost = 1;
            Speed = 5;
        }
        if (collision.GetComponent<BoxCollider2D>().name == "Boost")
        {
            Boost = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Points = GemList.Count;
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
