using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapcreate : MonoBehaviour
{
    [SerializeField] GameObject _map;
    int _mapInstance = 3;
    Transform _mappos;
    bool check = true;
    int a = 0;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
         _mappos = transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (check && timer>=1)
        {
            _mappos.position = new Vector3(a * 5, 0, 0);
            Instantiate(_map, _mappos.parent);
            if (a == 3)
            {
                check = false;
               
            }
            a++;
            timer = 0;
        }
    }
}
