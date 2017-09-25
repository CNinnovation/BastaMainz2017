using System;
using System.IO;
using System.Net;

namespace LocalFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestRun1();
            //TestRun2();
            //TestRun3();
            // StartSort();
            // WhenDoesItEnd();
            AsynchronousPattern1("https://csharp.christiannagel.com");
            AsynchronousPattern2("https://csharp.christiannagel.com");
            Console.ReadLine();
        }

        private static void TestRun1()
        {
            string[] coll = { "one", "two", "three" };

            try
            {
#line 100
                var q = coll.Filter1(null);

                foreach (var item in q)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }


        private static void TestRun2()
        {
            string[] coll = { "one", "two", "three" };

            try
            {
#line 100
                var q = coll.Filter2(null);

                foreach (var item in q)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }


        private static void TestRun3()
        {
            string[] coll = { "one", "two", "three" };

            try
            {
#line 100
                var q = coll.Filter3(null);

                foreach (var item in q)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void StartSort()
        {
            int[] arr = { 2, 9, 3, 4, 8 };
            QuickSort(arr);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }

        public static void WhenDoesItEnd()
        {
            Console.WriteLine(nameof(WhenDoesItEnd));
            void InnerLoop(int ix)
            {
                Console.WriteLine(ix++);
                InnerLoop(ix);
            }
            InnerLoop(1);
        }

        public static void QuickSort<T>(T[] elements) where T : IComparable<T>
        {
            void Sort(int start, int end)
            {
                int i = start, j = end;
                var pivot = elements[(start + end) / 2];

                while (i <= j)
                {
                    while (elements[i].CompareTo(pivot) < 0) i++;
                    while (elements[j].CompareTo(pivot) > 0) j--;
                    if (i <= j)
                    {
                        T tmp = elements[i];
                        elements[i] = elements[j];
                        elements[j] = tmp;
                        i++;
                        j--;
                    }
                }

                if (start < j) Sort(start, j);
                if (i < end) Sort(i, end);
            }

            Sort(0, elements.Length - 1);
        }

        static void AsynchronousPattern1(string url)
        {
            WebRequest request = WebRequest.Create(url);
            IAsyncResult result = request.BeginGetResponse(ar =>
            {
                using (WebResponse response = request.EndGetResponse(ar))
                {
                    Stream stream = response.GetResponseStream();
                    var reader = new StreamReader(stream);

                    string content = reader.ReadToEnd();
                    Console.WriteLine(content.Substring(0, 100));
                    Console.WriteLine();
                }
            }, null);
        }

        private static void AsynchronousPattern2(string url)
        {
            WebRequest request = WebRequest.Create(url);
            IAsyncResult result = request.BeginGetResponse(ReadResponse, null);

            void ReadResponse(IAsyncResult ar)
            {
                using (WebResponse response = request.EndGetResponse(ar))
                {
                    Stream stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream);
                    string content = reader.ReadToEnd();
                    Console.WriteLine(content.Substring(0, 100));
                    Console.WriteLine();
                }
            }
        }
    }
}
