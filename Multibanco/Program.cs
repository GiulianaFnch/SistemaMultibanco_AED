using Multibanco.PresentationLayer;

namespace Multibanco
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1()); 
        }
    }
}