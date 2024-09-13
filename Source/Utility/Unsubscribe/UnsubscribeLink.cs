using UnityEngine;

namespace PS.UiFramework.Unsubscribe
{
    /// <summary>
    /// Represents a link to a game object used for managing unsubscription from observables.
    /// </summary>
    public class UnsubscribeLink
    {
        internal GameObject LinkObject { get; }

        internal UnsubscribeLink(GameObject linkObject)
        {
            LinkObject = linkObject;
        }
    }
}