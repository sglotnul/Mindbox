using Geometry;
using Geometry.Exceptions;

Start();

void Start()
{
    Console.WriteLine("circle test started...");
    FailingTestCase<ValidationException>(() => 
    {
        var c = new Circle(-1);
    });
    TestCase(()=> CircleTest(5, 78.54));
    Console.WriteLine("success\n");

    Console.WriteLine("triangle test started...");
    FailingTestCase<ValidationException>(() => 
    {
        var c = new Triangle(7, 3, 4);
    });
    TestCase(() => TriangleTest(1, 1, 1, 0.43));
    TestCase(() => TriangleTest(3, 4, 5, 6));
    TestCase(() => RightTriangleTest(3, 4, 5, true));
    TestCase(() => RightTriangleTest(1, 1, 1, false));
    Console.WriteLine("success\n");

    Console.WriteLine("TESTS PASSED");

    Console.ReadKey();
}

//Нужен для избегания многократного повторения блоков try-catch
void TestCase(Action f)
{
    try
    {
        f();
    }
    catch (TestException exc)
    {
        Console.WriteLine(exc.Message);
        Console.ReadKey();

        Environment.Exit(1);
    }
}

//Нужен для проверки валидации полей фигуры
void FailingTestCase<T>(Action f) where T : Exception
{
    try
    {
        f();
    }
    catch (T exc)
    {
        Console.WriteLine($"expected {typeof(T)} exception received\nmessage: {exc.Message}");
        return;
    }

    Console.WriteLine($"test failed: {typeof(T)} expected");
    Environment.Exit(1);
}

//Проверяет правильно ли объект фигуры считает свою площадь
void CircleTest(double r, double expectedArea)
{
    var circle = new Circle(r);
    CheckArea(circle, expectedArea);
}

//Проверяет правильно ли объект фигуры считает свою площадь
void TriangleTest(double s1, double s2, double s3, double expectedArea)
{
    var triangle = new Triangle(s1, s2, s3);
    CheckArea(triangle, expectedArea);
}

void CheckArea(IFigure f, double expectedArea)
{
    double area = Math.Round(f.Area(), 2);

    if (area != expectedArea) throw new TestException($"the value of the area is not as expected\nExpected: {expectedArea}; Got: {area}");
}

//Проверяет правильно ли объект Triangle определяет прямоугольный ли он
void RightTriangleTest(double s1, double s2, double s3, bool expected)
{
    var triangle = new Triangle(s1, s2, s3);
    bool right = triangle.IsRight();

    if (right != expected)
    {
        throw new TestException($"IsRight method result is not as expected\nExpected: {expected}; Got: {right}");
    }
}