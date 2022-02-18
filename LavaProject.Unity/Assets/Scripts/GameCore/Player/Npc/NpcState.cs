using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace StateSettings
{
    [Serializable]
    public enum State
    { 
        attack,
        idle,
        run    
    }



    [Serializable]
    public abstract class NpcState 
    {
        public abstract AjdahaState ApllyState();
        public string availibaleVersionOfGame { get; set; }
        public State state { get; set; }
    }

    [Serializable]
    public abstract class AjdahaState : NpcState
    {
      
    }
    [Serializable]
    public class IdleAjdaha : AjdahaState
    { 
        public override AjdahaState ApllyState()
        {
            state = State.idle;
            return this;
        }
    }
    [Serializable]
    public class AttackAjdaha : AjdahaState
    {
        GameObject particles;
        public override AjdahaState ApllyState()
        {
            state = State.attack;
            particles = Resources.Load<GameObject>("Particles/Particles/Boom");  
            return this;
        }
    }
    [Serializable]
    public class RunAjdaha : AjdahaState
    {
        public override AjdahaState ApllyState()
        {
            state = State.run;
            return this;
        }
    }


}
