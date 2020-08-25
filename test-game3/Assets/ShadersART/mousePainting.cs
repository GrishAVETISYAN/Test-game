using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousePainting : MonoBehaviour
{
    public CustomRenderTexture HeightMap;

    public Material HeightMapUpdate;
    Camera mainCamera;

    static readonly int DrawPosition = Shader.PropertyToID(name: "_DrawPosition");
    static readonly int DrawAngle = Shader.PropertyToID(name: "_DrawAngle");
    static readonly int RestoreAmount = Shader.PropertyToID(name: "_RestoreAmount");

    void Start()
    {
        HeightMap.Initialize();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        HeightMapUpdate.SetFloat(nameID: RestoreAmount, 1f/250f);//sran karelia timerner avelacnel vor aveli kamac hangi
        if (Input.GetMouseButton(0))
        {
            //HeightMapUpdate.SetVector(nameID: DrawPosition, Input.mousePosition);

            
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out RaycastHit hit))
            {
                Vector2 hitTextureCoord = hit.textureCoord;

                HeightMapUpdate.SetVector(nameID: DrawPosition, hitTextureCoord);
                HeightMapUpdate.SetFloat(nameID: DrawAngle, 45*Mathf.Deg2Rad);
            }
            
        }

        HeightMap.Update();
    }
}
