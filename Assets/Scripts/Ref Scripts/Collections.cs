using UnityEngine;

public class GridPlacement : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToPlace;
    // Array of GameObjects to randomly select from
    [SerializeField] int gridWidth = 5;
    [SerializeField] int gridHeight = 5;
    [SerializeField] float cellSize = 1.0f; // Size of each grid cell

    void Start()
    {
        PlaceRandomObjectsInGrid();
    }

    void PlaceRandomObjectsInGrid()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                // 1. Select a random object from the array
                int randomIndex = Random.Range(0, objectsToPlace.Length);
                GameObject selectedObject = objectsToPlace[randomIndex];

                // 2. Calculate the position for the current grid cell
                Vector3 spawnPosition = new Vector3(x * cellSize, y * cellSize, 0);
                // Adjust Y for 2D or 3D as needed

                // 3. Instantiate the selected object at the calculated position
                Instantiate(selectedObject, spawnPosition, Quaternion.identity, this.transform);

                // Parent to this object for organization
            }
        }
    }
}

