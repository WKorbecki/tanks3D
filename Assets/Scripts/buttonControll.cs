using UnityEngine;
using System.Collections;

public class buttonControll : MonoBehaviour
{
	void Update ()
    {
        gameObject.SetActive(Globals.Pause); // Aktywacja lub deaktywacja przycisku kontynuacji gry
    }
}
