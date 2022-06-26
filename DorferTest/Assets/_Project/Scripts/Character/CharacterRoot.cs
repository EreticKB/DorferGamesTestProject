using UnityEngine;

public class CharacterRoot : MonoBehaviour
{
    internal State CharacterState;
    internal enum State
    { 
        Cutting,
        Idling,
        Walking
    }

}
