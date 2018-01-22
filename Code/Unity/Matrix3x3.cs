using UnityEngine;

public struct Matrix3x3
{
	// m#row#col
	public float m00;
	public float m01;
	public float m02;
	public float m10;
	public float m11;
	public float m12;
	public float m20;
	public float m21;
	public float m22;

	public Matrix3x3 (
		float m00,
		float m01,
		float m02,
		float m10,
		float m11,
		float m12,
		float m20,
		float m21,
		float m22)
	{
			
		this.m00 = m00;
		this.m01 = m01;
		this.m02 = m02;
		this.m10 = m10;
		this.m11 = m11;
		this.m12 = m12;
		this.m20 = m20;
		this.m21 = m21;
		this.m22 = m22;
	}

	public Matrix3x3 (Matrix3x3 m)
	{
		m00 = m.m00;
		m10 = m.m10;
		m20 = m.m20;
		m01 = m.m01;
		m11 = m.m11;
		m21 = m.m21;
		m02 = m.m02;
		m12 = m.m12;
		m22 = m.m22;
	}

	public static Matrix3x3 identity {
		get {
			Matrix3x3 matrix = new Matrix3x3 ();
			matrix.m00 = 1;
			matrix.m11 = 1;
			matrix.m22 = 1;
			return matrix;
		}
	}


	public float GetDeterminant ()
	{
		return m00 * (m11 * m22 - m12 * m21)
		- m01 * (m10 * m22 - m12 * m20)
		+ m02 * (m10 * m21 - m11 * m20);
	}

	public Matrix3x3 Invert ()
	{
		float determinant = GetDeterminant ();

		if (determinant == 0)
			throw new UnityException ("Can't invert matrix with determinant 0");
			
		float invdet = 1f / determinant;

		Matrix3x3 m = new Matrix3x3 ();
		m.m00 = (m11 * m22 - m21 * m12) * invdet;
		m.m10 = (m20 * m12 - m10 * m22) * invdet;
		m.m20 = (m10 * m21 - m20 * m11) * invdet;
		m.m01 = (m21 * m02 - m01 * m22) * invdet;
		m.m11 = (m00 * m22 - m20 * m02) * invdet;
		m.m21 = (m20 * m01 - m00 * m21) * invdet;
		m.m02 = (m01 * m12 - m11 * m02) * invdet;
		m.m12 = (m10 * m02 - m00 * m12) * invdet;
		m.m22 = (m00 * m11 - m10 * m01) * invdet;

		return m;
	}

	public Matrix3x3 Transpose ()
	{
		Matrix3x3 matrix = new Matrix3x3 ();
		matrix.m00 = m00;
		matrix.m01 = m10;
		matrix.m02 = m20;
		matrix.m10 = m01;
		matrix.m11 = m11;
		matrix.m12 = m21;
		matrix.m20 = m02;
		matrix.m21 = m12;
		matrix.m22 = m22;
		return matrix;
	}

	public static Vector2 MultiplyVector2 (Matrix3x3 m1, Vector2 inVector)
	{
		Vector2 outVector = new Vector2 ();
		outVector.x = m1.m00 * inVector.x + m1.m01 * inVector.y + m1.m02;
		outVector.y = m1.m10 * inVector.x + m1.m11 * inVector.y + m1.m12;
		return outVector;
	}

	public static Vector3 MultiplyVector3 (Matrix3x3 m1, Vector3 inVector)
	{
		Vector3 outVector = new Vector3 ();
		outVector.x = m1.m00 * inVector.x + m1.m01 * inVector.y + m1.m02;
		outVector.y = m1.m10 * inVector.x + m1.m11 * inVector.y + m1.m12;
		outVector.z = inVector.z;
		return outVector;
	}

	public static Matrix3x3 MultiplyMatrix3x3 (Matrix3x3 m1, Matrix3x3 m2)
	{
		Matrix3x3 m = new Matrix3x3 ();

		m.m00 = m1.m00 * m2.m00 + m1.m10 * m2.m01 + m1.m20 * m2.m02;
		m.m10 = m1.m00 * m2.m10 + m1.m10 * m2.m11 + m1.m20 * m2.m12;
		m.m20 = m1.m00 * m2.m20 + m1.m10 * m2.m21 + m1.m20 * m2.m22;
		m.m01 = m1.m01 * m2.m00 + m1.m11 * m2.m01 + m1.m21 * m2.m02;
		m.m11 = m1.m01 * m2.m10 + m1.m11 * m2.m11 + m1.m21 * m2.m12;
		m.m21 = m1.m01 * m2.m20 + m1.m11 * m2.m21 + m1.m21 * m2.m22;
		m.m02 = m1.m02 * m2.m00 + m1.m12 * m2.m01 + m1.m22 * m2.m02;
		m.m12 = m1.m02 * m2.m10 + m1.m12 * m2.m11 + m1.m22 * m2.m12;
		m.m22 = m1.m02 * m2.m20 + m1.m12 * m2.m21 + m1.m22 * m2.m22;
		return m;
	}

	public static Matrix3x3 operator * (Matrix3x3 m1, Matrix3x3 m2)
	{ 
		return Matrix3x3.MultiplyMatrix3x3 (m1, m2); 
	}

	public static Vector3 operator * (Matrix3x3 m, Vector3 v)
	{ 
		return Matrix3x3.MultiplyVector3 (m, v); 
	}

	public static Vector2 operator * (Matrix3x3 m, Vector2 v)
	{ 
		return Matrix3x3.MultiplyVector2 (m, v); 
	}

	public override string ToString ()
	{
		float det = GetDeterminant ();
		return string.Format ("[Matrix3x3: det={9} m00={0}, m01={1}, m02={2}, m10={3}, m11={4}, m12={5}, m20={6}, m21={7}, m22={8}]", m00, m10, m20, m01, m11, m21, m02, m12, m22, det);
	}
}
