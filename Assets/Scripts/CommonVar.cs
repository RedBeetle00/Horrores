using UnityEngine;

namespace Common
{
    public class CommonVar : MonoBehaviour
    {
        //IPsCheck
        public static bool FirstIPreached = false;
        public static bool SecondIPreached = false;
        public static bool ThirdIPreached = false;
        public static bool FourthIPreached = false;
        public static bool AllIPsCollected = false;
        public static bool usedbefore = false;

        public static bool isUse;
        public static bool canMove = true;

        public static bool inShkaf;
        public static bool inBath;
        public static bool inBed;

        public static bool inDanger;

        public static void ResetAll()
        {
            FirstIPreached = false;
            SecondIPreached = false;
            ThirdIPreached = false;
            FourthIPreached = false;
            AllIPsCollected = false;
        }
    }
}