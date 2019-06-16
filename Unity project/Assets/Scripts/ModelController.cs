using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelController : DefaultTrackableEventHandler
{
    #region GameObjects
    GameObject Model;
    #endregion
    #region Animations
    Animation ModelAnimation;
    #endregion
    #region Parameters
    bool Playable = false;
    #endregion

    #region MonoBehaviour

   
    void Awake()
    {
        Model = GameObject.FindGameObjectWithTag("Model");  
        ModelAnimation = Model.GetComponent<Animation>();

    }
    void Update()
    {
        if(Input.touchCount > 0 && Playable)
        {
            if(ModelAnimation["Dissociation"].normalizedTime <= 0) //dissocier la voiture
            {
                ModelAnimation["Dissociation"].normalizedTime = 0.0f;
                ModelAnimation["Dissociation"].speed = 1;
                ModelAnimation.Play("Dissociation");
            }
            else if(ModelAnimation["Dissociation"].normalizedTime >= 1) //Reassembler la voiture
            {
                ModelAnimation["Dissociation"].normalizedTime = 1.0f;
                ModelAnimation["Dissociation"].speed = -1;
                ModelAnimation.Play("Dissociation");
            }
        }
    }
    #endregion

    #region TrackingMethods
    protected override void OnTrackingFound()  //lors de la détection Une animation sera joué
    {
        base.OnTrackingFound();
        ModelAnimation.Play("Apparaitre");
        Playable = true;
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();
        Playable = false;
    }

    #endregion
}
