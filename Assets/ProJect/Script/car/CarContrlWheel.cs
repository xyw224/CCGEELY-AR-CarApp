using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CarContrlWheel : MonoBehaviour
{
    private Transform tr;
    public float max_speed;
    public float moveSpeed = 0;
    public float rotSpeed;
    public float jia_su_du;
    public bool turn_left;
    public float jiazhuanwan;
    public bool turn_right;
    public bool turn_go;
    public bool onSKY;
    public float drop;
    public float dropWangxia;
    public bool cantRun;
    public bool Stop;
    public float stop_fast_or_slow;
    public bool Dirft;
    public float dirft_fast_or_slow;
    public float dirft_fast_or_slow_rot;
    public GameObject obj;
    public bool use_button;
    public Canvas canvas_control_car;
    public float piaoyi_xuanzhuan_jiaodu_zengda;
    public bool use_WASD;
    public bool jianxiao_piaoyi_zhengda_shifou;
    void Start()
    {
        tr = GetComponent<Transform>();
        moveSpeed = 0;
        rotSpeed = 0;
        jia_su_du = 2;
        turn_go = false;
        turn_left = false;
        turn_right = false;
        rotSpeed = 0;
        onSKY = false;
        cantRun = true;
        Debug.Log("start game~");
        use_button = false;
        // canvas_control_car.enabled = false;
        piaoyi_xuanzhuan_jiaodu_zengda = 0.5f;
    }


    void Update()
    {
        //h = Input.GetAxis("Horizontal");
        //v = Input.GetAxis("Vertical");
        if (use_button == false)
        {
            if (use_WASD)
            {

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Dirft = true;
                }
                else
                {
                    if (Input.GetKey(KeyCode.RightShift))
                    {
                        Dirft = true;
                    }
                    else
                    {
                        Dirft = false;
                    }
                }
                if (Dirft == false)
                {
                    if (Input.GetKey(KeyCode.W))
                    {
                        turn_go = true;
                    }
                    else
                    {
                        turn_go = false;
                    }
                }
                if (Input.GetKey(KeyCode.S))
                {
                    if (cantRun == false)
                    {
                        Stop = true;
                    }
                }
                else
                {
                    Stop = false;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    turn_left = true;
                    if (rotSpeed > 0)
                    {
                        //rotSpeed = 0;
                    }
                }
                else
                {
                    turn_left = false;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    turn_right = true;
                    if (rotSpeed < 0)
                    {
                        //rotSpeed = 0;
                    }
                }
                else
                {
                    turn_right = false;
                }
                if (Input.GetKeyUp(KeyCode.D))
                {
                    //rotSpeed = 0;
                    jianxiao_piaoyi_zhengda_shifou = true;
                }
                if (Input.GetKeyUp(KeyCode.A))
                {
                    //rotSpeed = 0;
                    jianxiao_piaoyi_zhengda_shifou = true;
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    //rotSpeed = 0;
                    jianxiao_piaoyi_zhengda_shifou = true;
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    //rotSpeed = 0;
                    jianxiao_piaoyi_zhengda_shifou = true;
                }
            }
            if (use_WASD == false)
            {

                if (Input.GetKey(KeyCode.Space))
                {
                    Dirft = true;
                }
                else
                {
                    Dirft = false;



                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    turn_go = true;
                }
                else
                {
                    turn_go = false;
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    if (cantRun == false)
                    {
                        Stop = true;
                    }
                }
                else
                {
                    Stop = false;
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    turn_left = true;
                    if (rotSpeed > 0)
                    {
                        //rotSpeed = 0;
                    }
                }
                else
                {
                    turn_left = false;
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    turn_right = true;
                    if (rotSpeed < 0)
                    {
                        //rotSpeed = 0;
                    }
                }
                else
                {
                    turn_right = false;
                }
                if (Input.GetKeyUp(KeyCode.RightArrow))
                {
                    //rotSpeed = 0;
                }
                if (Input.GetKeyUp(KeyCode.LeftArrow))
                {
                    //rotSpeed = 0;
                }
            }
        }

        if (rotSpeed > 5)
        {
            if (turn_left == false)
            {
                if (turn_right == false)
                {
                    rotSpeed = rotSpeed - 5;
                }
            }

        }
        if (rotSpeed < -5)
        {
            if (turn_left == false)
            {
                if (turn_right == false)
                {
                    rotSpeed = rotSpeed + 5;
                }
            }

        }
        if (moveSpeed > 0)
        {
            tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed);
        }
        moveSpeed = moveSpeed - (jia_su_du / 2);


        if (moveSpeed < 0)
        {
            if (Stop == false)
            {
                moveSpeed = 0;
            }
        }


        if (moveSpeed > max_speed)
        {
            moveSpeed = max_speed;
        }


        if (moveSpeed < -20)
        {
            moveSpeed = -20;
        }


        tr.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);


        if (turn_go)
        {
            if (cantRun == false)
            {
                moveSpeed = moveSpeed + jia_su_du;
            }
        }


        if (onSKY == true)
        {
            tr.Translate(Vector3.down * drop * Time.deltaTime, Space.World);
            tr.Rotate(Vector3.down * Time.deltaTime * dropWangxia, Space.World);
            //moveSpeed = moveSpeed + jia_su_du;
        }


        if (Stop == true)
        {
            moveSpeed = moveSpeed - jia_su_du * stop_fast_or_slow;
        }


        if (Dirft == true)
        {
            if (cantRun == false)
            {
                if (moveSpeed > 5)
                {
                    piaoyi_xuanzhuan_jiaodu_zengda = piaoyi_xuanzhuan_jiaodu_zengda + 0.08f;
                    if (piaoyi_xuanzhuan_jiaodu_zengda > 5.9f)
                    {
                        piaoyi_xuanzhuan_jiaodu_zengda = 5.9f;
                    }
                    if (piaoyi_xuanzhuan_jiaodu_zengda < 0)
                    {
                        piaoyi_xuanzhuan_jiaodu_zengda = 0;
                    }
                    tr.Translate(Vector3.right * -(moveSpeed * rotSpeed / dirft_fast_or_slow) * Time.deltaTime, Space.Self);
                    tr.Rotate(Vector3.up * Time.deltaTime * (rotSpeed * dirft_fast_or_slow_rot * piaoyi_xuanzhuan_jiaodu_zengda), Space.Self);
                    if (use_button == true)
                    {
                        //moveSpeed = moveSpeed + jia_su_du;
                    }
                }
            }
        }
        if (jianxiao_piaoyi_zhengda_shifou)
        {
            piaoyi_xuanzhuan_jiaodu_zengda = piaoyi_xuanzhuan_jiaodu_zengda - 0.1f + (moveSpeed * 0.0008f);
        }
        {
            jianxiao_piaoyi_zhengda_shifou = true;
        }
        if (turn_left == true)
        {
            if (cantRun == true)
            {
                rotSpeed = rotSpeed - (jiazhuanwan / 2);
            }
            else
            {
                rotSpeed = rotSpeed - jiazhuanwan;
            }
        }
        if (turn_right == true)
        {
            if (cantRun == true)
            {
                rotSpeed = rotSpeed + (jiazhuanwan / 2);
            }
            else
            {
                rotSpeed = rotSpeed + jiazhuanwan;
            }
        }
        if (rotSpeed > 45)
        {
            rotSpeed = 45;
        }
        if (rotSpeed < -45)
        {
            rotSpeed = -45;
        }
    }


    public void OnClickLeft()
    {
        turn_left = true;
        jianxiao_piaoyi_zhengda_shifou = false;
    }
    public void OnClickRight()
    {
        turn_right = true;
        jianxiao_piaoyi_zhengda_shifou = false;
    }
    public void OnCLickGO()
    {
        turn_go = true;
    }
    public void LUP()
    {
        //rotSpeed = 0;
        turn_left = false;
        jianxiao_piaoyi_zhengda_shifou = true;
    }
    public void RUP()
    {
        //rotSpeed = 0;
        turn_right = false;
        jianxiao_piaoyi_zhengda_shifou = true;
    }
    public void GUP()
    {
        turn_go = false;
    }
    //触发
    void OnTriggerExit(Collider other)
    {
        onSKY = true;
    }
    void OnTriggerStay(Collider other)
    {
        onSKY = false;
    }
    public void STDW()
    {
        Stop = true;
    }
    public void STUP()
    {
        Stop = false;
    }
    public void DirftDW()
    {
        Dirft = true;
    }
    public void DirftUP()
    {
        Dirft = false;
    }
    public void OnClick_use_BUTTON_or_Keyboard()
    {
        if (use_button == true)
        {
            use_button = false;
            canvas_control_car.enabled = false;
        }
        else
        {
            use_button = true;
            canvas_control_car.enabled = true;
        }
    }
}