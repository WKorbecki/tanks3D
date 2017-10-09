using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class bulletControll : MonoBehaviour
{
    #region Variables
    List<GameObject> CollisionList;
    #endregion

    #region Mathods
    void OnCollisionEnter(Collision collision)
    {
        if (CollisionList == null) CollisionList = new List<GameObject>();

        if (collision.gameObject != null)
        {
            CollisionList.Add(collision.gameObject);

            if (collision.collider.tag == "Flag")
                Globals.Flag.Health -= 15.0f;

            if (collision.collider.tag == "Enemy")
                Globals.Enemy.Health -= 15.0f;
        }

        Destroy(gameObject); // Usuwanie obiektu
    }
    #endregion
}
