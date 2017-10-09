using UnityEngine;
using System.Collections;

public static class Globals
{
    // Zmienne globalne
    #region Variables
    static bool gamepause;
    static ObjectModel player;
    static ObjectModel enemy;
    static ObjectModel flag;
    #endregion

    #region Methods
    public static void NewGame()
    {
        player = new ObjectModel(Vector3.zero, new Quaternion(0, 0, 0, 0), 1000, 1000, ObjectTag.Player);
        enemy = new ObjectModel(Vector3.zero, new Quaternion(0, 0, 0, 0), 500, 500, ObjectTag.Enemy);
        flag = new ObjectModel(Vector3.zero, new Quaternion(0, 0, 0, 0), 1500, 1500, ObjectTag.Flag);
        gamepause = false;
    }
    #endregion

    #region Properties
    public static bool Pause { set { gamepause = value; } get { return gamepause; } }
    public static ObjectModel Player { get { return player; } set { player = value; } }
    public static ObjectModel Enemy { get { return enemy; } set { enemy = value; } }
    public static ObjectModel Flag { get { return flag; } set { flag = value; } }
    #endregion
}
