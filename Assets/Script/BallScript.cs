using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    //ボールの移動の速さを指定
    public float speed = 5f;
    Rigidbody myRigidBody;
    //速さの最小値
    public float minSpeed = 5f;
    //速さの最大値
    public float maxSpeed = 10f;
    Transform myTransform;
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyにアクセスして変数に保持しておく
        myRigidBody = GetComponent<Rigidbody>();
        //右斜め４５度に進む
        myRigidBody.velocity = new Vector3(speed, speed, 0f);
        myTransform = transform;

    }

    // Update is called once per frame
    void Update()
    {
        //現在の速さを取得
        Vector3 velocity = myRigidBody.velocity;
        //速さ計算
        float clampspeed = Mathf.Clamp(velocity.magnitude,minSpeed,maxSpeed);
        //速度の変更
        myRigidBody.velocity = velocity.normalized * clampspeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bar"))
        {
            //Barの位置を取得
            Vector3 barpos = collision.transform.position;
            //Ballの位置も取得
            Vector3 ballpos = myTransform.position;
            //Barから見たBallの方向を計算
            Vector3 direction = (ballpos - barpos).normalized;
            //速さの取得
            float speed = myRigidBody.velocity.magnitude;
            //速度を変更
            myRigidBody.velocity=direction * speed;
        }
    }
}
