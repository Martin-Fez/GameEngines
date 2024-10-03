using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelEnd : MonoBehaviour
{
    //every level has it's own levelEnd Object. This object knows what is going to be the next level our game
    // will open. The name of the next level is in this variable.
    public string nextLevel;

    // for example in level1 the value of this nextLevel is "Level2", in Level2 the value is "Level3" and so on.
    // you need to make Unity scenes and name them as "level1" "Level2" and "Level3"

    // When player hits this Level End object it will read the value of nextLevel and then open the scene
    // remember to put ALL your scenes to the list Build Settings.
}
