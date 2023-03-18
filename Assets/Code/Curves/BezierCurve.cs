using Unity.Mathematics;
using UnityEngine;


namespace Curves
{
	public readonly struct BezierCurve
	{
		public readonly float3 P1;
		public readonly float3 P2;
		public readonly float3 P3;
		public readonly float3 P4;

		public BezierCurve(float3 p1, float3 p2, float3 p3, float3 p4)
		{
			P1 = p1;
			P2 = p2;
			P3 = p3;
			P4 = p4;
		}

		public float3 SamplePoint(float t)
		{
			Debug.Assert(t >= 0f && t <= 1f);

			var oneMinusT = 1 - t;
			var a1 = oneMinusT * oneMinusT * oneMinusT * P1;
			var a2 = 3 * t * oneMinusT * oneMinusT * P2;
			var a3 = 3 * t * t * oneMinusT * P3;
			var a4 = t * t * t * P4;

			return a1 + a2 + a3 + a4;
		}
	}
}