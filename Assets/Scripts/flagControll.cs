using UnityEngine;
using System.Collections;

public class flagControll : MonoBehaviour
{
    // Utrata życia przez flagę przy kontakcie z graczem
    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
            Globals.Flag.Health -= 28f;

        if (Globals.Flag.Health <= 0f)
        {
            Destroy(gameObject);
            Main main = new Main();
            main.LoadScene(0);
        }
    }*/
    void Update()
    {
        if (Globals.Flag.Health <= 0f)
        {
            Destroy(gameObject);
            Main main = new Main();
            main.LoadScene(0);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Player")
            Globals.Flag.Health -= 3f;
    }
}
