using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoPSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject[] enemys;
    float time = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Vector2 position = transform.position;
            float y = Random.Range(-6.0f, 6.0f);
            position.y = y;
            GameObject obj = Instantiate(enemys[0], position, Quaternion.identity);
            time += 1;
        }
    }
}
