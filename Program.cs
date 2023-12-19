using MongoDataAccess.DataAccess;
using MongoDB.Driver;
using MongoDataAccess.Models;

//copy this string from MongoDbUi->3 dot->Copy connection string
//string connectionString = "your db";
//string databaseName = "simple_db";
//string collectionName = "people";//it is TABLE in SQL

//MongoClient client = new MongoClient(connectionString);//connection our database
//IMongoDatabase db = client.GetDatabase(databaseName);//getting our database
//IMongoCollection<PersonModel> collection = db.GetCollection<PersonModel>(collectionName);//getting our SQL TABLE and connecting with our PersonModel class

//PersonModel person = new PersonModel();

//Console.WriteLine("Select option:");
//Console.WriteLine("1. Get All Data");
//Console.Write("2. Create Data\n>");

//string option = Console.ReadLine();

//switch (option)
//{
//	case "1":
//		// _ => true  : return every record  _ means we dont have anything and not using, so pass nothing
//		var results = await collection.FindAsync(_ => true);

//		foreach (var result in results.ToList())
//			Console.WriteLine($"{result.Id}: {result.Name} {result.LastName}");
//		break;

//	case "2":
//		person.Name = Console.ReadLine();
//		person.LastName = Console.ReadLine();
//		await collection.InsertOneAsync(person);
//		break;

//	default:
//		break;
//}

ChoreDataAccess db = new();

// if we use async and awaits in our data access layer, we have to use this await keyword, exept it doesnt work
await db.CreateUser(new UserModel() { Name = "John", LastName = "Doe" });

List<UserModel> users = await db.GetAllUsers();

ChoreModel chore = new ChoreModel
{
	AssignedTo = users.Last(),
	FrequencyInDays = 7,
	ChoreText = "just trying"
};

await db.CreateChore(chore);

List<ChoreModel> chores = await db.GetAllChores();

ChoreModel newChore = chores.First();
newChore.LastCompleted = DateTime.UtcNow;

await db.CompleteChore(newChore);
