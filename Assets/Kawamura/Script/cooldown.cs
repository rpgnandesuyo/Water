using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cooldown : MonoBehaviour
{
    public Image CircleGauge;

    [SerializeField]
    private float countTime = 2.0f;
    private float countdown;
    private player player;
    public enum State{
       attack,ghillie,swim
    }
    State state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.attack:
                if(player.attacktimer >= 10)
                {
                    countdown = 10;
                }
                else
                {
                    countdown = countTime + player.attacktimer;
                }
                break;
            case State.ghillie:
                if (player.ghillietimer >= 10)
                {
                    countdown = 10;
                }
                else
                {
                    countdown = countTime + player.ghillietimer;
                }
                break;
            case State.swim:
                if (player.swimtimer >= 10)
                {
                    countdown = 10;
                }
                else
                {
                    countdown = countTime + player.swimtimer;
                }
                break;
        }
        CircleGauge.fillAmount -= 1.0f / countdown * Time.deltaTime;
    }
}
