using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderController : MonoBehaviour
{
    public Light thunderLight;

    public AudioClip thunderSound;

    public float timeToLive = 0.8F;

    public float audioScale = 0.7F;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Working?");
            StopAllCoroutines();
            SetLightIntensity(0.0F);
            ExecuteThunder();
        }
    }

    void ExecuteThunder() {
        PlayThunder();
        StartCoroutine(ShowThunder());
    }

    void PlayThunder()
    {
        audioSource.PlayOneShot(thunderSound, audioScale);
    }

    IEnumerator ShowThunder() {
        SetLightIntensity(0.9F);
        yield return new WaitForSeconds(timeToLive * 0.4F);
        SetLightIntensity(0.25F);

        yield return new WaitForSeconds(0.01F);

        SetLightIntensity(1.2F);
        yield return new WaitForSeconds(timeToLive);
        SetLightIntensity(0.25F);

        yield return new WaitForSeconds(0.01F);

        SetLightIntensity(1.0F);
        yield return new WaitForSeconds(timeToLive * 0.4F);
        SetLightIntensity(0.0F);
    }

    void SetLightIntensity(float intensity) {
        thunderLight.intensity = intensity;
    } 

}
