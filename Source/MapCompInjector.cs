using System.Linq;
using UnityEngine;
using Verse;

namespace RimRPC
{
    internal class MapCompInjector : MonoBehaviour
    {
        public void FixedUpdate()
        {
            if (Current.ProgramState != ProgramState.Playing)
            {
                return;
            }
            else
            {
                foreach (var map in Find.Maps.Where(m => m.GetComponent<MapCompHandler>() == null))
                {
                    map.components.Add(new MapCompHandler(map));
                    Log.Message("[RichPressence] Injected update comp to existing map!");
                }

                Destroy(this);
            }
        }
    }
}