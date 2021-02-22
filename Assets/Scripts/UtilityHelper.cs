using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilityHelper
{
    // Given transform object will be rotated using the given direction
    public static void ChangeRotation(Transform t, Vector3 dir)
    {
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(t.rotation, lookRotation, Time.deltaTime * 10f).eulerAngles;
        t.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    // Will return if the given gameobject has the velocity of 0
    public static bool IsGOSleeping(GameObject gO)
    {
        if (gO.GetComponent<Rigidbody>().velocity == new Vector3(0f, 0f, 0f))
            return true;
        else return false;
    }
}
