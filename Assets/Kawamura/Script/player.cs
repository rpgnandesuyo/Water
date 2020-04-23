using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private GameObject[] gameObjects = new GameObject[4];
    public int Life;
    public enum Stateform {
        normal, attack, ghillie, swim
    }
    Stateform stateform = Stateform.normal;
    [HideInInspector]
    public float attacktimer;
    [HideInInspector]
    public float ghillietimer;
    [HideInInspector]
    public float swimtimer;
    private Vector2 vector2;
    // Start is called before the first frame update
    void Start()
    {
        gameObjects[1].SetActive(false);
        gameObjects[2].SetActive(false);
        gameObjects[0].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))//ノーマル
        {
            stateform = Stateform.attack;
            gameObjects[0].SetActive(true);
            gameObjects[1].SetActive(false);
            gameObjects[2].SetActive(false);
            gameObjects[3].SetActive(false);
        }
        else if (Input.GetKey(KeyCode.X))
        {
            stateform = Stateform.ghillie;
            gameObjects[0].SetActive(false);
            gameObjects[1].SetActive(true);
            gameObjects[2].SetActive(false);
            gameObjects[3].SetActive(false);
        }
        else if (Input.GetKey(KeyCode.C))
        {
            stateform = Stateform.swim;
            gameObjects[0].SetActive(false);
            gameObjects[1].SetActive(false);
            gameObjects[2].SetActive(true);
            gameObjects[3].SetActive(false);
        }
        else if (Input.GetKey(KeyCode.V))
        {
            stateform = Stateform.normal;
            gameObjects[0].SetActive(false);
            gameObjects[1].SetActive(false);
            gameObjects[2].SetActive(false);
            gameObjects[3].SetActive(true);
        }
        switch (stateform)
        {
            case Stateform.attack:
                vector2 = transform.position;
                attacktimer += Time.deltaTime;
                break;
            case Stateform.ghillie:
                ghillietimer += Time.deltaTime;
                break;
            case Stateform.swim:
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    vector2.y += speed * 1.3f * Time.deltaTime;
                    gameObject.transform.position = vector2;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    vector2.y -= speed * 1.3f * Time.deltaTime;
                    gameObject.transform.position = vector2;
                }
                swimtimer += Time.deltaTime;
                break;
            case Stateform.normal:
                
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    vector2.y += speed * Time.deltaTime;
                    gameObject.transform.position = vector2;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    vector2.y -= speed * Time.deltaTime;
                    gameObject.transform.position = vector2;

                }
                break;
        }
    }

    void NormalMove()
    {

        
        
    }
    void AttackMove()
    {

    }

    void GhillieMove()
    {
        Vector2 vector2 = transform.position;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vector2.y += speed * 0.6f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            vector2.y -= speed * 0.6f * Time.deltaTime;
        }
    }

    void SwimMove()
    {
        
    }
}
