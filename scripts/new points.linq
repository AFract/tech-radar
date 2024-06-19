<Query Kind="Statements" />

string res = string.Empty;
int ring = 0;
int quadrant = 2;

var  items = new []
{
"Polly",
"Kreya",
"LibreHardwareMonitor",
"CliWrap",
"Enums.NET"
};


foreach(var item in items)
{
	var tmpl = $$"""
{
	"quadrant": {{quadrant}},
      "ring": {{ring}},
      "label": "{{item}}",
      "active": true,
      "moved": 0
	},
""";
	res += tmpl + Environment.NewLine;
}


res.Dump();