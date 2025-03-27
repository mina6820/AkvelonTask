namespace AkvelonTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FizzBuzzDetector detector = new FizzBuzzDetector();
            string input = """
                        Mary had a little lamb
                        Little lamb, little lamb
                        Mary had a little lamb
                        It's fleece was white as snow
                        """;
            FizzBuzzResult result = detector.GetOverlappings(input);

            Console.WriteLine($"Output String:\n{result.Output}\n\nCount: {result.Count}");
        }
    }
}
