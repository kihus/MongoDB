using MongoDB.Driver;

// string connection
var client = new MongoClient("mongodb+srv://brunonlsctt_db_user:Pmz0Fy95yrwnJFub@interacaomongo.mpghkok.mongodb.net/");

// create/use database
var database = client.GetDatabase("InterAcaoMongo");

// create/user database
var collection = database.GetCollection<User>("Usuarios");

// add one user
var user = new User("Fabricio", "fabi123");
collection.InsertOne(user);

// add many users
var manyUsers = new List<User> {
	(new User("Rogerio", "2022")),
	(new User("Marcola", "2023")),
	(new User("Gustavo", "2024")),
	(new User("Guilherme", "2025")),
	(new User("Guto", "2026")),
	(new User("Gerson", "2027"))
};

collection.InsertMany(manyUsers);

// list users
var users = await collection.FindAsync(x => true).Result.ToListAsync();
foreach (var item in users)
{
	Console.WriteLine(item);
}

// repalce data in user
var usuarioReplace = collection.Find(x => x.Login == "Gustavo").FirstOrDefault(); // find user
usuarioReplace.Password = "123"; // modify pass
collection.ReplaceOne(x => x.Login == usuarioReplace.Login, usuarioReplace); // find by login and replace data
Console.WriteLine(usuarioReplace);

// update data in user
var usuarioUpdate = collection.UpdateOne(x => x.Login == "Gustavo",
	Builders<User> // make BSON to MongoDB
	.Update
	.Set(x => x.Password, "2000"));

// update login and situation
var updateDefinition = Builders<User>
						.Update
						.Set(x => x.Login, "Virginia")
						.Set(y => y.IsActive, false)
						.Set(z => z.UpdateAt, DateTime.UtcNow);

var userUpdated = collection.UpdateOne(x => x.Login == "Gustavo", updateDefinition); // pass definition builder 

// delete 
collection.DeleteOne(x => x.Login == "Virginia");

// filter data
var filterCaseInsensitive = Builders<User>.Filter.Regex(x => x.Login, "^G"); // 

var filterUsers = collection.Find(filterCaseInsensitive).ToList();

Console.WriteLine("Listagem de usuarios que comeca com G");
filterUsers.ForEach(x => Console.WriteLine(x));
