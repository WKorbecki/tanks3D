using UnityEngine;
using System.Collections;

public enum TankType { Light, Medium, Heavy}

public class tankModel
{
    #region Variables
    float speed;
    float rotateSpeed;
    float range;
    bool inRange;
    float health;
    TankType tankType;
    Vector3 position;
    Quaternion rotate;
    #endregion

    public tankModel(TankType tankType)
    {
        ChangeTank(tankType);
        this.range = 2000.0f;
        this.health = 100.0f;
    }

    #region Methods
    public void ChangeTank(TankType tankType)
    {
        switch (tankType)
        {
            case TankType.Light:
                this.speed = 240.0f / 6;
                this.rotateSpeed = 60.0f / 2;
                break;
            case TankType.Medium:
                this.speed = 100.0f / 6;
                this.rotateSpeed = 20.0f / 2;
                break;
            case TankType.Heavy:
                this.speed = 60.0f/10;
                this.rotateSpeed = 8.5f / 2;
                break;
            default:
                this.speed = 240.0f;
                this.rotateSpeed = 60.0f;
                break;
        }
    }
    #endregion

    #region Properties
    public float Speed { get { return this.speed; } }
    public float RotateSpeed { get { return this.rotateSpeed; } }
    public float Range { get { return this.range; } set { this.range = value; } }
    public TankType Type { get { return this.tankType; } }
    public bool InRange { get { return this.inRange; } set { this.inRange = value; } }
    public float Health { get { return this.health; } set { this.health = value; } }
    public Vector3 Position { get { return this.position; } set { this.position = value; } }
    public Quaternion Rotate { get { return this.rotate; } set { this.rotate = value; } }
    #endregion
}
