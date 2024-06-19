<Query Kind="Statements">
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Text.Json.Nodes</Namespace>
</Query>

var json = File.ReadAllText(@"Z:\Exemples et sources externes\tech-radar\docs\config.json");
var jsonNode = JsonNode.Parse(json/*, new JsonDocumentOptions { CommentHandling = JsonCommentHandling.Skip }*/);

var outputDoc = new JsonObject();

// Get the "entries" array
JsonArray entriesArray = jsonNode!.Root!["entries"]!.AsArray();

// Sort the "entries" array based on the "quadrant" property
var sortedNodes = entriesArray
	.OrderBy(n => n!["quadrant"]!.GetValue<int>())
	.ThenBy(n => n!["ring"]!.GetValue<int>())
	.ThenBy(n => n!["label"]!.GetValue<string>());

//sortedNodes.Dump();

// Create a new JsonArray from the sorted list
var sortedEntriesArray = new JsonArray(sortedNodes.Cast<JsonNode>().Select(n => n.DeepClone()).ToArray());

// Copy date node, add entries array
outputDoc.Add("date", jsonNode!.Root!["date"]!.DeepClone());
outputDoc.Add("entries", sortedEntriesArray);

var memoryStream = new MemoryStream();
var writer = new Utf8JsonWriter(memoryStream, new JsonWriterOptions { Indented = true } );
outputDoc.WriteTo(writer);
writer.Flush();
var result = Encoding.UTF8.GetString(memoryStream.ToArray());
result.Dump();