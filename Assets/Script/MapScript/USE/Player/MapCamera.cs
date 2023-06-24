using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour
{
    public float smoothSpeed;
    GameObject player;
    Transform cameraTransform;
    // Start is called before the first frame update

    //Vector3 point = UnityEngine.Random.insideUnitSphere * 0.1f;


    void Start()
    {
        transform.rotation= Quaternion.Euler(27, 0, 0);
        cameraTransform = transform;
        smoothSpeed = 3f;
    }

    float currentTime = 0f;
    float TargetTime = 0.2f;
    void Update()
    {
        player = GameManager.instance.currentMario;
        
        if(MPlayer.instance.cameraShake)
        {
            currentTime += Time.deltaTime;
            if(currentTime<TargetTime)
            {
                Vector3 point = UnityEngine.Random.insideUnitSphere * 0.1f;
                transform.position += point;
            }else
            {
                currentTime = 0;
                MPlayer.instance.cameraShake = false;
            }    

        }else
        {
            Vector3 desiredPosition = player.transform.position - cameraTransform.forward * 11f + cameraTransform.up * 2f;

            cameraTransform.position = Vector3.Lerp(cameraTransform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        }

    }
 
}
