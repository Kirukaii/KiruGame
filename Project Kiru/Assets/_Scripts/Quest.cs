using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class Quest : MonoBehaviour
{
    public string dialog;
    internal bool done;
    [Serializable]
    public struct Reqs
    {
        public GameObject req;
        public int Amount;
    }
    [Serializable]
    public struct Rews
    {
        public GameObject item;
        public int Amount;
        public int exp;
    }
    public Reqs[] Requirements;
    public Rews[] Rewards;
}
