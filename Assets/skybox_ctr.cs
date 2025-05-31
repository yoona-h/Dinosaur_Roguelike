using UnityEngine;

public class skybox_ctr : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation",Time.time*2f);
        
    }
}
