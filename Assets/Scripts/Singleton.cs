using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Singleton : MonoBehaviour
{


    private static Singleton instance = null;

    public static Singleton Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance != null && instance != this && SceneManager.GetActiveScene().name == "Main Menue")
        {
            Destroy(this.gameObject);
            return;
        }

        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

}
