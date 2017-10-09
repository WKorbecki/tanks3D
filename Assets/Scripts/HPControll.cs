using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HPControll : MonoBehaviour
{
    #region Methods
    void Update ()
    {
        switch(name)
        {
            case "Player HP": PlayerHP(); break;
            case "Flag HP": FlagHP(); break;
            case "Enemy HP": EnemyHP(); break;
        }
    }

    void PlayerHP() // Sterowanie paskiem życia gracza
    {
        transform.localPosition = new Vector3((float)(-Screen.width / 2), (float)(Screen.height / 2));
        float health = Globals.Player.Health / Globals.Player.Health_Max * 100;
        transform.rotation = Quaternion.Euler(0f, 0f, 0.9f * health - 90f);
        Globals.Player.Health = (Globals.Player.Health <= 0f) ? 0f : Globals.Player.Health;
    }

    void FlagHP() // Sterowanie paskiem życia flagi
    {
        float scaleX = (Screen.width - 75) / 75 * Globals.Flag.Health / Globals.Flag.Health_Max;
        transform.localScale = new Vector3(scaleX, 1.25f, 1f);
        Globals.Flag.Health = (Globals.Flag.Health <= 0f) ? 0f : Globals.Flag.Health;
    }

    void EnemyHP() // Sterowanie paskiem życia komputera
    {
        transform.localPosition = new Vector3((float)(Screen.width / 2), (float)(Screen.height / 2));
        float health = Globals.Enemy.Health / Globals.Enemy.Health_Max * 100;
        transform.rotation = Quaternion.Euler(0f, 180f, 0.9f * health - 90f);
        Globals.Enemy.Health = (Globals.Enemy.Health <= 0f) ? 0f : Globals.Enemy.Health;
    }
    #endregion
}
