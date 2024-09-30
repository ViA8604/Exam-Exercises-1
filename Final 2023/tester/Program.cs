using System.Text.Json;
using MatCom.Tester;

Directory.CreateDirectory(".output");
var tester = new Tester();
var result = tester.Test(Path.Combine(".output", "cache.json"), input => Solution.GetRoutes(new Map(Tester.MakeMatrix(input.Item1), input.Item2, input.Item3), input.Item4))!;
File.Delete(Path.Combine(".output", "result.json"));
File.WriteAllText(Path.Combine(".output", "result.json"), JsonSerializer.Serialize(result));