using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStart : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.anyKeyDown)
        {
            SceneManager.LoadScene("GameScene");
        }

    }
}
