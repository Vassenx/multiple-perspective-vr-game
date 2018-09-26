using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Readme : MonoBehaviour {

    //Sam Difeo
    //Fall, 2018

    //My notes for starting VR Dev with Windows Mixed Reality Toolkit (Hololens toolkit)

    //AUDIO:

    //Edit -> Project Settings -> Audio -> Spatializer Plugin set to MS HRTF Spatializer
    //Add an audio source to an object, check off Spatialize under 3D Settings

    //CONTROLLERS:

    //Controller spawning away from you? (Specifically at the origin?)
    //Your main camera should start you at the origin, why? ... not sure. 
    //But change your main camera (and its parent if it has one) to the origin. Done.

    //MixedRealityCameraParent object -> MotionController -> Click the use alternative controller buttons 
    //And add the materials. Default was ControllerRect in the hololen toolkit input prefabs
    //using Holotoolkit.Unity.InputModule;
    //example: Input.GetAxis(InputMappingAxisUtility.CONTROLLER_LEFT_STICK_VERTICAL);

    //At end of InputManager.cs
    /*internal void HandleEvent<T>(InputPositionEventData eventData, Movement move)
    {
        throw new NotImplementedException();
    }*/

}
