using System;

using static System.Console;
using static RefOutCheckUp.ThatIsAllYouGot;
using static System.Threading.Tasks.Task;
using System.Threading;

namespace RefOutCheckUp
{
    internal class Program : Malta, IMalta
    {
        public static void Main(string[] args)
        {            
            awaitSpain();
            awaitItaly();

            ReadLine();
        }

        dynamic IMalta.Island { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        dynamic IMalta.GetCapital()
        {
            throw new NotImplementedException();
        }

        private protected static ThreadStart awaitSpain = async () => 
        {
            using (var spain = new Spain())
            {
                await Run(() =>
                {
                    spain.Madrid(ref x, ref y);
                    WriteLine($"{nameof(spain.Madrid)} |> {nameof(x)} has now become: {x} and {nameof(y)} has now become: {y}");
                })
                .ContinueWith(nextTask => {
                    spain.Barcelona(ref x, ref y);
                    WriteLine($"{nameof(spain.Barcelona)} |> {nameof(x)} has now become: {x} and {nameof(y)} has now become: {y}");
                });
            }            
        };

        private protected static ThreadStart awaitItaly = async () => 
        {
            using (var italy = new Italy())
            {
                await Run(() =>
                {
                    italy.Rome(x, y);
                    WriteLine($"{nameof(italy.Rome)} |> {nameof(x)} has now become: {x} and {nameof(y)} has now become: {y}");
                })
                .ContinueWith(nextTask =>
                {
                    italy.Milan(x, y, out var cValue);
                    WriteLine($"{nameof(italy.Milan)} |> {nameof(x)} has now become: {x} and {nameof(y)} has now become: {y}");
                })
                .ContinueWith(nextTask =>
                {
                    italy.SanRemo(ref x, ref y, out var cValue);
                    WriteLine($"{nameof(italy.SanRemo)} |> {nameof(x)} has now become: {x} and {nameof(y)} has now become: {y}");
                });
            }
        };
    }

    internal abstract class Malta
    {
        public object Island { get; set; } = "Island";
        object GetCapital() => null;
    }

    public interface IMalta
    {
        dynamic Island { get; set; }
        dynamic GetCapital();
    }

    internal class Spain : IDisposable
    {
        protected internal void Madrid(ref short a, ref short b)
        {
            short? c = null;
            c = (short)((a + 15) + (b + 10));
            WriteLine($"\n{nameof(c)} value adds up to: {c}");
        }

        protected internal void Barcelona(ref short a, ref short b)
        {            
            a = (short)(a + 15);
            b = (short)(b + 10);
            short? c = null;
            
            c = (short)(a + b);
            WriteLine($"\n{nameof(c)} value adds up to: {c}");
        }

        public void Dispose() => (x, y) = (default, default);
    }

    internal class Italy : IDisposable
    {
        protected internal void Rome(int a, int b)
        {
            a = a + 15;
            b = b + 10;
            int? c = null;

            c = a + b;
            WriteLine($"\n{nameof(c)} value adds up to: {c}");
        }

        protected internal void Milan(int a, int b, out byte? c)
        {
            a += 100;
            b += 99;
            c = (byte)(a - b);
            WriteLine($"\n{nameof(c)} value adds up to: {c}");
        }

        protected internal void SanRemo(ref short a, ref short b, out byte? c)
        {
            a += 100;
            b += 99;
            c = (byte)(a - b);
            WriteLine($"\n{nameof(c)} value adds up to: {c}");
        }

        public void Dispose() => (x, y) = (default, default);
    }

    internal class ThatIsAllYouGot
    {
        public static short x = default;
        public static short y = default;
    }
}
