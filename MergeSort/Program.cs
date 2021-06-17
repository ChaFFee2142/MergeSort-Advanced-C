using System;
using System.Threading.Tasks;
using System.Linq;
class Program
{

	static void Main(string[] args)
	{
		Int32[] array = new Int32[100];
		Random rd = new Random();
		for (Int32 i = 0; i < array.Length; ++i)
		{
			array[i] = rd.Next(100);
		}

		int[] arr1 = new int[array.Length / 4], arr2 = new int[array.Length / 4], arr3 = new int[array.Length / 4], arr4 = new int[array.Length / 4];

		System.Console.WriteLine("Unsorted:");
		foreach (Int32 x in array)
			System.Console.Write(x + " ");
		for (int j = 0; j < array.Length / 4; j++)
		{
			arr1[j] = array[j];
			arr2[j] = array[array.Length / 4 + j];
			arr3[j] = array[array.Length / 4 * 2 + j];
			arr4[j] = array[array.Length / 4 * 3 + j];
		}
		Task t1 = Task.Run(() => arr1 = MergeSort(arr1));
		Task t2 = Task.Run(() => arr2 = MergeSort(arr2));
		Task t3 = Task.Run(() => arr3 = MergeSort(arr3));
		Task t4 = Task.Run(() => arr4 = MergeSort(arr4));
		Task.WaitAll(t1, t2, t3, t4);
		array = Merge(Merge(arr1, arr2), Merge(arr3, arr4));
		System.Console.WriteLine("\n\nSorted:");
		foreach (Int32 x in array)
			System.Console.Write(x + " ");
		System.Console.WriteLine("\n\nPress a key");
		System.Console.ReadLine();
	}
	static Int32[] MergeSort(Int32[] array)
	{
		if (array.Length == 1)
		{
			return array;
		}

		Int32 middle = array.Length / 2;
		return Merge(MergeSort(array.Take(middle).ToArray()), MergeSort(array.Skip(middle).ToArray()));
	}

	static Int32[] Merge(Int32[] arr1, Int32[] arr2)
	{
		Int32 ptr1 = 0, ptr2 = 0;
		Int32[] merged = new Int32[arr1.Length + arr2.Length];

		for (Int32 i = 0; i < merged.Length; ++i)
		{
			if (ptr1 < arr1.Length && ptr2 < arr2.Length)
			{
				merged[i] = arr1[ptr1] > arr2[ptr2] ? arr2[ptr2++] : arr1[ptr1++];
			}
			else
			{
				merged[i] = ptr2 < arr2.Length ? arr2[ptr2++] : arr1[ptr1++];
			}
		}

		return merged;
	}


}