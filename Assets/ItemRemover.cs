using UnityEngine;

public class ItemRemover : MonoBehaviour
{
    private GameObject unitychan;
    //どのぐらい離れたらオブジェクトを削除するか
    private float distance = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find ("unitychan");        
    }

    // Update is called once per frame
    void Update()
    {
        //Unityちゃんの現在位置（Z座標）を取得して追い抜かれていたら自分を削除
        if(this.unitychan.transform.position.z - this.transform.position.z > this.distance)
        {
            Destroy(this.gameObject);   
        }
    }
}
