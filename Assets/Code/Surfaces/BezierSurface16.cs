using Unity.Mathematics;
using UnityEngine;

namespace Surfaces
{
	public readonly struct BezierSurface16
	{
		public readonly float3[][] Points;

		public BezierSurface16(float3[][] points)
		{
			Debug.Assert(points.Length == 4);
			Debug.Assert(points[0].Length == 4);

			Points = points;
		}

		public float3 SamplePoint(float s, float t)
		{
			Debug.Assert(s >= 0f && s <= 1f);
			Debug.Assert(t >= 0f && t <= 1f);

			var result = float3.zero;

			for (int i = 0; i <= 3; i++)
			for (int j = 0; j <= 3; j++)
			{
				result += Points[i][j] * Bernstein(3, i, s) * Bernstein(3, j, t);
			}

			return result;
		}

		float Bernstein(int n, int i, float t)
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