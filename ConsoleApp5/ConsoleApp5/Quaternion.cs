using System;

public class Quaternion
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }
    public double D { get; set; }

    public Quaternion(double a, double b, double c, double d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }

    
    public static Quaternion operator +(Quaternion q1, Quaternion q2)
    {
        return new Quaternion(q1.A + q2.A, q1.B + q2.B, q1.C + q2.C, q1.D + q2.D);
    }

    public static Quaternion operator -(Quaternion q1, Quaternion q2)
    {
        return new Quaternion(q1.A - q2.A, q1.B - q2.B, q1.C - q2.C, q1.D - q2.D);
    }

    
    public static Quaternion operator *(Quaternion q1, Quaternion q2)
    {
        double a = q1.A * q2.A - q1.B * q2.B - q1.C * q2.C - q1.D * q2.D;
        double b = q1.A * q2.B + q1.B * q2.A + q1.C * q2.D - q1.D * q2.C;
        double c = q1.A * q2.C - q1.B * q2.D + q1.C * q2.A + q1.D * q2.B;
        double d = q1.A * q2.D + q1.B * q2.C - q1.C * q2.B + q1.D * q2.A;

        return new Quaternion(a, b, c, d);
    }

    
    public double Norm()
    {
        return Math.Sqrt(A * A + B * B + C * C + D * D);
    }

    
    public Quaternion Conjugate()
    {
        return new Quaternion(A, -B, -C, -D);
    }

    
    public Quaternion Inverse()
    {
        double normSquared = A * A + B * B + C * C + D * D;
        if (normSquared == 0)
        {
            throw new InvalidOperationException("Quaternion has zero norm, cannot calculate inverse.");
        }

        double invNormSquared = 1.0 / normSquared;
        return new Quaternion(A * invNormSquared, -B * invNormSquared, -C * invNormSquared, -D * invNormSquared);
    }

    
    public static bool operator ==(Quaternion q1, Quaternion q2)
    {
        return q1.A == q2.A && q1.B == q2.B && q1.C == q2.C && q1.D == q2.D;
    }

    public static bool operator !=(Quaternion q1, Quaternion q2)
    {
        return !(q1 == q2);
    }

    
    public double[,] ToRotationMatrix()
    {
        double[,] matrix = new double[3, 3];

        matrix[0, 0] = A * A + B * B - C * C - D * D;
        matrix[0, 1] = 2 * (B * C - A * D);
        matrix[0, 2] = 2 * (A * C + B * D);

        matrix[1, 0] = 2 * (B * C + A * D);
        matrix[1, 1] = A * A - B * B + C * C - D * D;
        matrix[1, 2] = 2 * (C * D - A * B);

        matrix[2, 0] = 2 * (B * D - A * C);
        matrix[2, 1] = 2 * (A * B + C * D);
        matrix[2, 2] = A * A - B * B - C * C + D * D;

        return matrix;
    }
}

