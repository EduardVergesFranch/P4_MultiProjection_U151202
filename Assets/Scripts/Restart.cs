using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//restarts the game
public class Restart : MonoBehaviour
{
    
    public void Restart_Game()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
