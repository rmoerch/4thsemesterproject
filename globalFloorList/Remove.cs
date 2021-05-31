using System.Collections.Generic;
using UnityEngine;

namespace globalFloorList
{
    internal class Remove : List<Vector2Int>
    {
        private List<BoundsInt> availableRooms;

        public Remove(List<BoundsInt> availableRooms)
        {
            this.availableRooms = availableRooms;
        }
    }
}