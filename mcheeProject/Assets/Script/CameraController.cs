using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float xRotate, yRotate, xRotateMove, yRotateMove;
    public float rotateSpeed = 500.0f;
    public Transform target;//��������
    public GameObject stage;//���������ѵ� �����̼�
    public GameObject cambackup;

    //--------------Static ����.�� �ǵ����� ����.--------------------//
    public static Vector3 camarabu;
    //--------------------------------------------------------------//
     void Start()
    {
      
    }
    void Update()
    {
     
            xRotateMove = -Input.GetAxis("Mouse Y") * Time.deltaTime * rotateSpeed;
            yRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;

            yRotate = transform.eulerAngles.y + yRotateMove;
           
            xRotate = xRotate + xRotateMove;

            xRotate = Mathf.Clamp(xRotate, -90, 90); 

            transform.eulerAngles = new Vector3(xRotate, yRotate, 0);

        CharactorMouse();
        Camback();


    }
   /* private Vector3 AngleToDirection(float x,float y,float z)
    {
        Vector3 direction =transform.forward;

        var quaternion = Quaternion.Euler(x, y, z);
        Vector3 newDirection = quaternion * direction;

        return newDirection;
    }*/
   public void Camback()
    {
       
        if (Input.GetKey(KeyCode.F1))//3��Ī���� �ǵ�����,�� ĳ���� �������� �ʱ�ȭ
        {
            Vector3 PlayerPos = cambackup.transform.position;
            Quaternion playerRot = cambackup.transform.rotation;
            transform.position = new Vector3(PlayerPos.x, PlayerPos.y, PlayerPos.z);
            transform.rotation = new Quaternion(playerRot.x, playerRot.w, playerRot.y, playerRot.z);
            transform.LookAt(target);
        }
    }
    public void CharactorMouse()
    {  
        if (Input.GetMouseButtonDown(1))
        {//��������(1��Ī)
            Vector3 PlayerPos = stage.transform.position;
            Quaternion playerRot = stage.transform.rotation;
            transform.position = new Vector3(PlayerPos.x, PlayerPos.y, PlayerPos.z);
            
        }
        
        if (Input.GetMouseButtonDown(0))
        {


            transform.LookAt(target);


        }
        if (Input.GetMouseButton(0))
        {
            xRotateMove = Input.GetAxis("Mouse X") * Time.deltaTime * rotateSpeed;

            Vector3 stagePosition = stage.transform.position;

            transform.RotateAround(stagePosition, Vector3.up, xRotateMove);
            transform.LookAt(stagePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector3 PlayerPos = cambackup.transform.position;
            Quaternion playerRot = cambackup.transform.rotation;
            transform.position = new Vector3(PlayerPos.x, PlayerPos.y, PlayerPos.z);
            transform.rotation = new Quaternion(playerRot.x, playerRot.w, playerRot.y, playerRot.z);
            transform.LookAt(target);
        }
    }
}

