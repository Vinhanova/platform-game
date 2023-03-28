using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform respawnPoint;
    public GameObject playerPrefab;

    public CinemachineVirtualCameraBase cam;

    [Header("Currency")]
    public int currency = 0;
    public Text currencyUI;

    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("nivel1"))
        {
            SceneManager.LoadScene("nivel1");
        }
        else
        {
            SceneManager.LoadScene("nivel2");
        }
;        /*
        GameObject player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        cam.Follow = player.transform;
        */
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
        currencyUI.text = currency.ToString();
    }

    public void LevelChange()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("nivel1"))
        {
            SceneManager.LoadScene("nivel2");
        }
        else
        {
            SceneManager.LoadScene("nivel1");
        }
    }
}