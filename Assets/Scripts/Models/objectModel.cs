using UnityEngine;
using System.Collections;

public enum ObjectTag { Player, Enemy, Flag };

public class ObjectModel
{
    #region Variables
    Vector3 position;
    Quaternion rotation;
    float hpActually;
    float hpMax;
    ObjectTag tag;
    tankModel tank;
    #endregion

    public ObjectModel(Vector3 position, Quaternion rotation, float health, float healthMax, ObjectTag tag)
    {
        this.position = position;
        this.rotation = rotation;
        hpActually = health;
        hpMax = healthMax;
        this.tag = tag;
    }

    #region Methods
    #endregion

    #region Properties
    public Vector3 Position { get { return this.position; } set { this.position = value; } }
    public Quaternion Rotation { get { return this.rotation; } set { this.rotation = value; } }
    public float Health { get { return this.hpActually; } set { this.hpActually = value; } }
    public float Health_Max { get { return this.hpMax; } set { this.hpMax = value; } }
    public ObjectTag Tag { get { return this.tag; } set { this.tag = value; } }
    public tankModel Tank { get { return this.tank; }set { this.tank = value; } }
    #endregion
}
