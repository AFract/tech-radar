<Query Kind="Statements" />

string res = string.Empty;
for (int quadrant = 0; quadrant < 3; quadrant++)
{
	for (int ring = 0; ring < 4; ring++)
	{
		var tmpl = $$"""
{
	"quadrant": {{quadrant}},
      "ring": {{ring}},
      "label": "Test {{quadrant}}-{{ring}}",
      "active": true,
      "moved": 1
	},
""";
res+=tmpl + Environment.NewLine;
	}
}

res.Dump();