using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIControl : MonoBehaviour
{
    #region Variables
    tankModel tank;
    Transform tankPlayer;
    Transform tankEnemy;
    Transform flag;
    bool onGround;
    List<GameObject> CollisionList;
    #endregion

    #region Methods
    void Start ()
    {
        tank = new tankModel(TankType.Heavy);
        tankPlayer = GameObject.FindWithTag("Player").transform;
        tankEnemy = transform;
        onGround = false;

        if (Globals.Enemy.Position != Vector3.zero)
        {
            transform.position = Globals.Enemy.Position;
            transform.rotation = Globals.Enemy.Rotation;
            //Globals.Enemy.Health = (Globals.Enemy.Health == 0f) ? 500f : Globals.Enemy.Health;
            //Globals.Enemy.Health_Max = (Globals.Enemy.Health_Max == 0f) ? 500f : Globals.Enemy.Health_Max;
        }
    }
	
	void Update ()
    {
        tankPlayer = GameObject.FindWithTag("Player").transform;
        flag = GameObject.FindWithTag("Flag").transform;

        tank.InRange = (tank.Range >= Vector3.Distance(tankEnemy.position, tankPlayer.position)) ? true : false;
        
        float distancePE = Vector3.Distance(tankEnemy.position, tankPlayer.position); // Odległość pomiędzy graczem a komputerem
        float distanceFE = Vector3.Distance(tankEnemy.position, flag.position); // Odległość pomiędzy flagą a komputerem

        if(onGround && Globals.Enemy.Health > 0)
        {
            if (tank.InRange) // Ściganie gracza
            {
                tankEnemy.rotation = Quaternion.Slerp(tankEnemy.rotation, Quaternion.LookRotation(tankPlayer.position - tankEnemy.position), tank.RotateSpeed * Time.deltaTime);
                tankEnemy.position += tankEnemy.forward * tank.Speed * Time.deltaTime;
            }
            else if (distanceFE > 30f) // Powrót do bazy
            {
                tankEnemy.rotation = Quaternion.Slerp(tankEnemy.rotation, Quaternion.LookRotation(flag.position - tankEnemy.position), tank.RotateSpeed * Time.deltaTime);
                tankEnemy.position += tankEnemy.forward * tank.Speed * Time.deltaTime;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (CollisionList == null) CollisionList = new List<GameObject>();

        if (collision.gameObject != null)
            CollisionList.Add(collision.gameObject);
    }

    void OnCollisionStay()
    {
        onGround = (CollisionList.FindAll(go => go.tag == "Terrain").Count > 0) ? true : false;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision != null)
            CollisionList.Remove(collision.gameObject);
    }
    #endregion
}
