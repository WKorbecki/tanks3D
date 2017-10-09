using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class tankControl : MonoBehaviour
{
    #region Variables
    bool onGround;
    List<GameObject> CollisionList;
    tankModel tank;
    #endregion

    #region Methods
    void Start ()
    {
        tank = new tankModel(TankType.Light);
        CollisionList = new List<GameObject>();

        if (Globals.Player.Position != Vector3.zero)
        {
            transform.position = Globals.Player.Position;
            transform.rotation = Globals.Player.Rotation;
            //Globals.Player.Health = (Globals.Player.Health == 0f) ? 1000f : Globals.Player.Health;
            //Globals.Player.Health_Max = (Globals.Player.Health_Max == 0f) ? 1000f : Globals.Player.Health_Max;
        }
    }
	
    void Update ()
    {
        // Obracanie czołgu
        float rotate = Input.GetAxis("Horizontal") * ((Input.GetAxisRaw("Vertical") != 0) ? Input.GetAxisRaw("Vertical") : 1) * tank.RotateSpeed * Time.deltaTime;
        Vector3 v3 = new Vector3(0, rotate, 0);
        transform.Rotate(v3);

        // Poruszanie czołgu do przodu i do tyłu
        if (onGround) transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * tank.Speed * Time.deltaTime);

        // Grawitacja
        Physics.gravity = new Vector3(0.0f, -80.0f, 0.0f);

        // Przesuwanie kamery
        //Camera.main.transform.position = transform.position + new Vector3(0f, 15f, -30f);
        Camera.main.transform.position = transform.position + new Vector3(0f, 40f, -100f);
        print(Camera.main.transform.position);

        if (Globals.Player.Health <= 0f)
        {
            Destroy(gameObject);
            Main main = new Main();
            main.LoadScene(0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Funkcja ta tworzy listę kolizji a następnie sprawdza czy nastąpiła kolizja z terenem. Jeśli tak to czołg może się poruszać. W przypadku kolizji z flagą albo przeciwnikiem gracz traci życie.
        if (CollisionList == null) CollisionList = new List<GameObject>();

        if (collision.gameObject != null)
        {
            CollisionList.Add(collision.gameObject);

            //onGround = (CollisionList.FindAll(go => go.tag == "Terrain").Count > 0) ? true : false;

            /*if (collision.collider.tag == "Flag")
                Globals.Player.Health -= 28f;

            if (collision.collider.tag == "Enemy")
                Globals.Player.Health -= 40f;*/
        }
    }

    void OnCollisionStay()
    {
        if (CollisionList.Count > 0)
        {
            onGround = (CollisionList.FindAll(go => go.tag == "Terrain").Count > 0) ? true : false;

            foreach (GameObject collision in CollisionList)
            {
                if (collision.tag == "Flag")
                    Globals.Player.Health -= 3f;

                if (collision.tag == "Enemy")
                    Globals.Player.Health -= 1f;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision != null)
            CollisionList.Remove(collision.gameObject);
    }
    #endregion
}
