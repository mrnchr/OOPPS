using UnityEditor;
using UnityEngine;

namespace OOPPS.City.Editor
{
    public static class TileTools
    {
        private const string BASE_PATH = "Tools/Tile/";

        [MenuItem(BASE_PATH + "Recreate All")]
        public static void RecreateAll()
        {
            foreach (TileView tile in Object.FindObjectsByType<TileView>(FindObjectsInactive.Include, FindObjectsSortMode.None))
            {
                tile.RecreateMaterial();
            }
        }
    }
}