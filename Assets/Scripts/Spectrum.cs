
using UnityEngine;
using System.Collections;

public class Spectrum : MonoBehaviour {

    public GameObject[] bars;

	// Use this for initialization
	void Start () {
        bars = GameObject.FindGameObjectsWithTag("Bar");
    }
	
	// Update is called once per frame
	void Update () {
        float[] spectrum = AudioListener.GetSpectrumData(1024, 0, FFTWindow.Hamming);
        for (int i = 0; i < 32; i++)
        {
            Vector3 previousScale = bars[i].transform.localScale;
            previousScale.y = Mathf.Lerp(previousScale.y, spectrum[i] * 8, Time.deltaTime * 30);
            bars[i].transform.localScale = previousScale;
        }
	
	}
}
