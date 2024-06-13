using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    //ボールの移動の速さを指定
    public float speed = 5f;
    Rigidbody myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyにアクセスして変数に保持しておく
        myRigidBody = GetComponent<Rigidbody>();
        //右斜め４５度に進む
        myRigidBody.velocity = new Vector3(speed, speed, 0f);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
