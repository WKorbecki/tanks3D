using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour
{
    #region Variables
    public GameObject bullet;
    #endregion

    #region Methods
    void Update ()
    {
        GameObject clone = new GameObject("pocisk"); // Stworzenie pustego obiektu gry

        // Sklonowanie prefabu??? do pustego obiektu
        if (Input.GetKeyDown(KeyCode.Space))
            clone = Instantiate(bullet, transform.position, transform.rotation) as GameObject;

        if (clone.name != "pocisk")
            clone.transform.position += clone.transform.forward * 1000 * Time.deltaTime;
    }
    #endregion
}
