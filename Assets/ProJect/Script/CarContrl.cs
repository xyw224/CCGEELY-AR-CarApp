using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarContrl : MonoBehaviour
{
    private float y;
    //车辆控制速度参数
    private float speedOne = 0f;    //车辆实时速度
    private float speedMax = 1.5f;  //车辆最大速度
    private float speedMin = -20f;  //车辆最小速度(倒车最大速度）
    private float speedUpA = 0.1f;    //车辆加速加速度（A键控制）
    private float speedDownS = 0.5f;  //车辆减速加速度（S键控制）
    private float speedTend = 0.001f; //无操作实时速度趋于0时加速度
    private float speedBack = 0.0001f;   //车辆倒车加速度

    // Update is called once per frame
    void Update()
    {
        //按下W键并且速度没达到最大，则速度增加
        if (Input.GetKey(KeyCode.W) || CarManager.isMove == true && speedOne < speedMax)
        {
            speedOne = speedOne + Time.deltaTime * speedUpA;
        }
        //按下S键并且速度没达到零，则速度减小
        if (Input.GetKey(KeyCode.S) || CarManager.isBack == true && speedOne > 0f)
        {
            if (speedOne <= 0)
            {
                speedOne = 0;
                return;
            }
            speedOne = speedOne - Time.deltaTime * speedDownS;
        }
        //没有执行速度操作并且速度大于最小速度，则缓慢操作
        if (!Input.GetKey(KeyCode.W) || CarManager.isMove == false && !Input.GetKey(KeyCode.S) || CarManager.isBack == false && speedOne > 0f)
        {
            speedOne = speedOne - Time.deltaTime * speedTend;
        }
        if (!Input.GetKey(KeyCode.W) || CarManager.isMove == false && !Input.GetKey(KeyCode.S) || CarManager.isBack == false && speedOne < 0f)
        {
            speedOne = speedOne + Time.deltaTime * speedTend;
        }

        //按下S键并且速度没有达到倒车速度最大时，且车辆处于可以倒车状态时车辆倒车
        //if (Input.GetKey(KeyCode.S) || CarManager.isBack == true && speedOne > speedMax && speedOne <= 0)
        //{
        //    speedOne = speedOne - Time.deltaTime * speedBack;
        //}

        //按下空格，则汽车停止
        if (Input.GetKey(KeyCode.Space) && speedOne != 0)
        {
            speedOne = Mathf.Lerp(speedOne, 0, 0.4f);
            if (speedOne < 5) speedOne = 0;
        }

        if (speedOne > 0)
        {
            transform.Translate(Vector3.back * speedOne * Time.deltaTime);
        }
        //使用A和D来控制物体左右旋转
        if (speedOne > 0.1f)
        {
            y = Input.GetAxis("Horizontal") * 60f * Time.deltaTime;
            if (CarManager.isY == true)
            {
                y += 1;
            }
            if (CarManager.isZ == true)
            {
                y -= 1;
            }
            transform.Rotate(0, y, 0);
        }

        /* if (transform.eulerAngles.z != 0)
         {
             transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
         }*/
    }
}
