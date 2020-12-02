using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibeManager : MonoBehaviour
{
    public static VibeManager singleton;

    // Start is called before the first frame update
    void Start()
    {
        if (singleton && singleton != this)
            Destroy(this);
        else
            singleton = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void triggerViberationController(AudioClip vibeAudio, OVRInput.Controller controller)
    {
        OVRHapticsClip clip = new OVRHapticsClip(vibeAudio);

        if (controller == OVRInput.Controller.LTouch)
        {

            OVRHaptics.LeftChannel.Preempt(clip);

        }else if(controller == OVRInput.Controller.RTouch)
        {

            OVRHaptics.RightChannel.Preempt(clip);

        }
    }
}
