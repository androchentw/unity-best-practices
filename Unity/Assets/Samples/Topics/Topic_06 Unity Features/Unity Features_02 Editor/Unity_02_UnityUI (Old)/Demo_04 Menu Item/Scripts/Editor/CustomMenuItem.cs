﻿using RMC.BestPractices.Shared;
using UnityEditor;
using UnityEngine;

namespace RMC.BestPractices.Features.EditorScripting.Demo_04_MenuItem
{
	/// <summary>
	/// Render menu items in the top-bar Unity app menu.
	/// 
	/// You can add keyboard shortcuts too.
	/// See <a href="https://learn.unity.com/tutorial/editor-scripting#5c7f8528edbc2a002053b5f9">article</a>.
	/// 
	/// </summary>
	public class CustomMenuItem : Editor
	{
		// SHOW MENU ITEM
		[MenuItem(BestPracticesConstants.MenuItemPath + 
			"Demo_MenuItem/(+) Add Cube To Scene", priority = BestPracticesConstants.CreateAssetMenuPriority)]
		private static void AddCubeToScene()
		{
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.AddComponent<MyCustomCube>();

		}

		// SHOW MENU ITEM
		[MenuItem(BestPracticesConstants.MenuItemPath + 
			"Demo_MenuItem/(-) Remove Cube From Scene", priority = BestPracticesConstants.CreateAssetMenuPriority)]
		private static void RemoveCubeFromScene()
		{
			MyCustomCube[] myCustomCubes = GameObject.FindObjectsByType<MyCustomCube>(FindObjectsSortMode.InstanceID);

			if (myCustomCubes.Length == 0)
			{
				return;
			}

			
			// Unity has 2 ways to destroy depending on isPlaying
			if (Application.isPlaying)
			{
				Destroy(myCustomCubes[myCustomCubes.Length - 1].gameObject);
			}
			else
			{
				DestroyImmediate(myCustomCubes[myCustomCubes.Length - 1].gameObject);
			}
		}
		
		// TOGGLE MENU ITEM ENABLED
		[MenuItem(BestPracticesConstants.MenuItemPath + 
			"Demo_MenuItem/(-) Remove Cube From Scene", true, priority = BestPracticesConstants.CreateAssetMenuPriority)]
		private static bool RemoveCubeFromScene_Toggle()
		{
			MyCustomCube[] myCustomCubes = GameObject.FindObjectsByType<MyCustomCube>(FindObjectsSortMode.InstanceID);

			// Return TRUE to enable
			return myCustomCubes.Length > 0;
		}
	}
}