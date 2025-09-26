using MyMonkeyApp;

var asciiArts = new[]
{
    @"  __,=@"""=.__
 (  o   o  )
   (  =^=  )
   ("" )___("" )",
    @"   w  c( .. )o   (
    \\__ (- )    __)
        /\\     (
       /(_)___)",
    @"   (o o)
  (  =^=  )
  ("" )___("" )",
    @"   (o o)
  /  V  \
 /(  _  )\\
   ^^ ^^",
    @"   (o o)
  (  =^=  )
  ("" )___("" )
   Monkey!"
};

async Task ShowMenuAsync()
{
	while (true)
	{
		Console.Clear();
		// 무작위 ASCII 아트 출력
		var art = asciiArts[new Random().Next(asciiArts.Length)];
		Console.WriteLine(art);
		Console.WriteLine("\n==== Monkey App ====");
		Console.WriteLine("1. 모든 원숭이 나열");
		Console.WriteLine("2. 이름으로 특정 원숭이의 세부 정보 가져오기");
		Console.WriteLine("3. 무작위 원숭이 가져오기");
		Console.WriteLine("4. 앱 종료");
		Console.Write("메뉴를 선택하세요: ");
		var input = Console.ReadLine();
		Console.WriteLine();
		switch (input)
		{
			case "1":
				await ListAllMonkeysAsync();
				break;
			case "2":
				await ShowMonkeyByNameAsync();
				break;
			case "3":
				await ShowRandomMonkeyAsync();
				break;
			case "4":
				Console.WriteLine("앱을 종료합니다.");
				return;
			default:
				Console.WriteLine("잘못된 입력입니다. 엔터를 눌러 계속하세요.");
				Console.ReadLine();
				break;
		}
	}
}

async Task ListAllMonkeysAsync()
{
	var monkeys = await MonkeyHelper.GetMonkeysAsync();
	Console.WriteLine($"총 {monkeys.Count}마리의 원숭이가 있습니다:\n");
	foreach (var m in monkeys)
	{
		Console.WriteLine($"- {m.Name} ({m.Location}) - 개체수: {m.Population}");
	}
	Console.WriteLine("\n엔터를 누르면 메뉴로 돌아갑니다.");
	Console.ReadLine();
}

async Task ShowMonkeyByNameAsync()
{
	Console.Write("원숭이 이름을 입력하세요: ");
	var name = Console.ReadLine();
	if (string.IsNullOrWhiteSpace(name)) return;
	var monkey = await MonkeyHelper.GetMonkeyByNameAsync(name);
	if (monkey == null)
	{
		Console.WriteLine("해당 이름의 원숭이를 찾을 수 없습니다.");
	}
	else
	{
		PrintMonkeyDetails(monkey);
	}
	Console.WriteLine("\n엔터를 누르면 메뉴로 돌아갑니다.");
	Console.ReadLine();
}

async Task ShowRandomMonkeyAsync()
{
	var monkey = await MonkeyHelper.GetRandomMonkeyAsync();
	if (monkey == null)
	{
		Console.WriteLine("원숭이 데이터를 불러올 수 없습니다.");
	}
	else
	{
		PrintMonkeyDetails(monkey);
		var count = MonkeyHelper.GetRandomAccessCount(monkey.Name);
		Console.WriteLine($"(이 원숭이는 무작위로 {count}번 선택되었습니다.)");
	}
	Console.WriteLine("\n엔터를 누르면 메뉴로 돌아갑니다.");
	Console.ReadLine();
}

void PrintMonkeyDetails(Monkey m)
{
	Console.WriteLine($"이름: {m.Name}");
	Console.WriteLine($"위치: {m.Location}");
	Console.WriteLine($"개체수: {m.Population}");
	Console.WriteLine($"설명: {m.Details}");
	Console.WriteLine($"위도: {m.Latitude}, 경도: {m.Longitude}");
	Console.WriteLine($"이미지: {m.Image}");
}

await ShowMenuAsync();
