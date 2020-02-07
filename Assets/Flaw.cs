using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flaw : MonoBehaviour
{
    [SerializeField]
    private float bubbleDelay;
    [SerializeField]
    GameObject bubble;

    private float bubbleInstant = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bubbleInstant >= bubbleDelay)
        {
            Instantiate(bubble,gameObject.transform);
            bubbleInstant = 0;
        }
        bubbleInstant += Time.deltaTime;
    }
}
