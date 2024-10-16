using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Controller
{
    public abstract class ControllerBase : MonoBehaviour
    {
        public abstract void OnUpdate(Unit unit);
    }
}

