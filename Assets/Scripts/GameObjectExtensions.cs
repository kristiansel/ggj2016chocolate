using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public static class GameObjectExtensions {
	//convenience function for getComponent<ComponentType> != null
	public static bool HasComponent<T>(this GameObject gameObject) where T : UnityEngine.Component {
		return gameObject.GetComponent<T>() != null;
	}

	public static T GetComponentInParents<T>(this GameObject gameObject) where T : UnityEngine.Component{
		Transform t = gameObject.transform;
		while(t != null){
			T component = t.GetComponent<T>();
			if(component!=null){
				return component;
			}
			t = t.parent;
		}
		return null;
	}

	//easy access to 2d
	public static Vector2 GetPosition2D(this Transform t){
		return new Vector2(t.position.x, t.position.y);
	}

	//easy access to 2d
	public static Vector2 To2D(this Vector3 v){
		return new Vector2(v.x, v.y);
	}

	//easy access to 3d
	public static Vector3 To3D(this Vector2 v, float z=0){
		return new Vector3(v.x, v.y, z);
	}

	public static T MaxBy<T>(this IEnumerable<T> source, Func<T, IComparable> selector) {
		//aggregate is the same as reduce in other programming languages
		return source.Aggregate((lhs, rhs) => selector(lhs).CompareTo(selector(rhs)) > 0  ? lhs : rhs);
	}

}