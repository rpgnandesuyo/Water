using UnityEngine;
public class EnemyController : MonoBehaviour
{
    //外部参照可の変数
    [SerializeField]
    protected float speed;//NPC移動速度
  
    [SerializeField]
    protected string chara;//追尾対象のオブジェクト名
    [SerializeField]
    protected bool move = true;
    //外部参照不可の変数
    protected GameObject targetplayer;//追尾対象となるオブジェクト
    protected float rad;//ラジアン変数
    protected float destination_x, destination_y;//移動目的地
    protected double distance = 0;//2点間の距離
    protected int my_x=0, my_y=0, des_x=0, des_y=0;//右から自分のｘ,y座標、目的地のx,y座標（int型に変換したものを代入）
    protected float move_x, move_y;//移動方向代入変数
    protected int tmp = 0;//sqrt使う前に計算式を入れる
    public bool PLFind = false;
    private void Start()
    {
        targetplayer = GameObject.Find(chara);
        Destination_decision();
    }

    private void Update()
    {
        //距離は3平方の定理で
        tmp = (int)((transform.position.x - targetplayer.transform.position.x) * (transform.position.x - targetplayer.transform.position.x) + (transform.position.y - targetplayer.transform.position.y) * (transform.position.y - targetplayer.transform.position.y));
        distance = System.Math.Sqrt(tmp);
        PlayerChase(targetplayer);
        PLFind = true;
        if (move)
        {
            move_x *= Time.timeScale;
            move_y *= Time.timeScale;
            transform.Translate(move_x * Time.deltaTime, move_y * Time.deltaTime, 0, Space.World);
        }
    }

    //目的地決定関数
    private void Destination_decision()
    {
      //  destination_x = Random.Range(-Movement_range, Movement_range);
      //  destination_y = Random.Range(-Movement_range, Movement_range);
    }

    //プレイヤー索敵関数
    private void Searching_player()
    {
        my_x = (int)transform.position.x;
        my_y = (int)transform.position.y;
        des_x = (int)destination_x;
        des_y = (int)destination_y;
        //目的地到着の場合は新しい目的地を配る
        if (my_x == des_x && my_y == des_y)
        {
            Destination_decision();
        }
        //移動方向決定部
        if (my_x < des_x && my_y < des_y)
        {
            move_x = move_y = speed;
        }
        if (my_x >= des_x && my_y < des_y)
        {
            move_x = -speed;
            move_y = speed;
        }
        if (my_x < des_x && my_y >= des_y)
        {
            move_x = speed;
            move_y = -speed;
        }
        if (my_x >= des_x && my_y >= des_y)
        {
            move_x = move_y = -speed;
        }
        
        if (my_x == des_x)
        {
            move_x = 0;
        }
        if (my_y == des_y)
        {
            move_y = 0;
        }
    }

    //プレイヤー追跡関数
    protected void PlayerChase(GameObject target)
    {
        rad = Mathf.Atan2(target.transform.position.y - transform.position.y,
            target.transform.position.x - transform.position.x);
        move_x = speed * Mathf.Cos(rad);
        move_y = speed * Mathf.Sin(rad);
    }
}