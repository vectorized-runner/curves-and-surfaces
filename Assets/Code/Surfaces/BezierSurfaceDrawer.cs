using Unity.Mathematics;
using UnityEngine;

namespace Surfaces
{
	public class BezierSurfaceDrawer : MonoBehaviour
	{
		public Transform[] Points;
		public int SampleAmountT = 100;
		public int SampleAmountS = 100;

		public Color DrawColor = Color.yellow;

		float3 GetPos(Transform tf)
		{
			return tf.position;
		}

		void Update()
		{
			if (SampleAmountT <= 0 || SampleAmountS <= 0)
			{
				Debug.LogError("SampleAmount should be positive.");
				return;
			}

			var points = new float3[4][];
			points[0] = new float3[4] { GetPos(Points[0]), GetPos(Points[1]), GetPos(Points[2]), GetPos(Points[3]) };
			points[1] = new float3[4] { GetPos(Points[4]), GetPos(Points[5]), GetPos(Points[6]), GetPos(Points[7]) };
			points[2] = new float3[4] { GetPos(Points[8]), GetPos(Points[9]), GetPos(Points[10]), GetPos(Points[11]) };
			points[3] = new float3[4] { GetPos(Points[12]), GetPos(Points[13]), GetPos(Points[14]), GetPos(Points[15]) };

			var surface = new BezierSurface16(points);

			var deltaS = 1f / SampleAmountS;
			var deltaT = 1f / SampleAmountT;

			for (float t = 0f; t <= 1f; t += deltaT)
			for (float s = 0f; s <= 1f; s += deltaS)
			{
				var current = surface.SamplePoint(s, t);
				var next = surface.SamplePoint(math.min(s + deltaS, 1f), t);
				Debug.DrawLine(current, next, DrawColor);
			}

			Debug.Log("Drawing");
		}
	}
}