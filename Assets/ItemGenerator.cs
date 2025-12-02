using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    private GameObject unitychan;


    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //conePrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;

    //既に配置が完了している座標
    private int arrangedPos = 40;

    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //アイテムを配置する間隔
    private int interval = 15;


    //指定したZ座標にオブジェクトを配置する
    void SetObjects(int newPos)
    {
        //どのアイテムを出すのかをランダムに設定
        int num = Random.Range (1, 11);
        if (num <= 2)
        {
            //コーンをx軸方向に一直線に生成
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate (conePrefab);
                cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, newPos);
            }
        }
        else
        {

            //レーンごとにアイテムを生成
            for (int j = -1; j <= 1; j++)
            {
                //アイテムの種類を決める
                int item = Random.Range (1, 11);
                //アイテムを置くZ座標のオフセットをランダムに設定
                int offsetZ = Random.Range(-5, 6);
                //60%コイン配置:30%車配置:10%何もなし
                if (1 <= item && item <= 6)
                {
                    //コインを生成
                    GameObject coin = Instantiate (coinPrefab);
                    coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, newPos + offsetZ);
                }
                else if (7 <= item && item <= 9)
                {
                    //車を生成
                    GameObject car = Instantiate (carPrefab);
                    car.transform.position = new Vector3 (posRange * j, car.transform.position.y, newPos + offsetZ);
                }
            }
        }        
    }


    // Start is called before the first frame update
    void Start ()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find ("unitychan");

    }

    // Update is called once per frame
    void Update ()
    {
        //次にオブジェクトを配置する基準地点に到達した
        if((int)unitychan.transform.position.z + this.startPos >= this.arrangedPos)
        {
            this.arrangedPos += this.interval;
            //オブジェクトを配置して良い場所かどうかを判別
            if(this.arrangedPos >= this.startPos && this.arrangedPos <= this.goalPos){
                SetObjects(this.arrangedPos);
                //Debug.Log("SetObjects:"+this.arrangedPos);
            }
        }
    }
}