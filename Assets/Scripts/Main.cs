using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
    #region Methods
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Globals.Pause) // Zapisanie ustawień gracza i komputera
        {
            Globals.Player.Position = GameObject.FindWithTag("Player").transform.position;
            Globals.Player.Rotation = GameObject.FindWithTag("Player").transform.rotation;
            Globals.Enemy.Position = GameObject.FindWithTag("Enemy").transform.position;
            Globals.Enemy.Rotation = GameObject.FindWithTag("Enemy").transform.rotation;
            Globals.Pause = true;
            LoadScene(0);
        }
        else if (Globals.Pause) 
        {
            
        }
    }

    public void NewGame()
    {
        Globals.NewGame();
        LoadScene(1);
    }

    public void UnPause() // Wznowienie gry i czytanie ustawień gracza i komputera
    {
        LoadScene(1);
        Globals.Pause = false;
        GameObject.FindWithTag("Player").transform.Translate(Globals.Player.Position);
        GameObject.FindWithTag("Player").transform.Rotate(Globals.Player.Rotation.ToEulerAngles());
        GameObject.FindWithTag("Enemy").transform.Translate(Globals.Enemy.Position);
        GameObject.FindWithTag("Enemy").transform.Rotate(Globals.Enemy.Rotation.ToEulerAngles());
    }

    public void LoadScene(int level)
    {
        switch (level)
        {
            case -1: // Wyjście
                Application.Quit();
                break;
            case 0: // Wyjście
                Application.LoadLevel(0);
                break;
            case 1: // Nowa gra
                Globals.Pause = false;
                Application.LoadLevel(1);
                break;
            default: // Brak akcji
                break;
        }
    }
    #endregion
}
