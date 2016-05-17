using System;

class Triangle
{
    static void Main()
    {
        //Reading the input
        int aX = int.Parse(Console.ReadLine());
        int aY = int.Parse(Console.ReadLine());

        int bX = int.Parse(Console.ReadLine());
        int bY = int.Parse(Console.ReadLine());

        int cX = int.Parse(Console.ReadLine());
        int cY = int.Parse(Console.ReadLine());

        //Finding distances between each point
        //Sides are named after their points infront of them - example : side a = BC
        double cSide = Math.Sqrt(Math.Pow((bX - aX),2)+ Math.Pow((bY - aY),2));
        double bSide = Math.Sqrt(Math.Pow((cX - aX), 2) + Math.Pow((cY - aY), 2));
        double aSide = Math.Sqrt(Math.Pow((cX - bX), 2) + Math.Pow((cY - bY), 2));

        //Checking for possible triangle
        if (aSide+bSide > cSide && bSide + cSide > aSide && aSide + cSide > bSide )
        {
            Console.WriteLine("Yes");
            double halfPerimeter = (aSide + bSide + cSide) / 2;
            double halfPerimeterMultiply = (halfPerimeter - aSide) * (halfPerimeter - bSide) * (halfPerimeter - cSide);
            double area = Math.Sqrt(halfPerimeter*halfPerimeterMultiply);
            Console.WriteLine("{0:F2}",area);
        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine("{0:F2}",cSide);
        }
    }
}