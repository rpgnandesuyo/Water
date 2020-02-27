using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrool : MonoBehaviour
{
    [SerializeField]float _speed;
    Vector3 vector3;
    Vector3 _transform;
    // Start is called before the first frame update
    void Start()
    {
        vector3 = new Vector3(_speed, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        _transform = transform.position;
        if (_transform.x <= -5)
        {
            transform.position = new Vector3(10,0,0);
        }
        gameObject.transform.position += vector3*Time.deltaTime; 
    }
}
