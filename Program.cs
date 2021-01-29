using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BadCode
{
	class BadProgram
	{
		/*But du programme :
		1. lit un fichier de données de Student
		2. trouve le student ayant la meilleure note et affiche à l'écran sa note et son prenom
		3. trouve le plus jeune student et l'affiche à l'écran
		*/

		class Student
		{
			public int id;
			public string prenom;
			public int age;
			public decimal grade;
		}

		public static void Main()
		{
			//Rien à corriger ici : écriture du fichier de données
			var fileName = "filename.txt";
			WriteFile(fileName);

			//DEBUT DU TEST
			ReadAllText(fileName, out List<Student> s);

			decimal tmp = 0;

			foreach (var i in s)
			{
				if (tmp < i.grade)
					tmp = i.grade;
			}

			var prenom = "";
			foreach (var i in s)
			{
				if (i.grade == tmp)
				{
					prenom = i.prenom;
				}
			}
			Console.WriteLine("Meilleure note Id : " + tmp + " Prenom : " + prenom);

			int count = s.ToArray().Length;
			Console.WriteLine(count);

			tmp = -1;
			for (var i = 0; i < s.Count(); i++)
			{
				if (tmp > 0 && s[i].age < tmp)
					tmp = s[i].age;
			}
			Console.WriteLine(tmp);
			//FIN DU TEST

			Console.ReadLine();
		}

		static void ReadAllText(string path, out List<Student> s)
		{
			var sr = new StreamReader(path);
			var file = sr.ReadToEndAsync();

			var obj = JsonConvert.DeserializeObject<List<Student>>(file.Result);
			s = obj;
		}

		//RIEN A CORRIGER ICI
		public static void WriteFile(string path)
		{
			var studentList = new List<Student>{
				new Student {id = 1, prenom = "John", age = 25, grade = 10.5m },
				new Student {id = 3, prenom = "Marc", age = 29, grade = 9.4m },
				new Student {id = 7, prenom = "Pierre", age = 21, grade = 10.1m },
				new Student {id = 2, prenom = "Luc", age = 24, grade = 10.5m }
			};

			string json = JsonConvert.SerializeObject(studentList);
			File.WriteAllText(path, json);
		}
	}
}