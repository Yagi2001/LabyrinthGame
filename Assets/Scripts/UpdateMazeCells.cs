using UnityEngine;
using System.Collections.Generic;

public class UpdateMazeCells : MonoBehaviour
{
    public GameObject mazeCellPrefab; // The updated prefab

    void Start()
    {
        // Find all clones of the MazeCell in the scene
        GameObject[] clones = GameObject.FindGameObjectsWithTag( "MazeCell" );

        foreach (GameObject clone in clones)
        {
            // Store the position, rotation, and active states of the clone and its walls
            Vector3 position = clone.transform.position;
            Quaternion rotation = clone.transform.rotation;

            var activeStates = StoreActiveStates( clone );

            // Destroy the old clone
            Destroy( clone );

            // Instantiate a new clone from the updated prefab
            GameObject newClone = Instantiate( mazeCellPrefab, position, rotation );

            // Restore the active states
            RestoreActiveStates( newClone, activeStates );
        }
    }

    // Helper method to store the active states of the game object and its children
    private Dictionary<string, bool> StoreActiveStates( GameObject obj )
    {
        var activeStates = new Dictionary<string, bool>();

        foreach (Transform child in obj.transform)
        {
            activeStates[child.name] = child.gameObject.activeSelf;
        }

        return activeStates;
    }

    // Helper method to restore the active states of the game object and its children
    private void RestoreActiveStates( GameObject obj, Dictionary<string, bool> activeStates )
    {
        foreach (Transform child in obj.transform)
        {
            if (activeStates.ContainsKey( child.name ))
            {
                child.gameObject.SetActive( activeStates[child.name] );
            }
        }
    }
}