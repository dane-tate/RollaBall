using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class menu : MonoBehaviour
{
    public void StartGame(){
        EditorSceneManager.LoadScene("Game");
    }
}
