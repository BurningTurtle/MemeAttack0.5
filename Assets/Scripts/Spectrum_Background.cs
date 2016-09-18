using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Spectrum_Background : MonoBehaviour {

    public GameObject background;
    public bool initiated;

    // Use this for initialization
    void Start () {
        background = GameObject.FindGameObjectWithTag("Background");
        initiated = false;
	}
	
	// Update is called once per frame
	void Update () {
        float[] spectrum = AudioListener.GetSpectrumData(1024, 0, FFTWindow.Hamming);
        Vector3 previousScale = background.transform.localScale;

        if (Mathf.Lerp(previousScale.y, spectrum[2] * 8, Time.deltaTime * 30) > 1 && initiated == true)
        {
            if (SceneManager.GetActiveScene().name ==  "MainMenue")
            {
                previousScale.y = Mathf.Lerp(previousScale.y, spectrum[2] * 8, Time.deltaTime * 30);
            }
            else
            {
                previousScale.y = Mathf.Lerp(previousScale.y, spectrum[2] * 4, Time.deltaTime * 30);
            }
        }
        else if (Mathf.Lerp(previousScale.y, spectrum[2] * 8, Time.deltaTime * 30) > 0.1 && initiated == false)
        {
            previousScale.y = 0;
        }

        if (Mathf.Lerp(previousScale.x, spectrum[2] * 8, Time.deltaTime * 30) > 1 && initiated == true)
        {
            if (SceneManager.GetActiveScene().name == "MainMenue")
            {
                previousScale.x = Mathf.Lerp(previousScale.x, spectrum[2] * 8, Time.deltaTime * 30);
            }
            else
            {
                previousScale.x = Mathf.Lerp(previousScale.x, spectrum[2] * 4, Time.deltaTime * 30);
            }
        }
        else if (Mathf.Lerp(previousScale.x, spectrum[2] * 8, Time.deltaTime * 30) > 0.1 && initiated == false)
        {
            previousScale.x = 0;
        }

        if (Mathf.Lerp(previousScale.y, spectrum[2] * 8, Time.deltaTime * 30) > 0.1) initiated = true;

        background.transform.localScale = previousScale;
    }
}
