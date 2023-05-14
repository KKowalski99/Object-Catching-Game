using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Events
{
    public static class GameEvents
    {
        public static readonly Event OnMissedObjectCountChanged = new Event();

        public static readonly Event OnPaperPointsChanged = new Event();
        public static readonly Event OnCanPointsChanged = new Event();
        public static readonly Event OnPlasticPointsChanged = new Event();

        public static readonly Event<bool> ToggleGrabAction = new Event<bool>();

    }
}
