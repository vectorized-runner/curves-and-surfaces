using UnityEngine;

namespace Surfaces
{
	public class BezierSurfaceDrawer : MonoBehaviour
	{
		public Transform P1;
		public Transform P2;
		public Transform P3;
		public Transform P4;
		public int SampleAmount = 100;
		public Color DrawColor = Color.yellow;

		void Update()
		{
			if (SampleAmount <= 0)
			{
				Debug.LogError("SampleAmount should be positive.");
				return;
			}

			var surface = new BezierSurface(
				P1.transform.position,
				P2.transform.position,
				P3.transform.position,
				P4.transform.position);

			var previousPoint = surface.SamplePoint(0f, 0f);

			for (float t = 0f; t <= 1f; t += 1f / SampleAmount)
			{
				for (float s = 0f; s <= 1f; s += 1f / SampleAmount)
				{
					// Debug.Log($"SamplePoint s: {s}, t: {t}");

					var point = surface.SamplePoint(s, t);

					Debug.DrawLine(previousPoint, point, DrawColor);

					previousPoint = point;
				}

				Debug.DrawLine(previousPoint, surface.SamplePoint(1f, t), DrawColor);

				//Debug.Log($"SamplePoint s: {1f}, t: {t}");
			}

			Debug.DrawLine(previousPoint, surface.SamplePoint(1f, 1f), DrawColor);

			Debug.Log("Drawing");
		}
	}
}