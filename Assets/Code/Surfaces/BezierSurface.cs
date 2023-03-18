using Unity.Mathematics;
using UnityEngine;

namespace Surfaces
{
	public readonly struct BezierSurface
	{
		public readonly float3 P1;
		public readonly float3 P2;
		public readonly float3 P3;
		public readonly float3 P4;

		public BezierSurface(float3 p1, float3 p2, float3 p3, float3 p4)
		{
			P1 = p1;
			P2 = p2;
			P3 = p3;
			P4 = p4;
		}

		public float3 SamplePoint(float s, float t)
		{
			Debug.Assert(s >= 0f && s <= 1f);
			Debug.Assert(t >= 0f && t <= 1f);

			var points4 = new[] { P1, P2, P3, P4 };
			var result = float3.zero;

			for (int i = 0; i <= 3; i++)
			for (int j = 0; j <= 3; j++)
			{
				result += points4[i] * Bernstein(3, i, s) * Bernstein(3, j, t);
			}

			return result;
		}

		float3 Bernstein(int n, int i, float t)
		{
			return Combination(n, i) * Pow(t, i) * Pow(1 - t, n - i);
		}

		float Pow(float t, int i)
		{
			return math.pow(t, i);
		}

		int Combination(int n, int r)
		{
			return Factorial(n) / (Factorial(r) * Factorial(n - r));
		}

		int Factorial(int n)
		{
			Debug.Assert(n >= 0);

			var res = 1;

			while (n > 1)
			{
				res *= n;
				n--;
			}

			return res;
		}
	}
}