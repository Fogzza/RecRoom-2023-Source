using System;
using UnityEngine;

namespace Delaunay
{
	[Serializable]
	public class Vertex<T>
	{
		public T Data;

		public Vector3 Position;
	}
}
