using UnityEngine;
using System.Collections;

public class EnemytargetShot : MonoBehaviour
{ 
    GameObject player;
    [SerializeField]
        float Speed;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0.25f)* Time.timeScale;
    }
}
